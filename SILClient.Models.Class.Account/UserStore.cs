using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace SILClient.Models.Class.Account
{

public class UserStore : IUserPasswordStore<Usuario, string>, IUserLockoutStore<Usuario, string>, IUserTwoFactorStore<Usuario, string>, IUserStore<Usuario, string>, IDisposable
{
	public Task CreateAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task<Usuario> FindByIdAsync(string userId)
	{
		throw new NotImplementedException();
	}

	public Task<Usuario> FindByNameAsync(string userName)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	public Task<string> GetPasswordHashAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task<bool> HasPasswordAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task SetPasswordHashAsync(Usuario user, string passwordHash)
	{
		throw new NotImplementedException();
	}

	public Task<int> GetAccessFailedCountAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task<bool> GetLockoutEnabledAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task<DateTimeOffset> GetLockoutEndDateAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task<int> IncrementAccessFailedCountAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task ResetAccessFailedCountAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task SetLockoutEnabledAsync(Usuario user, bool enabled)
	{
		throw new NotImplementedException();
	}

	public Task SetLockoutEndDateAsync(Usuario user, DateTimeOffset lockoutEnd)
	{
		throw new NotImplementedException();
	}

	public Task<bool> GetTwoFactorEnabledAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task SetTwoFactorEnabledAsync(Usuario user, bool enabled)
	{
		throw new NotImplementedException();
	}

	public Task AddClaimAsync(Usuario user, Claim claim)
	{
		throw new NotImplementedException();
	}

	public Task<IList<Claim>> GetClaimsAsync(Usuario user)
	{
		throw new NotImplementedException();
	}

	public Task RemoveClaimAsync(Usuario user, Claim claim)
	{
		throw new NotImplementedException();
	}
}
}
