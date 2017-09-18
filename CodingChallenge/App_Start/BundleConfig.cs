using System.Web;
using System.Web.Optimization;

namespace CodingChallenge
{ 
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/bundles/js").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/content/bundles/css/bootstrap").Include(
                        "~/content/css/bootstrap/bootstrap.css"));
        }
    }
}