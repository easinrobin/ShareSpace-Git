using System.Web;
using System.Web.Optimization;

namespace AdminPanel
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Style

            bundles.Add(new StyleBundle("~/Content/material-font").Include(
                      "~/Content/material-design-iconic-font/dist/css/material-design-iconic-font.min.css"));

            bundles.Add(new StyleBundle("~/Content/animate-min").Include(
                      "~/Content/animate.min.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-scrollbar").Include(
                      "~/Content/jquery.scrollbar.css"));

            bundles.Add(new StyleBundle("~/Content/fullcalendar-min").Include(
                      "~/Content/fullcalendar.min.css"));

            bundles.Add(new StyleBundle("~/Content/app-min").Include(
                      "~/Content/app.min.css"));


            //Script



            
            bundles.Add(new ScriptBundle("~/bundles/jquerymin").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/poppermin").Include(
                        "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapmin").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryscrollbarmin").Include(
                        "~/Scripts/jquery.scrollbar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryscrollLockmin").Include(
                        "~/Scripts/jquery-scrollLock.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquerydataTablesmin").Include(
                        "~/Scripts/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTablesbuttonsmin").Include(
                        "~/Scripts/dataTables.buttons.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/buttonsprintmin").Include(
                        "~/Scripts/buttons.print.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jszipmin").Include(
                        "~/Scripts/jszip.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/buttonshtml5min").Include(
                        "~/Scripts/buttons.html5.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/appmin").Include(
                        "~/Scripts/app.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/curvedline").Include(
                        "~/Scripts/demo/js/flot-charts/curved-line.js"));


            bundles.Add(new ScriptBundle("~/bundles/line").Include(
                        "~/Scripts/demo/js/flot-charts/line.js"));

            bundles.Add(new ScriptBundle("~/bundles/charttooltips").Include(
                        "~/Scripts/demo/js/flot-charts/chart-tooltips.js"));

            bundles.Add(new ScriptBundle("~/bundles/other-charts").Include(
                        "~/Scripts/demo/js/other-charts.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqvmap").Include(
                        "~/Scripts/demo/js/jqvmap.js"));




            
        }
    }
}
