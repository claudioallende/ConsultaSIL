using System.ComponentModel.DataAnnotations;

namespace SILClient.Models.Class.Account;

public class LoginViewModel
{
	[Display(Name = "Usuario")]
	[Required]
	public string UserName { get; set; }

	[DataType(DataType.Password)]
	[Display(Name = "Contraseña")]
	[Required]
	public string Password { get; set; }
}
