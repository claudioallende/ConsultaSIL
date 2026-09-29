using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SILClient.Models.Auth;

namespace SILClient.Models.Class.Account;

public class SignInManager : SignInManager<Usuario, string>
{
	public SignInManager(UserManager<Usuario, string> userManager, IAuthenticationManager authenticationManager)
		: base(userManager, authenticationManager)
	{
	}

	// Baja de acabase.com.ar: antes el usuario/password y los permisos (EsCYO) venian del SSO y el
	// access_token de IdentityServer3. Ahora valida contra App_Data/usuarios.json y emite un JWT
	// propio (LocalTokenIssuer), mismo mecanismo que CuposCorretajeWeb.
	public async Task<SignInStatus> PasswordSignInAsync(string UserName, string Password)
	{
		UsuarioLocal usuario = UsuariosLocalStore.FindByUsername(UserName);
		if (usuario == null || !LocalPasswordHasher.Verify(Password, usuario.PasswordSalt, usuario.PasswordHash, usuario.PasswordIterations))
		{
			return SignInStatus.Failure;
		}
		SetClaim("access_token", LocalTokenIssuer.IssueAccessToken(usuario));
		SetClaim("EsCuentaCYO", usuario.EsCuentaCYO ? "True" : "False");
		await SignInAsync(new Usuario(usuario.Usuario, usuario.Usuario, null), isPersistent: false, rememberBrowser: false);
		return SignInStatus.Success;
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

	public void SetClaim(string key, string value)
	{
		UserManager userManager = UserManager as UserManager;
		userManager.SetClaim(key, value);
	}
}
