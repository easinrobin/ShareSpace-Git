using System.Web;
using System.Web.Optimization;

namespace AdminPanel
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.8.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/appmin").Include(
                        "~/Scripts/app.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymin").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/poppermin").Include(
                        "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapminjs").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle(("~/bundles/jqueryscrollbarmin")).Include(
                       ("~/Scripts/jquery.scrollbar.min.js")));

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



            // Style Bundles
            bundles.Add(new StyleBundle("~/Content/booststrap").Include(
          "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/appmin").Include(
                      "~/Content/app.min.css"));
            bundles.Add(new StyleBundle("~/Content/materialdesign").Include(
                      "~/fonts/dist/css/material-design-iconic-font.min.css"));

            bundles.Add(new StyleBundle("~/Content/animatemin").Include(
                      "~/Content/animate.min.css"));

            bundles.Add(new StyleBundle("~/fonts/fontAwesome").Include(
                        "~/fonts/material-design-iconic-font/dist/css/material-design-iconic-font.min.css"));



        }
    }
}
