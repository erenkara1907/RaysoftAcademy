using System.Web;
using System.Web.Optimization;

namespace MVC
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

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                     "~/Scripts/js/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Scripts/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/imagesloaded").Include(
                       "~/Scripts/js/imagesloaded.js"));

            bundles.Add(new ScriptBundle("~/bundles/isotope").Include(
                       "~/Scripts/js/isotope.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.tab-accordion").Include(
                       "~/Scripts/js/jquery.tab-accordion.js"));

            bundles.Add(new ScriptBundle("~/bundles/parallax").Include(
                       "~/Scripts/js/parallax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/smooth.scroll").Include(
                       "~/Scripts/js/smooth.scroll.min.js"));



            bundles.Add(new ScriptBundle("~/bundles/"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/style.css",
                      "~/Content/css/content-box.css",
                      "~/Content/css/image-box.css",
                      "~/Content/css/animations.css",
                      "~/Content/css/components.css",
                       "~/Content/css/skin.css",
                        "~/Content/css/font-awesome.css",
                         "~/Content/css/bootstrap-theme.css",
                          "~/Content/css/bootstrap-theme-min.css",
                           "~/Content/css/bootstrap.css",
                         "~/Content/css/Site.css"




                      ));
        }
    }
}
