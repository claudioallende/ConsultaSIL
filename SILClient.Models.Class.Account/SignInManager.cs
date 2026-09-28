using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using RestSharp;

namespace SILClient.Models.Class.Account;

public class SignInManager : SignInManager<Usuario, string>
{
	public SignInManager(UserManager<Usuario, string> userManager, IAuthenticationManager authenticationManager)
		: base(userManager, authenticationManager)
	{
	}

	public async Task<SignInStatus> PasswordSignInAsync(string UserName, string Password)
	{
		Task<string> IdTokenAsync = GetIdToken(UserName, Password);
		TokenResponse token = GetAccessToken(UserName, Password);
		string IdToken = await IdTokenAsync;
		if (!string.IsNullOrEmpty(IdToken) && !string.IsNullOrEmpty(token.AccessToken))
		{
			DatosUsuario datos = await GetDatosUsuario(IdToken);
			SetTokenInSession(token);
			SetClaim("EsCuentaCYO", ClaimsUtil.GetClaimValue(datos.Claims, "EsCYO"));
			Task signin = SignInAsync(new Usuario(UserName, UserName, Password), isPersistent: false, rememberBrowser: false);
			await signin;
			return SignInStatus.Success;
		}
		return SignInStatus.Failure;
	}

	public Task<DatosUsuario> GetDatosUsuario(string IdToken)
	{
		RestClient restClient = new RestClient(ConfigurationManager.AppSettings["SSO_SERVER"] + "/api/User/GetUserPermissionCuposCorretaje");
		RestRequest restRequest = new RestRequest();
		restRequest.Method = Method.GET;
		restRequest.AddHeader("Content-Type", "application/json");
		restRequest.AddHeader("Authorization", "Bearer " + IdToken);
		IRestResponse restResponse = restClient.Execute(restRequest);
		string content = restResponse.Content;
		return Task.Run(() => JsonConvert.DeserializeObject<DatosUsuario>(content, new JsonConverter[1]
		{
			new ClaimsConverter()
		}));
	}

	public Task<string> GetIdToken(string UserName, string Password)
	{
		RestClient restClient = new RestClient(ConfigurationManager.AppSettings["SSO_SERVER"] + "/api/user/authenticate");
		RestRequest restRequest = new RestRequest();
		restRequest.Method = Method.POST;
		restRequest.AddHeader("Content-Type", "application/json");
		restRequest.AddJsonBody(new
		{
			Username = UserName,
			Password = Password,
			Sitio = "cuposcorretaje"
		});
		IRestResponse restResponse = restClient.Execute(restRequest);
		string content = restResponse.Content;
		return Task.Run(() => JsonConvert.DeserializeObject<string>(content));
	}

	public async Task<SignInStatus> AcabaseSignInAsync(string idToken)
	{
		DatosUsuario datos = await GetDatosUsuario(idToken);
		if (datos.IsAuthenticated())
		{
			TokenResponse token = GetAccessToken(datos.USUARIO.ToLower(), datos.PASSWORD.ToLower());
			SetTokenInSession(token);
			SetClaim("EsCuentaCYO", ClaimsUtil.GetClaimValue(datos.Claims, "EsCYO"));
			await SignInAsync(new Usuario(datos.USUARIO, datos.USUARIO, datos.PASSWORD), isPersistent: false, rememberBrowser: false);
			return SignInStatus.Success;
		}
		return SignInStatus.Failure;
	}

	public new async Task SignInAsync(Usuario user, bool isPersistent, bool rememberBrowser)
	{
		AuthenticationManager.SignOut("ApplicationCookie");
		ClaimsIdentity userIdentity = await user.GenerateUserIdentityAsync(UserManager);
		if (rememberBrowser)
		{
			ClaimsIdentity claimsIdentity = AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(user.Id);
			AuthenticationManager.SignIn(new AuthenticationProperties
			{
				IsPersistent = isPersistent
			}, userIdentity, claimsIdentity);
		}
		else
		{
			AuthenticationManager.SignIn(new AuthenticationProperties
			{
				IsPersistent = isPersistent
			}, userIdentity);
		}
	}

	public void SetTokenInSession(TokenResponse token)
	{
		UserManager userManager = UserManager as UserManager;
		userManager.SetClaim("access_token", token.AccessToken);
	}

	public void SetClaim(string key, string value)
	{
		UserManager userManager = UserManager as UserManager;
		userManager.SetClaim(key, value);
	}

	public TokenResponse GetAccessToken(string UserName, string Password)
	{
		string clientId = ConfigurationManager.AppSettings["CLIENT_ID"];
		string clientSecret = ConfigurationManager.AppSettings["CLIENT_SECRET"];
		TokenClient tokenClient = new TokenClient(ConfigurationManager.AppSettings["AUTH_SERVER"], clientId, clientSecret);
		return RequestToken(tokenClient, UserName, Password);
	}

	public TokenResponse RequestToken(TokenClient tokenClient, string UserName, string Password)
	{
		return tokenClient.RequestResourceOwnerPasswordAsync(UserName, Password, ConfigurationManager.AppSettings["SCOPES"]).Result;
	}

	public TokenResponse RefreshToken(TokenClient tokenClient, string refreshToken)
	{
		Console.WriteLine("Using refresh token: {0}", refreshToken);
		return tokenClient.RequestRefreshTokenAsync(refreshToken).Result;
	}
}
