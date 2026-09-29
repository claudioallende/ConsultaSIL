using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace SILClient.Models.Class
{

public static class ClaimsUtil
{
	public static string GetAccessToken()
	{
		ClaimsIdentity claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
		string text = (from x in claimsIdentity.Claims
			where x.Type == "access_token"
			select x.Value).FirstOrDefault();
		if (string.IsNullOrEmpty(text))
		{
			throw new Exception("Token vacío o nulo");
		}
		return text;
	}

	public static long GetCuenta()
	{
		ClaimsIdentity claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
		string value = (from x in claimsIdentity.Claims
			where x.Type == "Cuit"
			select x.Value).FirstOrDefault();
		if (string.IsNullOrEmpty(value))
		{
			throw new Exception("Token vacío o nulo");
		}
		return 100395L;
	}

	public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
	{
		if (!(currentPrincipal.Identity is ClaimsIdentity claimsIdentity))
		{
			return null;
		}
		Claim claim = claimsIdentity.Claims.FirstOrDefault((Claim c) => c.Type == key);
		return claim.Value;
	}

	public static string GetClaimValue(IEnumerable<Claim> claims, string key)
	{
		Claim claim = claims.FirstOrDefault((Claim c) => c.Type == key);
		return claim.Value;
	}
}
}
