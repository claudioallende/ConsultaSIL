using SILClient.Models.Class.Cupo;

namespace SILClient.Models.Class.Info;

public class IdentificadorDetalle
{
	public long CuentaVendedor { get; set; }

	public long CuentaComprador { get; set; }

	public long CuentaPuerto { get; set; }

	public int CodigoGrano { get; set; }

	public Consignacion Consignacion { get; set; }

	public bool InformadoStop { get; set; }

	public bool EsCYO { get; set; }
}
