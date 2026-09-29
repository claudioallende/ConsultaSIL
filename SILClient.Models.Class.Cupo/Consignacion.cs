using System.ComponentModel.DataAnnotations;

namespace SILClient.Models.Class.Cupo
{

public class Consignacion
{
	[Display(Name = "Solicitante")]
	public string Cuitsolicitante { get; set; }

	[Display(Name = "Nombre")]
	public string Nomsolicitante { get; set; }

	[Display(Name = "Intermediario")]
	public string Cuitintermediario { get; set; }

	[Display(Name = "Nombre")]
	public string Nomintermediario { get; set; }

	[Display(Name = "Rte. Comercial")]
	public string Cuitrtecomercial { get; set; }

	[Display(Name = "Nombre")]
	public string Nomrtecomercial { get; set; }

	[Display(Name = "Corredor Comprador")]
	public string Cuitcorrcomp { get; set; }

	[Display(Name = "Nombre")]
	public string Nomcorrcomp { get; set; }

	[Display(Name = "Mercado a Término")]
	public string Cuitmat { get; set; }

	[Display(Name = "Nombre")]
	public string Nommat { get; set; }

	[Display(Name = "Corredor Vendedor")]
	public string Cuitcorrvta { get; set; }

	[Display(Name = "Nombre")]
	public string Nomcorrvta { get; set; }

	[Display(Name = "Representante/Entregador")]
	public string Cuitrteent { get; set; }

	[Display(Name = "Nombre")]
	public string Nomrteent { get; set; }

	[Display(Name = "Destinatario")]
	public string Cuitdestinatario { get; set; }

	[Display(Name = "Nombre")]
	public string Nomdestinatario { get; set; }
}
}
