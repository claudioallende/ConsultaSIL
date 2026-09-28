using System;
using IdentityModel.Client;

namespace SILClient.Models.Class.Account;

public class Identity
{
	public TokenClient GetToken()
	{
		string clientId = "prueba";
		string clientSecret = "prueba_sil";
		return new TokenClient("http://localhost:61030/identity/connect/token", clientId, clientSecret);
	}

	public TokenResponse RequestAccessToken(string UserName, string Password)
	{
		return GetToken().RequestResourceOwnerPasswordAsync(UserName, Password, "offline_access CuposCorrRSRCServ").Result;
	}

	public TokenResponse RequestAccessTokenFromRefreshToken(string refreshToken)
	{
		Console.WriteLine("Using refresh token: {0}", refreshToken);
		return GetToken().RequestRefreshTokenAsync(refreshToken).Result;
	}
}
