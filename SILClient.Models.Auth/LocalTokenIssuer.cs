using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace SILClient.Models.Auth
{

// Arma el access_token que antes emitia IdentityServer3 (acabase.com.ar). JWT_ISSUER, JWT_AUDIENCE
// y JWT_SIGNING_KEY deben ser IDENTICOS a los de CuposCorretajeWeb y SILResourceServer: la API
// valida un unico issuer/audience/clave, asi los tokens de ambos fronts le sirven por igual.
// A diferencia del token de SILWeb, este lleva Cuit/Cuenta: todos los endpoints de api/Cliente
// filtran por ClaimsUtil.GetCuitOrCuenta() y fallan si el token no los trae. Esa lista se compara
// SIEMPRE contra VENDCTA (cuenta vendedora), nunca contra un CUIT; por eso se emite fijo el Cuit de
// ACA, que hace que GetCuitOrCuenta() devuelva el claim Cuenta con las cuentas del usuario.
public static class LocalTokenIssuer
{
	private const string CuitAca = "30500120882";

	public static string IssueAccessToken(UsuarioLocal usuario)
	{
		string issuer = ConfigurationManager.AppSettings["JWT_ISSUER"];
		string audience = ConfigurationManager.AppSettings["JWT_AUDIENCE"];
		string signingKey = ConfigurationManager.AppSettings["JWT_SIGNING_KEY"];
		int expiresMinutes = int.Parse(ConfigurationManager.AppSettings["JWT_EXPIRES_MINUTES"] ?? "1190");
		List<KeyValuePair<string, object>> claims = new List<KeyValuePair<string, object>>
		{
			new KeyValuePair<string, object>("Usuario", usuario.Usuario),
			new KeyValuePair<string, object>("Cuit", new List<string> { CuitAca }),
			new KeyValuePair<string, object>("Cuenta", ToStrings(usuario.Cuentas)),
			new KeyValuePair<string, object>("scope", "CuposCorrRSRCServ")
		};
		return SimpleJwtBuilder.Issue(issuer, audience, signingKey, TimeSpan.FromMinutes(expiresMinutes), claims);
	}

	// Como string (no numero JSON): el lado API hace Int64.Parse(claim.Value) y un array JSON
	// se mapea a un claim por elemento.
	private static List<string> ToStrings(IList<long> values)
	{
		return (values ?? new List<long>()).Select((long v) => v.ToString()).ToList();
	}
}
}
