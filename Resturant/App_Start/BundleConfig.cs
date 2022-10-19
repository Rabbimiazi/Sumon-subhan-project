using System.Web.Optimization;

namespace Resturant
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                        "~/Scripts/Chatbot.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/open-iconic-bootstrap").Include(
                     "~/feliciano/css/open-iconic-bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/animate-css").Include(
                   "~/feliciano/css/animate.css"));

            bundles.Add(new StyleBundle("~/bundles/carosel").Include(
                  "~/feliciano/css/owl.carousel.min.css"));

            bundles.Add(new StyleBundle("~/bundles/defaulttheme").Include(
                 "~/feliciano/css/owl.theme.default.min.css"));

            bundles.Add(new StyleBundle("~/bundles/magnificpopup").Include(
                "~/feliciano/css/magnific-popup.css"));

            bundles.Add(new StyleBundle("~/bundles/aos").Include(
             "~/feliciano/css/aos.css"));

            bundles.Add(new StyleBundle("~/bundles/ionicons").Include(
            "~/feliciano/css/ionicons.min.css"));

            bundles.Add(new StyleBundle("~/bundles/datepicker").Include(
          "~/feliciano/css/bootstrap-datepicker.css"));

            bundles.Add(new StyleBundle("~/bundles/timepicker").Include(
         "~/feliciano/css/jquery.timepicker.css"));

            bundles.Add(new StyleBundle("~/bundles/flation").Include(
       "~/feliciano/css/flaticon.css"));

            bundles.Add(new StyleBundle("~/bundles/icomon").Include(
     "~/feliciano/css/icomoon.css"));

            bundles.Add(new StyleBundle("~/bundles/style").Include(
    "~/feliciano/css/style.css"));




            bundles.Add(new ScriptBundle("~/bundles/jquery.min.js").Include(
 "~/feliciano/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-migrate-3.0.1.min.js").Include(
   "~/feliciano/js/jquery-migrate-3.0.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper.min.js").Include(
 "~/feliciano/js/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap.min.js").Include(
"~/feliciano/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.easing.1.3.js").Include(
"~/feliciano/js/jquery.easing.1.3.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery.waypoints.min.js").Include(
"~/feliciano/js/jquery.waypoints.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.stellar.min.js").Include(
"~/feliciano/js/jquery.stellar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/owl.carousel.min.js").Include(
"~/feliciano/js/owl.carousel.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery.magnific-popup.min.js").Include(
"~/feliciano/js/jquery.magnific-popup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/aos.js").Include(
"~/feliciano/js/aos.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.animateNumber.min.js").Include(
"~/feliciano/js/jquery.animateNumber.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker.js").Include(
"~/feliciano/js/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.timepicker.min.js").Include(
"~/feliciano/js/jquery.timepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollax.min.js").Include(
"~/feliciano/js/scrollax.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/main.js").Include(
"~/feliciano/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/main.js").Include(
"~/feliciano/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/main.js").Include(
"~/feliciano/js/main.js"));


        }

    }
}

 
