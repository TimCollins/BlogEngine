using System.Web.Optimization;

namespace BlogEngine
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/blog.css")
                .Include("~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-1.9.1.js")
                .Include("~/Scripts/bootstrap.js"));
        }
    }
}