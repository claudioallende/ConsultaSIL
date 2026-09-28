using System.Collections.Generic;
using System.Threading.Tasks;
using SILClient.Models.Class.Reporte;

namespace SILClient.Models.Data;

public class ReporteStore
{
	public async Task<IList<ReporteViewModel>> GetReporte(FiltroReporteViewModel filtro)
	{
		using DataUtil store = new DataUtil();
		return await store.RequestPostAndDeserializeAsync<IList<ReporteViewModel>>("GetReporteCliente", filtro);
	}
}
