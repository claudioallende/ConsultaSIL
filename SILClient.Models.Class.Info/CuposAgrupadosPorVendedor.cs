using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SILClient.Models.Class.Cupo;

namespace SILClient.Models.Class.Info
{

public class CuposAgrupadosPorVendedor
{
	[Display(Name = "Grano")]
	public virtual int GRANO { get; set; }

	[Display(Name = "NombreGrano")]
	public virtual string NOMGRANO { get; set; }

	[Display(Name = "Comprador")]
	public virtual long COMPCTA { get; set; }

	public virtual string COMPRADOR { get; set; }

	[Display(Name = "Puerto")]
	public virtual long PUERTOCTA { get; set; }

	public virtual string PUERTO { get; set; }

	[Display(Name = "Vendedor")]
	public virtual long VENDCTA { get; set; }

	public virtual string VENDEDOR { get; set; }

	[Display(Name = "InformadoStop")]
	public virtual int INFORMADOSTOP { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D0CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D0CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D1CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D1CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D2CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D2CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D3CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D3CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D4CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D4CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D5CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D5CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D6CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D6CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D7CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D7CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D8CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D8CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D9CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D9CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D10CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D10CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D11CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D11CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D12CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D12CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D13CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D13CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D14CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D14CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D15CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D15CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D16CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D16CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D17CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D17CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D18CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D18CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D19CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D19CC { get; set; }

	[Display(Name = "Cupos Otorgados")]
	public virtual int D20CO { get; set; }

	[Display(Name = "Cupos Cumplido")]
	public virtual int D20CC { get; set; }

	public virtual string HOY { get; set; }

	public virtual string DIA1 { get; set; }

	public virtual string DIA2 { get; set; }

	public virtual string DIA3 { get; set; }

	public virtual string DIA4 { get; set; }

	public virtual string DIA5 { get; set; }

	public virtual string DIA6 { get; set; }

	public virtual string DIA7 { get; set; }

	public virtual string DIA8 { get; set; }

	public virtual string DIA9 { get; set; }

	public virtual string DIA10 { get; set; }

	public virtual string DIA11 { get; set; }

	public virtual string DIA12 { get; set; }

	public virtual string DIA13 { get; set; }

	public virtual string DIA14 { get; set; }

	public virtual string DIA15 { get; set; }

	public virtual string DIA16 { get; set; }

	public virtual string DIA17 { get; set; }

	public virtual string DIA18 { get; set; }

	public virtual string DIA19 { get; set; }

	public virtual string DIA20 { get; set; }

	[Display(Name = "Solicitante")]
	public virtual string CUITSOLICITANTE { get; set; }

	[Display(Name = "Nombre")]
	public virtual string NOMSOLICITANTE { get; set; }

	[Display(Name = "Intermediario")]
	public virtual string CUITINTERMEDIARIO { get; set; }

	[Display(Name = "Nombre")]
	public virtual string NOMINTERMEDIARIO { get; set; }

	[Display(Name = "Comercial")]
	public virtual string CUITRTECOMERCIAL { get; set; }

	[Display(Name = "Nombre")]
	public virtual string NOMRTECOMERCIAL { get; set; }

	[Display(Name = "Corredor Comprador")]
	public virtual string CUITCORRCOMP { get; set; }

	[Display(Name = "Nombre")]
	public virtual string NOMCORRCOMP { get; set; }

	[Display(Name = "Mercado a Termino")]
	public virtual string CUITMAT { get; set; }

	[Display(Name = "Nombre")]
	public virtual string NOMMAT { get; set; }

	[Display(Name = "Corredor Vendedor")]
	public virtual string CUITCORRVTA { get; set; }

	[Display(Name = "Nombre")]
	public virtual string NOMCORRVTA { get; set; }

	[Display(Name = "Entregador")]
	public virtual string CUITRTEENT { get; set; }

	[Display(Name = "Nombre")]
	public virtual string NOMRTEENT { get; set; }

	[Display(Name = "Destinatario")]
	public virtual string CUITDESTINATARIO { get; set; }

	[Display(Name = "Nombre")]
	public virtual string NOMDESTINATARIO { get; set; }

	public int CYO { get; set; }

	public bool EsCYO()
	{
		return CYO == 1;
	}

	public override bool Equals(object obj)
	{
		CuposAgrupadosPorVendedor cuposAgrupadosPorVendedor = (CuposAgrupadosPorVendedor)obj;
		if (object.ReferenceEquals(cuposAgrupadosPorVendedor, null))
		{
			return false;
		}
		if (object.ReferenceEquals(cuposAgrupadosPorVendedor, this))
		{
			return true;
		}
		if (GRANO == cuposAgrupadosPorVendedor.GRANO && COMPCTA == cuposAgrupadosPorVendedor.COMPCTA && PUERTOCTA == cuposAgrupadosPorVendedor.PUERTOCTA && VENDCTA == cuposAgrupadosPorVendedor.VENDCTA && INFORMADOSTOP == cuposAgrupadosPorVendedor.INFORMADOSTOP)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public IList<ResumenDia> GetDias()
	{
		List<ResumenDia> list = new List<ResumenDia>();
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D0CC,
			TurnosOtorgados = D0CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D1CC,
			TurnosOtorgados = D1CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D2CC,
			TurnosOtorgados = D2CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D3CC,
			TurnosOtorgados = D3CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D4CC,
			TurnosOtorgados = D4CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D5CC,
			TurnosOtorgados = D5CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D6CC,
			TurnosOtorgados = D6CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D7CC,
			TurnosOtorgados = D7CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D8CC,
			TurnosOtorgados = D8CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D9CC,
			TurnosOtorgados = D9CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D10CC,
			TurnosOtorgados = D10CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D11CC,
			TurnosOtorgados = D11CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D12CC,
			TurnosOtorgados = D12CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D13CC,
			TurnosOtorgados = D13CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D14CC,
			TurnosOtorgados = D14CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D15CC,
			TurnosOtorgados = D15CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D16CC,
			TurnosOtorgados = D16CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D17CC,
			TurnosOtorgados = D17CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D18CC,
			TurnosOtorgados = D18CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D19CC,
			TurnosOtorgados = D19CO
		});
		list.Add(new ResumenDia
		{
			TurnosConsumidos = D20CC,
			TurnosOtorgados = D20CO
		});
		return list;
	}

	public Consignacion GetCuitConsignacion()
	{
		Consignacion consignacion = new Consignacion();
		consignacion.Cuitsolicitante = CUITSOLICITANTE;
		consignacion.Cuitintermediario = CUITINTERMEDIARIO;
		consignacion.Cuitrtecomercial = CUITRTECOMERCIAL;
		consignacion.Cuitcorrcomp = CUITCORRCOMP;
		consignacion.Cuitmat = CUITMAT;
		consignacion.Cuitrteent = CUITRTEENT;
		consignacion.Cuitcorrvta = CUITCORRVTA;
		consignacion.Cuitdestinatario = CUITDESTINATARIO;
		return consignacion;
	}
}
}
