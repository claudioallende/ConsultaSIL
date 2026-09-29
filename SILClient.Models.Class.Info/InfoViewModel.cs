using System;
using System.Collections.Generic;

namespace SILClient.Models.Class.Info
{

public class InfoViewModel
{
	private int CantidadDias = 20;

	public IList<DateTime> Dias { get; set; }

	public IList<CuposAgrupadosPorVendedor> ListaResumenesInformadosStopNoCyo { get; set; }

	public IList<CuposAgrupadosPorVendedor> ListaResumenesNoInformadosStopNoCyo { get; set; }

	public IList<CuposAgrupadosPorVendedor> ListaResumenesInformadosStopCyo { get; set; }

	public IList<CuposAgrupadosPorVendedor> ListaResumenesNoInformadosStopCyo { get; set; }

	public string FiltroComprador { get; set; }

	public string FiltroPuerto { get; set; }

	public InfoViewModel()
	{
		ListaResumenesInformadosStopNoCyo = new List<CuposAgrupadosPorVendedor>();
		ListaResumenesNoInformadosStopNoCyo = new List<CuposAgrupadosPorVendedor>();
		ListaResumenesInformadosStopCyo = new List<CuposAgrupadosPorVendedor>();
		ListaResumenesNoInformadosStopCyo = new List<CuposAgrupadosPorVendedor>();
		Dias = GetDias();
	}

	public InfoViewModel(CuposAgrupados CuposAgrupados)
	{
		ListaResumenesInformadosStopNoCyo = CuposAgrupados.CuposInformadosSTOPNoCyo;
		ListaResumenesNoInformadosStopNoCyo = CuposAgrupados.CuposNoInformadosSTOPNoCyo;
		ListaResumenesInformadosStopCyo = CuposAgrupados.CuposInformadosSTOPCyo;
		ListaResumenesNoInformadosStopCyo = CuposAgrupados.CuposNoInformadosSTOPCyo;
		Dias = GetDias();
	}

	public IList<DateTime> GetDias()
	{
		IList<DateTime> list = new List<DateTime>();
		for (int i = 0; i <= CantidadDias; i++)
		{
			list.Add(DateTime.Now.AddDays(i).Date);
		}
		return list;
	}
}
}
