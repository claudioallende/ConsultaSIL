using System.Collections.Generic;
using System.Threading.Tasks;
using SILClient.Models.Class.Cupo;
using SILClient.Models.Class.Filtro;
using SILClient.Models.Class.Info;

namespace SILClient.Models.Data;

public class CuposClienteStore
{
	public Task<IList<CuposAgrupadosPorVendedor>> GetCuposClienteAgrupadosPorVendedor(bool InformadoStop)
	{
		string text = "0";
		if (InformadoStop)
		{
			text = "1";
		}
		using DataUtil dataUtil = new DataUtil();
		return dataUtil.RequestGetAndDeserializeAsync<IList<CuposAgrupadosPorVendedor>>("GetCupos/" + text);
	}

	public Task<IList<DetalleViewModel>> GetDetalleCupoCliente(long CuentaComprador, long CuentaPuerto, int CodigoGrano, Consignacion Consignacion, bool InformadoStop, bool EsCYO)
	{
		using DataUtil dataUtil = new DataUtil();
		return dataUtil.RequestPostAndDeserializeAsync<IList<DetalleViewModel>>("GetDetalleCuposStop", new { CuentaComprador, CuentaPuerto, CodigoGrano, Consignacion, InformadoStop, EsCYO });
	}

	public Task<IList<Grano>> GetGranos()
	{
		using DataUtil dataUtil = new DataUtil();
		return dataUtil.RequestGetAndDeserializeAsync<IList<Grano>>("GetGranos");
	}

	public async Task<CuposAgrupados> GetCuposAgrupadosInformadosSTOPYCyo()
	{
		using DataUtil store = new DataUtil();
		return await store.RequestGetAndDeserializeAsync<CuposAgrupados>("GetCuposAgrupados");
	}

	public async Task<CuposAgrupados> GetCuposAgrupadosInformadosSTOPYCyo(GranoCompradorPuerto filtro)
	{
		using DataUtil store = new DataUtil();
		return await store.RequestPostAndDeserializeAsync<CuposAgrupados>("BuscarCuposAgrupados", filtro);
	}
}
