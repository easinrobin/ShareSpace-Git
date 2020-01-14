using System.Web.Optimization;

namespace AdminPanel
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/ThirdPartyJs/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/ThirdPartyJs/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/ThirdPartyJs/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.validate.unobtrusive").Include(
                        "~/Scripts/ThirdPartyJs/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/poppermin").Include(
                        "~/Scripts/ThirdPartyJs/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapmin").Include(
                        "~/Scripts/ThirdPartyJs/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryscrollbarmin").Include(
                        "~/Scripts/ThirdPartyJs/jquery.scrollbar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryscrollLockmin").Include(
                        "~/Scripts/ThirdPartyJs/jquery-scrollLock.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerydataTablesmin").Include(
                        "~/Scripts/ThirdPartyJs/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTablesbuttonsmin").Include(
                        "~/Scripts/ThirdPartyJs/dataTables.buttons.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/buttonsprintmin").Include(
                        "~/Scripts/ThirdPartyJs/buttons.print.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jszipmin").Include(
                        "~/Scripts/ThirdPartyJs/jszip.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/buttonshtml5min").Include(
                        "~/Scripts/ThirdPartyJs/buttons.html5.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/appmin").Include(
                        "~/Scripts/CustomJs/app.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetAlert2").Include(
                        "~/Scripts/ThirdPartyJs/sweetalert2.min.js"));

            //new

            bundles.Add(new ScriptBundle("~/bundles/curvedline").Include(
                        "~/Scripts/ThirdPartyJs/curvedLines.js"));

            bundles.Add(new ScriptBundle("~/bundles/autosize").Include(
                "~/Scripts/ThirdPartyJs/autosize.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dropzone").Include(
                "~/Scripts/ThirdPartyJs/dropzone.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/momentJs").Include(
                "~/Scripts/ThirdPartyJs/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/flatpickr").Include(
                "~/Scripts/ThirdPartyJs/flatpickr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                "~/Scripts/ThirdPartyJs/fullcalendar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/easypiechart").Include(
                "~/Scripts/ThirdPartyJs/jquery.easypiechart.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/flot").Include(
                "~/Scripts/ThirdPartyJs/jquery.flot.js"));

            bundles.Add(new ScriptBundle("~/bundles/flotResize").Include(
                "~/Scripts/ThirdPartyJs/jquery.flot.resize.js"));

            bundles.Add(new ScriptBundle("~/bundles/peity").Include(
                "~/Scripts/ThirdPartyJs/jquery.peity.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/lightgallery").Include(
                "~/Scripts/ThirdPartyJs/lightgallery-all.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/salvattore").Include(
                "~/Scripts/ThirdPartyJs/salvattore.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/select").Include(
                "~/Scripts/ThirdPartyJs/bootstrap-select.min.js"));

            
            //rich text
            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-1").Include(
                "~/Scripts/rich-textJs/trumbowyg.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-2").Include(
                "~/Scripts/rich-textJs/trumbowyg.min.js"));

            

            #endregion





            #region StyleSheets

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/ThirdPartyCss/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
                "~/Content/ThirdPartyCss/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/app-min").Include(
                "~/Content/CustomCss/app.min.css"));

            bundles.Add(new StyleBundle("~/Content/animate-min").Include(
                "~/Content/ThirdPartyCss/animate.min.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-scrollbar").Include(
                "~/Content/ThirdPartyCss/jquery.scrollbar.css"));

            bundles.Add(new StyleBundle("~/Content/material-font").Include(
                "~/Content/material-design-iconic-font/dist/css/material-design-iconic-font.min.css"));

            bundles.Add(new StyleBundle("~/Content/demo-css").Include(
                "~/Content/CustomCss/demo.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-1").Include(
                "~/Content/rich-text/trumbowyg.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-2").Include(
                "~/Content/rich-text/trumbowyg.min.css"));



            //new
            bundles.Add(new StyleBundle("~/Content/dropzone").Include(
                "~/Content/ThirdPartyCss/dropzone.css"));

            bundles.Add(new StyleBundle("~/Content/fullcalendar").Include(
                "~/Content/ThirdPartyCss/fullcalendar.min.css"));

            bundles.Add(new StyleBundle("~/Content/select").Include(
                        "~/Content/ThirdPartyCss/bootstrap-select.min.css"));

            bundles.Add(new StyleBundle("~/Content/sweetAlert2").Include(
                        "~/Content/ThirdPartyCss/sweetalert2.min.css"));

            bundles.Add(new StyleBundle("~/fonts/flatIcon").Include(
                "~/fonts/flaticon/font/flaticon.css"));

            bundles.Add(new StyleBundle("~/Content/flatpickr").Include(
                "~/Content/ThirdPartyCss/flatpickr.min.css"));

            #endregion
        }
    }
}
