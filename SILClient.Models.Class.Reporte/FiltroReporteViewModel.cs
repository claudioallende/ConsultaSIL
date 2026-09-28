using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SILClient.Models.Class.Reporte;

public class FiltroReporteViewModel
{
	[Display(Name = "Grano")]
	public IEnumerable<SelectListItem> Granos { get; set; }

	public string Grano { get; set; }

	[Display(Name = "Fecha Desde")]
	public DateTime? FechaDesde { get; set; }

	[Display(Name = "Fecha Hasta")]
	public DateTime? FechaHasta { get; set; }
}
