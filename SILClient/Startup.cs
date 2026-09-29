using System;
using System.Web.Helpers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SILClient.Models.Class.Account;

namespace SILClient
{

public class Startup
{
	public void Configuration(IAppBuilder app)
	{
		AntiForgeryConfig.UniqueClaimTypeIdentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
		app.CreatePerOwinContext(() => new UserManager(new UserStore()));
		app.CreatePerOwinContext((IdentityFactoryOptions<SignInManager> options, IOwinContext context) => new SignInManager(context.GetUserManager<UserManager>(), context.Authentication));
		app.UseCookieAuthentication(new CookieAuthenticationOptions
		{
			AuthenticationType = "ApplicationCookie",
			LoginPath = new PathString("/Account/Login"),
			Provider = new CookieAuthenticationProvider(),
			ExpireTimeSpan = TimeSpan.FromMinutes(15.0)
		});
	}
}
}
