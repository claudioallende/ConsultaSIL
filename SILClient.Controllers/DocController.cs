using System;
using System.Linq;
using System.Web.Mvc;

namespace SILClient.Controllers
{

[Authorize]
public class DocController : Controller
{
	// Solo se sirven estos archivos de ~/Manuales/. Antes el nombre del querystring se concatenaba a la
	// ruta, y "filename=..\Web.config" devolvia el Web.config del sitio (con JWT_SIGNING_KEY).
	private static readonly string[] Manuales =
	{
		"Sistema Integral de Logistica.pdf",
		"STOP ministerio de transporte.pdf",
		"CTG codigo de trazabilidad de granos.pdf"
	};

	public ActionResult GetPdf(string filename)
	{
		string manual = Manuales.FirstOrDefault((string m) => string.Equals(m, filename, StringComparison.OrdinalIgnoreCase));
		if (manual == null)
		{
			return HttpNotFound();
		}
		string path = Server.MapPath("~/Manuales/" + manual);
		if (!System.IO.File.Exists(path))
		{
			return HttpNotFound("Manual no disponible: " + manual);
		}
		return File(path, "application/pdf", manual);
	}
}
}
