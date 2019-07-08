using System.Web;
using System.Web.Optimization;

namespace ArenaFifa20.BatchServices.NET
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/default-jquery").Include(
                        "~/Scripts/jquery/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery/jquery.validate.js",
                        "~/Scripts/jquery/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryaux").Include(
                        "~/Scripts/jquery/circle-progress.min.js",
                        "~/Scripts/jquery/circle-progress.min.js",
                        "~/Scripts/jquery/jquery.countdown.min.js",
                        "~/Scripts/jquery/jquery.timelify.js",
                        "~/Scripts/jquery/jquery-data-to.js",
                        "~/Scripts/jquery/circle.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/default-script").Include(
                      "~/Content/bootstrap/js/bootstrap.min.js",
                      "~/Content/bootstrap/js/bootstrap-4-navbar.js",
                      "~/Scripts/custom.js",
                      "~/Scripts/functions-custom.js",
                      "~/Scripts/popper.min.js",
                      "~/Scripts/typeahead.bundle.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/wow.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/gentelella-script").Include(
                      "~/Scripts/dashboard-gentelella/jquery.min.js",
                      "~/Scripts/dashboard-gentelella/bootstrap.min.js",
                      "~/Scripts/dashboard-gentelella/custom.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/gentelella-form-script").Include(
                      "~/Scripts/functions-registrations.js",
                      "~/Scripts/dashboard-gentelella/parsley.min.js",
                      "~/Scripts/dashboard-gentelella/i18n/fr.js",
                      "~/Scripts/dashboard-gentelella/i18n/it.js",
                      "~/Scripts/dashboard-gentelella/fastclick.js",
                      "~/Scripts/dashboard-gentelella/nprogress.js",
                      "~/Scripts/dashboard-gentelella/jquery.inputmask.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/gentelella-datatable-script").Include(
                      "~/Scripts/dashboard-gentelella/jquery.dataTables.min.js",
                      "~/Scripts/dashboard-gentelella/dataTables.bootstrap.min.js",
                      "~/Scripts/dashboard-gentelella/dataTables.responsive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/carousel-portfolio-script").Include(
                      "~/Content/owlcarousel/owl.carousel.min.js",
                      "~/Content/portfolio-filter-gallery/jquery.isotope.min.js",
                      "~/Content/portfolio-filter-gallery/portfolio-filter-gallery.js",
                      "~/Content/fancybox-master/jquery.fancybox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/gentelella-editor-script").Include(
                      "~/Scripts/dashboard-gentelella/bootstrap-wysiwyg.min.js",
                      "~/Scripts/dashboard-gentelella/jquery.hotkeys.js",
                      "~/Scripts/dashboard-gentelella/prettify.js",
                      "~/Scripts/dashboard-gentelella/jquery.tagsinput.js",
                      "~/Scripts/dashboard-gentelella/switchery.min.js"));

            bundles.Add(new StyleBundle("~/Content/default-css").Include(
                      "~/Content/fontawesome/css/fontawesome-all.min.css",
                      "~/Content/arena20-icons.css",
                      "~/Content/custom.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/custom-responsive.css"));

            bundles.Add(new StyleBundle("~/Content/main-css").Include(
                      "~/Content/animate.min.css",
                      "~/Content/bootstrap/css/bootstrap.min.css",
                      "~/Content/bootstrap/css/bootstrap-4-navbar.css",
                      "~/Content/portfolio-filter-gallery/portfolio-filter-gallery.css",
                      "~/Content/fancybox-master/jquery.fancybox.min.css",
                      "~/Content/range-slider/range-slider.css",
                      "~/Content/owlcarousel/owl.carousel.min.css",
                      "~/Content/owlcarousel/owl.theme.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/gentelella-css").Include(
                      "~/Content/dashboard-gentelella/bootstrap.min-website.css",
                      "~/Content/bootstrap/css/bootstrap-4-navbar.css",
                      "~/Content/dashboard-gentelella/bootstrap.min.css",
                      "~/Content/dashboard-gentelella/font-awesome.min.css",
                      "~/Content/dashboard-gentelella/custom.min.css",
                      "~/Content/fontawesome/css/fontawesome-all.min.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/arena20-icons.css",
                      "~/Content/custom.css",
                      "~/Content/custom-responsive.css",
                      "~/Content/portfolio-filter-gallery/portfolio-filter-gallery.css"));

            bundles.Add(new StyleBundle("~/Content/gentelella-datatable-css").Include(
                      "~/Content/dashboard-gentelella/dataTables.bootstrap.min.css",
                      "~/Content/dashboard-gentelella/buttons.bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/alertifyjs-css").Include(
                      "~/Content/alertifyjs/alertify.min.css",
                      "~/Content/alertifyjs/themes/default.min.css",
                      "~/Scripts/alertify.min.js"
                      ));
        }
    }
}
