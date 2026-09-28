using System.Collections.Generic;
using System.Threading.Tasks;
using SILClient.Models.Class.Reporte;
using SILClient.Models.Data;

namespace SILClient.Models.Services;

public class ServicioReporte
{
	public async Task<IList<ReporteViewModel>> GetReporte(FiltroReporteViewModel filtro)
	{
		ReporteStore Store = new ReporteStore();
		return await Store.GetReporte(filtro);
	}
}
