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
                        "~/Scripts/Third-partyJs/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Third-partyJs/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Third-partyJs/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/Third-partyJs/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/ie").Include(
                        "~/Scripts/Third-partyJs/ie-emulation-modes-warning.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapSubmenu").Include(
                        "~/Scripts/Third-partyJs/bootstrap-submenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/ytPlayer").Include(
                        "~/Scripts/Third-partyJs/jquery.mb.YTPlayer.js"));

            bundles.Add(new ScriptBundle("~/bundles/wowJs").Include(
                        "~/Scripts/Third-partyJs/wow.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapSelect").Include(
                        "~/Scripts/Third-partyJs/bootstrap-select.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/easing").Include(
                        "~/Scripts/Third-partyJs/jquery.easing.1.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollUp").Include(
                        "~/Scripts/Third-partyJs/jquery.scrollUp.js"));

            bundles.Add(new ScriptBundle("~/bundles/customScrollbarContact").Include(
                        "~/Scripts/Third-partyJs/jquery.mCustomScrollbar.concat.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/customScrollbar").Include(
                        "~/Scripts/Third-partyJs/jquery.mCustomScrollbar.js"));

            bundles.Add(new ScriptBundle("~/bundles/rateYo").Include(
                        "~/Scripts/Third-partyJs/jquery.rateyo.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/filterizr").Include(
                        "~/Scripts/Third-partyJs/jquery.filterizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapDate").Include(
                        "~/Scripts/Third-partyJs/bootstrap-datetimepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/tiltJs").Include(
                        "~/Scripts/Third-partyJs/tilt.jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/momentJs").Include(
                        "~/Scripts/Third-partyJs/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/moveitJs").Include(
                        "~/Scripts/Third-partyJs/moveit.js"));

            bundles.Add(new ScriptBundle("~/bundles/customJs").Include(
                        "~/Scripts/CustomJs/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/clientDashboardJs").Include(
                        "~/Scripts/CustomJs/clientDashboard.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/contact-us").Include(
                        "~/Scripts/CustomJs/contact-us.js"));

            bundles.Add(new ScriptBundle("~/bundles/succeedJs").Include(
                        "~/Scripts/CustomJs/succeedJs.js"));

            bundles.Add(new ScriptBundle("~/bundles/booking-validationJs").Include(
                        "~/Scripts/CustomJs/booking-validation.js"));





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
                        "~/Content/CustomCss/style.css"));

            bundles.Add(new StyleBundle("~/Content/defaultCss").Include(
                        "~/Content/CustomCss/default.css"));

            bundles.Add(new StyleBundle("~/Content/loginCss").Include(
                        "~/Content/CustomCss/login.css"));

            bundles.Add(new StyleBundle("~/Content/clientDashboardCss").Include(
                        "~/Content/CustomCss/clientDashboard.min.css"));

            bundles.Add(new StyleBundle("~/Content/contact-us").Include(
                        "~/Content/CustomCss/contact-us.css"));

            bundles.Add(new StyleBundle("~/Content/succeedCss").Include(
                        "~/Content/CustomCss/succeed.css"));

            bundles.Add(new StyleBundle("~/Content/ieBug").Include(
                        "~/Content/ie10-viewport-bug-workaround.css"));
        }
    }
}
