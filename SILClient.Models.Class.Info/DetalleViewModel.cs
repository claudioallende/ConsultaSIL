using System;
using System.Collections.Generic;
using System.Linq;
using SILClient.Models.Class.Cupo;

namespace SILClient.Models.Class.Info
{

public class DetalleViewModel
{
	public long CuentaComprador { get; set; }

	public long CuentaVendedor { get; set; }

	public Puerto Puerto { get; set; }

	public Grano Grano { get; set; }

	public Consignacion Consignacion { get; set; }

	public IList<AlfanumericosDia> AlfanumericosPorDia { get; set; }

	public Consignacion GetConsignacionOrEmpty()
	{
		if (Consignacion == null)
		{
			return new Consignacion();
		}
		return Consignacion;
	}

	public IList<AlfanumericosDia> GetAlfanumericosParaDias(int CantidadDias)
	{
		IList<AlfanumericosDia> list = new List<AlfanumericosDia>();
		DateTime Dia = DateTime.Now.Date;
		AlfanumericosDia alfanumericosDia = null;
		for (int i = 0; i <= CantidadDias; i++)
		{
			Dia = Dia.AddDays(i);
			alfanumericosDia = AlfanumericosPorDia.Where((AlfanumericosDia x) => x.Dia == Dia).FirstOrDefault();
			if (alfanumericosDia != null)
			{
				list.Add(alfanumericosDia);
				continue;
			}
			list.Add(new AlfanumericosDia
			{
				Dia = Dia
			});
		}
		return list;
	}

	public IList<ObservacionViewModel> GetObservaciones()
	{
		return (from x in AlfanumericosPorDia.SelectMany((AlfanumericosDia x) => x.Alfanumericos)
			group x by x.Observacion into x
			where !string.IsNullOrEmpty(x.Key)
			select x).Select((IGrouping<string, InformacionAlfanumerico> x, int i) => new ObservacionViewModel
		{
			Valor = x.Key
		}).ToList();
	}
}
}
