using System.ComponentModel.DataAnnotations;

namespace SILClient.Models.Class.Account;

public class LoginAcabaseViewModel
{
	[Required]
	[Display(Name = "Usuario")]
	public string Usuario { get; set; }

	[Display(Name = "Contraseña")]
	[DataType(DataType.Password)]
	[Required]
	public string Password { get; set; }

	public string EsCyo { get; set; }

	public bool IsAuthenticated()
	{
		if (!string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Password))
		{
			return true;
		}
		return false;
	}
}
