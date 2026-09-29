using System.Collections.Generic;

namespace SILClient.Models.Auth;

// Usuario de App_Data/usuarios.json (reemplazo del SSO acabase.com.ar, dado de baja).
// Mismo esquema de password que CuposCorretajeWeb (SILWeb), mas las cuentas vendedoras que puede
// consultar (ACABSAS.A_ACCESS.VALORES de las puertas 71 y 73 del SSO viejo).
public class UsuarioLocal
{
	public string Usuario { get; set; }

	public string Nombre { get; set; }

	public string Email { get; set; }

	public bool Activo { get; set; }

	public string PasswordSalt { get; set; }

	public string PasswordHash { get; set; }

	public int PasswordIterations { get; set; }

	public IList<long> Cuentas { get; set; }

	public bool EsCuentaCYO { get; set; }
}

public class UsuariosLocalFile
{
	public string GeneradoUtc { get; set; }

	public string Fuente { get; set; }

	public string HashAlgoritmo { get; set; }

	public string Nota { get; set; }

	public IList<UsuarioLocal> Usuarios { get; set; }
}
