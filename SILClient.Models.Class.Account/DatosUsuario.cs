using System.Collections.Generic;
using System.Security.Claims;

namespace SILClient.Models.Class.Account;

public class DatosUsuario
{
	public string USUARIO { get; set; }

	public string PASSWORD { get; set; }

	public string NOMBRE { get; set; }

	public IList<Claim> Claims { get; set; }

	public bool IsAuthenticated()
	{
		if (!string.IsNullOrEmpty(USUARIO))
		{
			return !string.IsNullOrEmpty(PASSWORD);
		}
		return false;
	}
}
