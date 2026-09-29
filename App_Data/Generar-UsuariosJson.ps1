<#
Genera App_Data\usuarios.json para Consulta SIL (reemplazo del SSO acabase.com.ar).

Entrada: el export de consulta_datos_usuarios_consultasil.sql, separado por ',' o ';', con
encabezado. Se leen por POSICION las columnas:
    0 Usuario, 1 Nombre, 2 Email, 3 Password, 4 Cuits (ignorado), 5 Cuentas, 6 EsCuentaCYO, 8 DIAG_ESTADO
Por posicion y no por nombre porque DIAG_PUERTAS sale sin comillas y con comas ("71,1126"), lo que
corre las columnas de la derecha; las de la izquierda no se ven afectadas.
  - Cuentas: cuentas vendedoras separadas por '|' (puertas 71 y 73 del SSO viejo). Obligatorio: la
    API filtra los cupos por VENDCTA contra esta lista; sin cuentas el usuario no veria nada.
  - DIAG_ESTADO: si existe y no es 1, el usuario se omite (inactivo en ACACLAVE).
  - Password en texto plano: solo se usa para calcular el hash, no se escribe en el json.
    Borrar el export despues de generar.

Hash: PBKDF2-HMACSHA1, 210.000 iteraciones, salt 16 bytes, hash 32 bytes (igual que
LocalPasswordHasher.cs y que CuposCorretajeWeb).

Ejemplo:
    .\Generar-UsuariosJson.ps1 -Csv C:\temp\Exportcuentacooperativas.txt -Salida .\usuarios.json
#>
param(
    [Parameter(Mandatory = $true)] [string] $Csv,
    [string] $Salida = (Join-Path $PSScriptRoot 'usuarios.json')
)

$ErrorActionPreference = 'Stop'
$Iteraciones = 210000

# [IO.File] resuelve rutas relativas contra el directorio del proceso, no el de PowerShell.
$Csv = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($Csv)
$Salida = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($Salida)

# Split por separador respetando comillas dobles, y sin las comillas en cada campo.
function Split-Linea([string] $linea, [string] $sep) {
    $re = [regex]::Escape($sep) + '(?=(?:[^"]*"[^"]*")*[^"]*$)'
    return , @([regex]::Split($linea, $re) | ForEach-Object { $_.Trim().Trim('"').Trim() })
}

# Devuelve siempre long[] sin duplicados (la coma evita que PowerShell desenrolle un array de 0 o 1
# elemento, que ConvertTo-Json escribiria como escalar/objeto en vez de array JSON).
function Get-Cuentas([string] $texto) {
    if ([string]::IsNullOrWhiteSpace($texto)) { return , [long[]]@() }
    return , [long[]]@($texto.Split('|') | ForEach-Object { $_.Trim() } | Where-Object { $_ } | ForEach-Object { [long] $_ } | Select-Object -Unique)
}

$lineas = @([IO.File]::ReadAllLines($Csv, [Text.Encoding]::UTF8) | Where-Object { $_.Trim() })
$sep = if ($lineas[0].Contains(';')) { ';' } else { ',' }
$encabezado = Split-Linea $lineas[0] $sep
if ($encabezado[0] -ne 'Usuario' -or $encabezado[3] -ne 'Password' -or $encabezado[5] -ne 'Cuentas') {
    throw "Encabezado inesperado: $($lineas[0])"
}
$tieneEstado = $encabezado.Count -gt 8 -and $encabezado[8] -eq 'DIAG_ESTADO'

$usuarios = New-Object System.Collections.Generic.List[object]
$omitidos = @()

foreach ($linea in ($lineas | Select-Object -Skip 1)) {
    $f = Split-Linea $linea $sep
    $usuario = $f[0].ToUpperInvariant()
    if (-not $usuario) { continue }
    $cuentas = Get-Cuentas $f[5]

    if ($tieneEstado -and $f[8] -ne '1') { $omitidos += "$usuario : estado $($f[8]) en ACACLAVE"; continue }
    if (-not $f[3]) { $omitidos += "$usuario : falta Password"; continue }
    if ($cuentas.Count -eq 0) { $omitidos += "$usuario : sin cuentas (puertas 71/73)"; continue }

    $salt = New-Object byte[] 16
    [System.Security.Cryptography.RandomNumberGenerator]::Create().GetBytes($salt)
    $pbkdf2 = New-Object System.Security.Cryptography.Rfc2898DeriveBytes($f[3], $salt, $Iteraciones)
    $hash = $pbkdf2.GetBytes(32)
    $pbkdf2.Dispose()

    $usuarios.Add([ordered]@{
        Usuario            = $usuario
        Nombre             = $f[1]
        Email              = $f[2]
        Activo             = $true
        PasswordSalt       = [Convert]::ToBase64String($salt)
        PasswordHash       = [Convert]::ToBase64String($hash)
        PasswordIterations = $Iteraciones
        Cuentas            = $cuentas
        EsCuentaCYO        = ($f[6] -eq 'True')
    })
}

$raiz = [ordered]@{
    GeneradoUtc   = (Get-Date).ToUniversalTime().ToString('o')
    Fuente        = [IO.Path]::GetFileName($Csv)
    HashAlgoritmo = "PBKDF2-HMACSHA1/$Iteraciones/salt16/hash32"
    Nota          = 'Consulta SIL - auth local (baja de acabase.com.ar). No versionar.'
    Usuarios      = $usuarios
}

if (Test-Path $Salida) { Copy-Item $Salida "$Salida.bak-$((Get-Date).ToString('yyyyMMdd-HHmmss'))" }
[IO.File]::WriteAllText($Salida, ($raiz | ConvertTo-Json -Depth 5), (New-Object System.Text.UTF8Encoding($false)))

Write-Host "Generados $($usuarios.Count) usuarios en $Salida"
if ($omitidos.Count -gt 0) {
    Write-Warning "$($omitidos.Count) filas omitidas:"
    $omitidos | ForEach-Object { Write-Warning "  $_" }
}
