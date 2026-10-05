using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SILClient.Controllers
{

[Authorize]
public class DocController : Controller
{
	// Solo se sirven estos archivos de ~/Manuales/. Antes el nombre del querystring se concatenaba a la
	// ruta, y "filename=..\Web.config" devolvia el Web.config del sitio (con JWT_SIGNING_KEY).
	// Clave: nombre que usan los links del menu (y nombre de la descarga). Valor: archivo en el servidor.
	private static readonly Dictionary<string, string> Manuales = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
	{
		{ "Sistema Integral de Logistica.pdf", "SIL_Sistema_Integral_de_Logistica.pdf" },
		{ "STOP ministerio de transporte.pdf", "STOP_ministerio_de_transporte.pdf" },
		{ "CTG codigo de trazabilidad de granos.pdf", "CTG_codigo_de_trazabilidad_de_granos.pdf" }
	};

	public ActionResult GetPdf(string filename)
	{
		string archivo;
		if (filename == null || !Manuales.TryGetValue(filename, out archivo))
		{
			return HttpNotFound();
		}
		string path = Server.MapPath("~/Manuales/" + archivo);
		if (!System.IO.File.Exists(path))
		{
			return HttpNotFound("Manual no disponible: " + archivo);
		}
		return File(path, "application/pdf", filename);
	}
}
}
