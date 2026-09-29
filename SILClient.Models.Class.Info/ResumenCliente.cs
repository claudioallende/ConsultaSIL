using System.Collections.Generic;

namespace SILClient.Models.Class.Info
{

public class ResumenCliente
{
	public string Grano { get; set; }

	public string Comprador { get; set; }

	public string Puerto { get; set; }

	public IList<ResumenDia> Dias { get; set; }
}
}
