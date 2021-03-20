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

            bundles.Add(new ScriptBundle("~/bundles/audio").Include(
                       "~/Scripts/js/audio.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/email").Include(
                     "~/Scripts/js/email.js"));

            bundles.Add(new ScriptBundle("~/bundles/myapp").Include(
                     "~/Scripts/js/my-app.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryfit").Include(
                       "~/Scripts/js/jquery.fitvids.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerysw").Include(
                       "~/Scripts/js/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/js/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerycus").Include(
                       "~/Scripts/js/jquery.custom.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/simple").Include(
                       "~/Scripts/js/simple-lightbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/swiper").Include(
                       "~/Scripts/js/swiper.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/style.css",
                      "~/Content/css/reset.css",
                      "~/Content/css/swiper.css",
                      "~/Content/css/simplelightbox.css"));
        }
    }
}
