using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using SILClient.Models.Class.Filtro;
using SILClient.Models.Class.Info;
using SILClient.Models.Services;

namespace SILClient.Controllers
{

[Authorize]
public class InfoController : Controller
{
	public async Task<ActionResult> Index()
	{
		ServicioResumenCuposVendedor servicio = new ServicioResumenCuposVendedor();
		InfoViewModel infoViewModel = new InfoViewModel(await servicio.GetCuposAgrupados());
		InfoViewModel model = infoViewModel;
		return View(model);
	}

	[HttpPost]
	public async Task<ActionResult> Index(GranoCompradorPuerto filtro)
	{
		ServicioResumenCuposVendedor servicio = new ServicioResumenCuposVendedor();
		InfoViewModel infoViewModel = new InfoViewModel(await servicio.GetCuposAgrupados(filtro));
		InfoViewModel model = infoViewModel;
		return View(model);
	}

	public async Task<ActionResult> Detalle(string JsonId)
	{
		IList<DetalleViewModel> model = new List<DetalleViewModel>();
		ServicioDetalleCuposVendedor servicio = new ServicioDetalleCuposVendedor();
		try
		{
			IdentificadorDetalle Id = JsonConvert.DeserializeObject<IdentificadorDetalle>(JsonId);
			IList<DetalleViewModel> response = await servicio.ObtenerDetalle(Id.CuentaComprador, Id.CuentaPuerto, Id.CodigoGrano, Id.Consignacion, Id.InformadoStop, Id.EsCYO);
			if (response != null)
			{
				model = response;
			}
		}
		catch
		{
			ModelState.AddModelError("Error", "Error");
		}
		return View(model);
	}
}
}
