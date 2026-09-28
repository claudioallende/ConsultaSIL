using System.Configuration;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using IdentityModel.Client;

namespace SILClient.Controllers;

public class CallApiController : Controller
{
	public async Task<ActionResult> GetCuposInfoStop()
	{
		object result = await CallApi((await GetTokenAsync()).AccessToken, informaStop: true);
		ViewBag.Json = result;
		return View("ShowApiResult");
	}

	public async Task<ActionResult> GetCuposNoInfoStop()
	{
		object result = await CallApi((await GetTokenAsync()).AccessToken, informaStop: false);
		ViewBag.Json = result;
		return View("ShowApiResult");
	}

	public async Task<ActionResult> UserCredentials()
	{
		ClaimsPrincipal user = User as ClaimsPrincipal;
		string token = user.FindFirst("access_token").Value;
		object result = await CallApi(token, informaStop: false);
		ViewBag.Json = result;
		return View("ShowApiResult");
	}

	private async Task<object> CallApi(string token, bool informaStop)
	{
		HttpClient client = new HttpClient();
		client.SetBearerToken(token);
		string llamada = ((!informaStop) ? string.Format(ConfigurationManager.AppSettings["RSRC_SERVER"] + "/GetCuposByStop/{0}/{1}", "100395", "0") : string.Format(ConfigurationManager.AppSettings["RSRC_SERVER"] + "/GetCuposByStop/{0}/{1}", "100395", "1"));
		HttpResponseMessage response = await client.GetAsync(llamada);
		if (response.IsSuccessStatusCode)
		{
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
		}
		return null;
	}

	private async Task<TokenResponse> GetTokenAsync()
	{
		TokenClient client = new TokenClient(ConfigurationManager.AppSettings["AUTH_SERVER"], ConfigurationManager.AppSettings["CLIENT_ID"], ConfigurationManager.AppSettings["CLIENT_SECRET"]);
		return await client.RequestClientCredentialsAsync(ConfigurationManager.AppSettings["SCOPES"]);
	}
}
