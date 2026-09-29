using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace SILClient.Models.Class.Account
{

public class UserManager : UserManager<Usuario, string>
{
	private IList<Claim> AllClaims { get; set; }

	public UserManager(IUserStore<Usuario, string> store)
		: base(store)
	{
		AllClaims = new List<Claim>();
	}

	public override Task<IList<Claim>> GetClaimsAsync(string userId)
	{
		return Task.FromResult(AllClaims);
	}

	public void SetAccessTokenClaims(string AccessToken)
	{
		AllClaims.Add(new Claim("access_token", AccessToken));
	}

	public void SetClaim(string key, string value)
	{
		AllClaims.Add(new Claim(key, value));
	}
}
}
