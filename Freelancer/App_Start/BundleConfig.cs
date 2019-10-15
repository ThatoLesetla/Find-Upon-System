using System.Web;
using System.Web.Optimization;

namespace Freelancer
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

      
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Content/Freelancer/js").Include(
                        "~/Content/Freelancer/vendor/jquery-3.2.1.min.js",
                        "~/Content/Freelancer/vendor/bootstrap-4.1/popper.min.js",
                        "~/Content/Freelancer/vendor/bootstrap-4.1/bootstrap.min.js",
                        "~/Content/Freelancer/vendor/slick/slick.min.js",
                        "~/Content/Freelancer/vendor/wow/wow.min.js",
                        "~/Content/Freelancer/vendor/animsition/animsition.min.js",
                        "~/Content/Freelancer/vendor/bootstrap-progressbar/bootstrap-progressbar.min.js",
                        "~/Content/Freelancer/vendor/counter-up/jquery.waypoints.min.js",
                        "~/Content/Freelancer/vendor/counter-up/jquery.counterup.min.js",
                        "~/Content/Freelancer/vendor/circle-progress/circle-progress.min.js",
                        "~/Content/Freelancer/vendor/perfect-scrollbar/perfect-scrollbar.js",
                        "~/Content/Freelancer/vendor/chartjs/Chart.bundle.min.js",
                        "~/Content/Freelancer/vendor/select2/select2.min.js",
                        "~/Content/Freelancer/js/main.js",
                        "~/Scripts/main.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Customer/css/jquery.uls.css",
                      "~/Content/Customer/css/jquery.uls.grid.css",
                      "~/Content/Customer/css/jquery.uls.lcd.css",
                      "~/Content/Customer/css/bootstrap.min.css",
                      "~/Content/Customer/css/bootstrap-select.css",
                      "~/Content/Customer/css/style.css",
                      "~/Content/Customer/css/flexslider.css",
                      "~/Content/Customer/css/font-awesome.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Freelancer/css").Include(
                // Bootstrap CSS
                "~/Content/Freelancer/vendor/bootstrap-4.1/bootstrap.min.css",
                
                // Vendor CSS
                "~/Content/Freelancer/vendor/animsition/animsition.min.css",
                "~/Content/Freelancer/vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css",
                "~/Content/Freelancer/vendor/wow/animate.css",
                "~/Content/Freelancer/vendor/css-hamburgers/hamburgers.min.css",
                "~/Content/Freelancer/vendor/slick/slick.css",
                "~/Content/Freelancer/vendor/select2/select2.min.css",
                "~/Content/Freelancer/vendor/perfect-scrollbar/perfect-scrollbar.css",
                "~/Content/Freelancer/css/theme.css",
                "~/Content/Freelancer/css/font-face.css",
                "~/Content/Freelancer/vendor/font-awesome-4.7/css/font-awesome.min.css",
                "~/Content/Freelancer/vendor/font-awesome-5/css/fontawesome-all.min.css",
                "~/Content/Freelancer/vendor/mdi-font/css/material-design-iconic-font.min.css"
                ));
        }
    }
}
