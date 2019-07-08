using System.Web;
using System.Web.Optimization;

namespace HohoTraveltestlagi
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-1.12.1.js"));

            bundles.Add(new StyleBundle("~/Content/cssjqueryui").Include("~/Content/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-2.2.3.min.js",
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //Booking Page
            bundles.Add(new StyleBundle("~/Content/css-userbook").Include(
                      "~/Content/bootstrap.css",
                      "~/Styles/css/bootstrap.min.css",
                      "~/Styles/css/font-awesome.css",
                      "~/Styles/css/style-userbook.css"));

            //Home Page User
            bundles.Add(new StyleBundle("~/Content/css-user").Include(
                      "~/Content/bootstrap.css",
                      "~/Styles/css/bootstrap.min.css",
                      "~/Styles/css/font-awesome.css",
                      "~/Styles/css/style-package.css",
                      "~/Styles/css/style-user.css"));

            //Form Booking
            bundles.Add(new StyleBundle("~/Content/css-form").Include(
                      "~/Content/bootstrap.css",
                      "~/Styles/css/style-form.css"));

            //newest form
            bundles.Add(new StyleBundle("~/Content/css-book").Include(
                                  "~/Content/bootstrap.css",
                                  "~/Styles/css/style-book.css",
                                  "~/Styles/css/jquery-ui.css"));

            //Thank Page
            bundles.Add(new StyleBundle("~/Content/css-thank").Include(
                      "~/Content/bootstrap.css",
                      "~/Styles/css/style-thank.css"));

            //Login
            bundles.Add(new StyleBundle("~/Content/css-login").Include(
                      "~/Content/bootstrap.css",
                      "~/Styles/css/style-login.css"));

            //Dashboard Admin
            bundles.Add(new StyleBundle("~/Content/css-admin").Include(
                      //"~/Content/bootstrap.css",
                      "~/Styles/css/bootstrap.min.css",
                      "~/Styles/css/font-awesome.min.css",
                      "~/Styles/css/style-admin.css"));
        }
    }
}
