using System.Collections.Generic;
using System.Threading.Tasks;
using SILClient.Models.Class.Cupo;
using SILClient.Models.Class.Filtro;
using SILClient.Models.Class.Info;
using SILClient.Models.Data;

namespace SILClient.Models.Services;

public class ServicioResumenCuposVendedor
{
	private CuposClienteStore CuposClienteStore;

	public ServicioResumenCuposVendedor()
	{
		CuposClienteStore = new CuposClienteStore();
	}

	public async Task<IList<CuposAgrupadosPorVendedor>> GetCuposAgruposPorVendedorAsync(bool InformadoStop)
	{
		return await CuposClienteStore.GetCuposClienteAgrupadosPorVendedor(InformadoStop);
	}

	public async Task<CuposAgrupados> GetCuposAgrupados()
	{
		return await CuposClienteStore.GetCuposAgrupadosInformadosSTOPYCyo();
	}

	public async Task<CuposAgrupados> GetCuposAgrupados(GranoCompradorPuerto filtro)
	{
		return await CuposClienteStore.GetCuposAgrupadosInformadosSTOPYCyo(filtro);
	}

	public async Task<IList<Grano>> GetGranos()
	{
		return await CuposClienteStore.GetGranos();
	}
}
