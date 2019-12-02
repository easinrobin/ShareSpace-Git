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

            bundles.Add(new StyleBundle("~/Content/dropzone").Include(
                      "~/Content/dropzone.css"));
            bundles.Add(new StyleBundle("~/Content/validation").Include(
                "~/Content/validation.css"));


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




            bundles.Add(new ScriptBundle("~/bundles/curvedline").Include(
                        "~/Scripts/demo/js/flot-charts/curved-line.js"));


            bundles.Add(new ScriptBundle("~/bundles/line").Include(
                        "~/Scripts/demo/js/flot-charts/line.js"));

            bundles.Add(new ScriptBundle("~/bundles/charttooltips").Include(
                        "~/Scripts/demo/js/flot-charts/chart-tooltips.js"));

            bundles.Add(new ScriptBundle("~/bundles/othercharts").Include(
                        "~/Scripts/demo/js/other-charts.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqvmap").Include(
                        "~/Scripts/demo/js/jqvmap.js"));



               


            bundles.Add(new ScriptBundle("~/bundles/salvattoremin").Include(
                        "~/Scripts/salvattore.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryflot").Include(
                        "~/Scripts/jquery.flot.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryflotresize").Include(
                        "~/Scripts/jquery.flot.resize.js"));

            bundles.Add(new ScriptBundle("~/bundles/curvedLines").Include(
                        "~/Scripts/curvedLines.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvmapmin").Include(
                        "~/Scripts/jquery.vmap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvmapworld").Include(
                        "~/Scripts/jquery.vmap.world.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryeasypiechartmin").Include(
                        "~/Scripts/jquery.easypiechart.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerypeitymin").Include(
                        "~/Scripts/jquery.peity.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/momentmin").Include(
                        "~/Scripts/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendarmin").Include(
                        "~/Scripts/fullcalendar.min.js"));




            bundles.Add(new ScriptBundle("~/bundles/lightgalleryall").Include(
                        "~/Scripts/lightgallery-all.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dropzone").Include(
                       "~/Scripts/dropzone.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/autosizemin").Include(
                       "~/Scripts/autosize.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
                "~/Scripts/validation.js"));




            bundles.Add(new ScriptBundle("~/bundles/appmin").Include(
                       "~/Scripts/app.min.js"));

        }
    }
}
