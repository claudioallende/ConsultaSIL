using System.Collections.Generic;
using System.Threading.Tasks;
using SILClient.Models.Class.Cupo;
using SILClient.Models.Class.Info;
using SILClient.Models.Data;

namespace SILClient.Models.Services
{

public class ServicioDetalleCuposVendedor
{
	public Task<IList<DetalleViewModel>> ObtenerDetalle(long CuentaComprador, long CuentaPuerto, int CodigoGrano, Consignacion Consignacion, bool InformadoStop, bool EsCYO)
	{
		CuposClienteStore cuposClienteStore = new CuposClienteStore();
		return cuposClienteStore.GetDetalleCupoCliente(CuentaComprador, CuentaPuerto, CodigoGrano, Consignacion, InformadoStop, EsCYO);
	}
}
}
