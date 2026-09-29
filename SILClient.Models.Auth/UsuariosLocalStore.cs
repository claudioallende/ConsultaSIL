using System;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace SILClient.Models.Auth
{

// Fuente de usuarios que reemplaza al SSO acabase.com.ar: App_Data/usuarios.json (no se versiona,
// se deploya aparte). Se relee en cada login (sin cache) para que un cambio manual en el servidor
// aplique sin reiniciar el sitio.
public static class UsuariosLocalStore
{
	private static string FilePath => HostingEnvironment.MapPath("~/App_Data/usuarios.json");

	public static UsuarioLocal FindByUsername(string usuario)
	{
		if (string.IsNullOrWhiteSpace(usuario))
		{
			return null;
		}
		return Load().Usuarios.FirstOrDefault((UsuarioLocal u) => u.Activo && string.Equals(u.Usuario, usuario.Trim(), StringComparison.OrdinalIgnoreCase));
	}

	private static UsuariosLocalFile Load()
	{
		string path = FilePath;
		if (!File.Exists(path))
		{
			throw new InvalidOperationException("No se encontro App_Data/usuarios.json (fuente local de usuarios).");
		}
		return JsonConvert.DeserializeObject<UsuariosLocalFile>(File.ReadAllText(path));
	}
}
}
