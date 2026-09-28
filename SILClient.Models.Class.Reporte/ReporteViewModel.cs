using System;

namespace SILClient.Models.Class.Reporte;

public class ReporteViewModel
{
	public long Id { get; set; }

	public DateTime Fecha { get; set; }

	public string FechaFormateada
	{
		get
		{
			return Fecha.Date.ToString("dd/MM/yyyy");
		}
		set
		{
		}
	}

	public string Grano { get; set; }

	public string Alfanumerico { get; set; }

	public string DetalleCupoSTOP { get; set; }

	public string Observacion { get; set; }

	public string Exportador { get; set; }

	public string Intermediario { get; set; }

	public string RteComercial { get; set; }

	public string CorredorComp { get; set; }

	public string CorredorVend { get; set; }

	public string Solicitante { get; set; }

	public string Mat { get; set; }

	public string Rteent { get; set; }

	public string CuentaVendedor { get; set; }

	public string CodigoGrano { get; set; }

	public string Destino { get; set; }

	public long Vendcyo { get; set; }
}
