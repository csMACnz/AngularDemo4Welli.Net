using System.Web.Optimization;

namespace DemoBlog
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/html5shiv").Include(
                        "~/Scripts/html5shiv.js",
                        "~/Scripts/html5shiv-printshiv.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js",
                      "~/Scripts/angular-resource.js",
                      "~/Scripts/angular-sanitize.js",
                      "~/Scripts/ui-ace.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/App/app.js",
                      "~/Scripts/App/ListCtrl.js",
                      "~/Scripts/App/ViewEntryCtrl.js",
                      "~/Scripts/App/EditEntryCtrl.js",
                      "~/Scripts/App/NewEntryCtrl.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/site.css"));
        }
    }
}
