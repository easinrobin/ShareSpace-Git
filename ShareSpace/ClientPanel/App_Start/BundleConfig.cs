using System.Web;
using System.Web.Optimization;

namespace ClientPanel
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/ie").Include(
                        "~/Scripts/ie-emulation-modes-warning.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapSubmenu").Include(
                        "~/Scripts/bootstrap-submenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/ytPlayer").Include(
                        "~/Scripts/jquery.mb.YTPlayer.js"));

            bundles.Add(new ScriptBundle("~/bundles/wowJs").Include(
                        "~/Scripts/wow.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapSelect").Include(
                        "~/Scripts/bootstrap-select.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/easing").Include(
                        "~/Scripts/jquery.easing.1.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollUp").Include(
                        "~/Scripts/jquery.scrollUp.js"));

            bundles.Add(new ScriptBundle("~/bundles/customScrollbarContact").Include(
                        "~/Scripts/jquery.mCustomScrollbar.concat.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/customScrollbar").Include(
                        "~/Scripts/jquery.mCustomScrollbar.js"));

            bundles.Add(new ScriptBundle("~/bundles/rateYo").Include(
                        "~/Scripts/jquery.rateyo.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/filterizr").Include(
                        "~/Scripts/jquery.filterizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapDate").Include(
                        "~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/momentJs").Include(
                        "~/Scripts/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/customJs").Include(
                        "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/loginJs").Include(
                        "~/Scripts/login.js"));

            bundles.Add(new ScriptBundle("~/bundles/clientDashboardJs").Include(
                "~/Scripts/clientDashboard.min.js"));





            // Style Bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/animateCss").Include(
                        "~/Content/animate.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapSubmenu").Include(
                        "~/Content/bootstrap-submenu.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapSelect").Include(
                        "~/Content/bootstrap-select.min.css"));

            bundles.Add(new StyleBundle("~/Content/rateYo").Include(
                        "~/Content/jquery.rateyo.min.css"));

            bundles.Add(new StyleBundle("~/fonts/fontAwesome").Include(
                        "~/fonts/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/fonts/flatIcon").Include(
                        "~/fonts/flaticon/font/flaticon.css"));

            bundles.Add(new StyleBundle("~/fonts/linearIcon").Include(
                        "~/fonts/linearicons/style.css"));

            bundles.Add(new StyleBundle("~/Content/jQueryCustomScroll").Include(
                        "~/Content/jquery.mCustomScrollbar.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapDate").Include(
                        "~/Content/bootstrap-datetimepicker.min.css"));

            bundles.Add(new StyleBundle("~/Content/customCss").Include(
                        "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/defaultCss").Include(
                        "~/Content/default.css"));

            bundles.Add(new StyleBundle("~/Content/loginCss").Include(
                        "~/Content/login.css"));

            bundles.Add(new StyleBundle("~/Content/clientDashboardCss").Include(
                "~/Content/clientDashboard.min.css"));

            bundles.Add(new StyleBundle("~/Content/ieBug").Include(
                        "~/Content/ie10-viewport-bug-workaround.css"));
        }
    }
}
