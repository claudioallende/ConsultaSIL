using System.Collections.Generic;

namespace SILClient.Models.Class.Info
{

public class CuposAgrupados
{
	public IList<CuposAgrupadosPorVendedor> CuposInformadosSTOPCyo { get; set; }

	public IList<CuposAgrupadosPorVendedor> CuposNoInformadosSTOPCyo { get; set; }

	public IList<CuposAgrupadosPorVendedor> CuposInformadosSTOPNoCyo { get; set; }

	public IList<CuposAgrupadosPorVendedor> CuposNoInformadosSTOPNoCyo { get; set; }
}
}
