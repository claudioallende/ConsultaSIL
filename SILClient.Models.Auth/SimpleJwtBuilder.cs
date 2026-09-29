using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace SILClient.Models.Auth;

// Emite un JWT HS256 sin paquetes extra. Copia de CuposCorretajeWeb (SILWeb): SILResourceServer
// lo valida con UseJwtBearerAuthentication usando la misma clave simetrica (JWT_SIGNING_KEY).
public static class SimpleJwtBuilder
{
	public static string Issue(string issuer, string audience, string signingKey, TimeSpan lifetime, IEnumerable<KeyValuePair<string, object>> claims)
	{
		DateTimeOffset now = DateTimeOffset.UtcNow;
		Dictionary<string, object> header = new Dictionary<string, object>
		{
			["alg"] = "HS256",
			["typ"] = "JWT"
		};
		Dictionary<string, object> payload = new Dictionary<string, object>
		{
			["iss"] = issuer,
			["aud"] = audience,
			["iat"] = now.ToUnixTimeSeconds(),
			["nbf"] = now.ToUnixTimeSeconds(),
			["exp"] = now.Add(lifetime).ToUnixTimeSeconds()
		};
		foreach (KeyValuePair<string, object> claim in claims)
		{
			payload[claim.Key] = claim.Value;
		}
		string headerB64 = Base64UrlEncode(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header)));
		string payloadB64 = Base64UrlEncode(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));
		string unsigned = headerB64 + "." + payloadB64;
		using HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(signingKey));
		byte[] signature = hmac.ComputeHash(Encoding.UTF8.GetBytes(unsigned));
		return unsigned + "." + Base64UrlEncode(signature);
	}

	private static string Base64UrlEncode(byte[] bytes)
	{
		return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
	}
}
