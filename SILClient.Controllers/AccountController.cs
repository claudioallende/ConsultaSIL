using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SILClient.Models.Class.Account;

namespace SILClient.Controllers;

public class AccountController : Controller
{
	private SignInManager _signInManager;

	public SignInManager SignInManager
	{
		get
		{
			return _signInManager ?? HttpContext.GetOwinContext().Get<SignInManager>();
		}
		private set
		{
			_signInManager = value;
		}
	}

	public AccountController()
	{
	}

	public AccountController(SignInManager signInManager)
	{
		SignInManager = signInManager;
	}

	[Authorize]
	[ValidateAntiForgeryToken]
	public ActionResult Signout()
	{
		HttpContext.GetOwinContext().Authentication.SignOut("ApplicationCookie");
		return RedirectToAction("Login");
	}

	[AllowAnonymous]
	public ActionResult Login(string returnUrl)
	{
		if (TempData["error"] != null)
		{
			ModelState.AddModelError("", TempData["error"].ToString());
		}
		ViewBag.ReturnUrl = returnUrl;
		return View();
	}

	[HttpPost]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> Login(LoginViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}
		try
		{
			switch (await SignInManager.PasswordSignInAsync(model.UserName, model.Password))
			{
			case SignInStatus.Success:
				return RedirectToAction("Index", "Info");
			case SignInStatus.LockedOut:
				return View("Lockout");
			default:
				ModelState.AddModelError("", "Usuario o contraseña incorrecto.");
				return View(model);
			}
		}
		catch (Exception)
		{
			ModelState.AddModelError("", "Error");
			return View(model);
		}
	}
}
