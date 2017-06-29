using System.Web;
using System.Web.Optimization;

namespace AOS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/lib/jquery/dist/jquery*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/lib/jquery.validation/dist/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/lib/bootstrap/dist/js/bootstrap.js"));
            //,
            //          "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
          "~/lib/angular/angular.min.js"));
            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                        "~/Scripts/Scripts.js"));

            bundles.Add(new StyleBundle("~/css/styles").Include(
                      "~/css/styles.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/muijs").Include(
                        "~/lib/mui/packages/cdn/js/mui.js"));
            bundles.Add(new StyleBundle("~/bundles/muicss").Include(
                        "~/lib/mui/packages/cdn/css/mui.css"));

        }
    }
}
