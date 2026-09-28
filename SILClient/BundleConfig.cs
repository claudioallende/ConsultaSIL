using System.Web.Optimization;

namespace SILClient;

public class BundleConfig
{
	public static void RegisterBundles(BundleCollection bundles)
	{
		bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
		bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
		bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
		bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));
		bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));
		bundles.Add(new ScriptBundle("~/bundles/datatables_columnfixed").Include("~/Scripts/datatables.min.js"));
		bundles.Add(new StyleBundle("~/Content/datatables_columnfixed").Include("~/Content/datatables.min.css"));
		bundles.Add(new ScriptBundle("~/bundles/datepicker").Include("~/Scripts/jquery-ui-datepicker.min.js"));
		bundles.Add(new StyleBundle("~/Content/datepicker").Include("~/Content/jquery-ui-datepicker.min.css"));
		bundles.Add(new StyleBundle("~/Content/spinner").Include("~/Content/loading.css", "~/Content/loading-btn.css"));
		bundles.Add(new ScriptBundle("~/bundles/spinner").Include("~/Scripts/Spinner.js"));
	}
}
