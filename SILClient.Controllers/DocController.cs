using System.Web.Mvc;

namespace SILClient.Controllers;

[Authorize]
public class DocController : Controller
{
	public ActionResult GetPdf(string filename)
	{
		return File(Server.MapPath("~/Manuales/") + filename, "application/pdf", filename);
	}
}
