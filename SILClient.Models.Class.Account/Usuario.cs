using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace SILClient.Models.Class.Account
{

public class Usuario : IUser<string>
{
	public string Id { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public Usuario()
	{
	}

	public Usuario(string Id, string UserName, string Password)
	{
		this.Id = Id;
		this.UserName = UserName;
		this.Password = Password;
	}

	public virtual async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario, string> manager)
	{
		ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, "ApplicationCookie");
		userIdentity.AddClaims(await manager.GetClaimsAsync(UserName));
		return userIdentity;
	}
}
}
