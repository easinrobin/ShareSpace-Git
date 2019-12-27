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
                "~/Scripts/rich-textJs/codemirror.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-2").Include(
                "~/Scripts/rich-textJs/xml.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-3").Include(
                "~/Scripts/rich-textJs/froala_editor.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-4").Include(
                "~/Scripts/rich-textJs/align.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-5").Include(
                "~/Scripts/rich-textJs/code_beautifier.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-6").Include(
                "~/Scripts/rich-textJs/code_view.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-7").Include(
                "~/Scripts/rich-textJs/colors.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-8").Include(
                "~/Scripts/rich-textJs/draggable.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-9").Include(
                "~/Scripts/rich-textJs/emoticons.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-10").Include(
                "~/Scripts/rich-textJs/font_size.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-11").Include(
                "~/Scripts/rich-textJs/font_family.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-12").Include(
                "~/Scripts/rich-textJs/image.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-13").Include(
                "~/Scripts/rich-textJs/file.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-14").Include(
                "~/Scripts/rich-textJs/image_manager.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-15").Include(
                "~/Scripts/rich-textJs/line_breaker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-16").Include(
                "~/Scripts/rich-textJs/link.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-17").Include(
                "~/Scripts/rich-textJs/lists.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-18").Include(
                "~/Scripts/rich-textJs/paragraph_format.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-19").Include(
                "~/Scripts/rich-textJs/paragraph_style.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-20").Include(
                "~/Scripts/rich-textJs/paragraph_style.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-21").Include(
                "~/Scripts/rich-textJs/video.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-22").Include(
                "~/Scripts/rich-textJs/table.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-23").Include(
                "~/Scripts/rich-textJs/url.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-24").Include(
                "~/Scripts/rich-textJs/entities.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-25").Include(
                "~/Scripts/rich-textJs/char_counter.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-26").Include(
                "~/Scripts/rich-textJs/inline_style.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-27").Include(
                "~/Scripts/rich-textJs/save.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-28").Include(
                "~/Scripts/rich-textJs/fullscreen.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-29").Include(
                "~/Scripts/rich-textJs/quick_insert.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rich-textJs-30").Include(
                "~/Scripts/rich-textJs/quote.min.js"));

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
                "~/Content/rich-text/froala_editor.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-2").Include(
                "~/Content/rich-text/froala_style.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-3").Include(
                "~/Content/rich-text/code_view.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-4").Include(
                "~/Content/rich-text/colors.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-5").Include(
                "~/Content/rich-text/emoticons.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-6").Include(
                "~/Content/rich-text/image_manager.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-7").Include(
                "~/Content/rich-text/image.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-8").Include(
                "~/Content/rich-text/line_breaker.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-9").Include(
                "~/Content/rich-text/table.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-10").Include(
                "~/Content/rich-text/char_counter.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-11").Include(
                "~/Content/rich-text/video.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-12").Include(
                "~/Content/rich-text/fullscreen.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-13").Include(
                "~/Content/rich-text/quick_insert.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-14").Include(
                "~/Content/rich-text/file.min.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-15").Include(
                "~/Content/rich-text/dark.css"));

            bundles.Add(new StyleBundle("~/Content/rich-text-16").Include(
                "~/Content/rich-text/codemirror.min.css"));


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
