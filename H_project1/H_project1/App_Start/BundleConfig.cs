using System.Web;
using System.Web.Optimization;

namespace H_project1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/BundleAssets").Include(
                         "~/content/assets/Bootstrap/dist/css/bootstrap.css",
                         "~/content/assets/css/main.css",
                         "~/content/assets/css/pro-fitkit2.css",
                         "~/content/assets/css/astonish.css",
                         "~/content/assets/css/style.css",
                         "~/content/assets/css/icomoon.css",
                         "~/content/assets/css/fonts.min.css",
                         "~/content/assets/assets/css/Font-Awesome/font-awesome.css",
                         "~/content/assets/css/style2.css"));
        }

    }
}
