using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;
using SILClient.Models.Class.Cupo;
using SILClient.Models.Class.Reporte;
using SILClient.Models.Data;
using SILClient.Models.Services;

namespace SILClient.Controllers
{

[Authorize]
public class ReporteController : Controller
{
	private static readonly Logger log = LogManager.GetCurrentClassLogger();

	public async Task<ActionResult> Index()
	{
		FiltroReporteViewModel model = new FiltroReporteViewModel();
		using (DataUtil store = new DataUtil())
		{
			model.Granos = (await store.RequestGetAndDeserializeAsync<IList<Grano>>("GetGranos")).Select((Grano x) => new SelectListItem
			{
				Value = x.CodigoGrano.ToString(),
				Text = x.Nombre
			});
		}
		return View(model);
	}

	public async Task<ActionResult> GetReporte(FiltroReporteViewModel model)
	{
		int num = default;
		_ = num;
		_ = 0;
		try
		{
			ServicioReporte servicio = new ServicioReporte();
			JsonResult result = Json(new
			{
				data = await servicio.GetReporte(model)
			});
			// Sin filtro de fechas la API devuelve todo el historial del cliente (miles de filas, ~2 MB):
			// supera el MaxJsonLength por defecto de JavaScriptSerializer (2.097.152 caracteres) y la
			// serializacion falla fuera del try, como un 500 sin log ("DataTables warning: Ajax error").
			result.MaxJsonLength = int.MaxValue;
			return result;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			throw ex;
		}
	}
}
}
