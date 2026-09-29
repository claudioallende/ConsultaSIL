using System;
using System.Security.Cryptography;

namespace SILClient.Models.Auth
{

// PBKDF2-HMACSHA1 (Rfc2898DeriveBytes), mismo esquema que CuposCorretajeWeb (SILWeb) y que
// App_Data/Generar-UsuariosJson.ps1, para que los hashes generados por el script verifiquen aca.
public static class LocalPasswordHasher
{
	public const int HashSizeBytes = 32;

	public const int SaltSizeBytes = 16;

	public const int DefaultIterations = 210000;

	public static bool Verify(string password, string saltBase64, string hashBase64, int iterations)
	{
		if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(saltBase64) || string.IsNullOrEmpty(hashBase64))
		{
			return false;
		}
		byte[] salt = Convert.FromBase64String(saltBase64);
		byte[] expectedHash = Convert.FromBase64String(hashBase64);
		using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
		{
		byte[] actualHash = pbkdf2.GetBytes(expectedHash.Length);
		return FixedTimeEquals(actualHash, expectedHash);
		}
	}

	private static bool FixedTimeEquals(byte[] a, byte[] b)
	{
		if (a.Length != b.Length)
		{
			return false;
		}
		int diff = 0;
		for (int i = 0; i < a.Length; i++)
		{
			diff |= a[i] ^ b[i];
		}
		return diff == 0;
	}
}
}
