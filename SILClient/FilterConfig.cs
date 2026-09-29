using System.Web.Mvc;

namespace SILClient
{

public class FilterConfig
{
	public static void RegisterGlobalFilters(GlobalFilterCollection filters)
	{
		filters.Add(new HandleErrorAttribute());
	}
}
}
