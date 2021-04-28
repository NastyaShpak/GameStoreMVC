using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace GameStore.Client.App_Start
{ 
  public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                     "~/Content/style.css", "~/Content/my_style.css"));

            bundles.Add(new StyleBundle("~/Content/login-register").Include(
                     "~/Content/style.css", "~/Content/login-register.css"));

            bundles.Add(new ScriptBundle("~/Script/custom-script").Include(
                        "~/Scripts/custom-script.js"));

            bundles.Add(new ScriptBundle("~/Script/jquery").Include(
                        "~/Scripts/jquery-3.0.0.min.js"));

            bundles.Add(new ScriptBundle("~/Script/popper").Include(
                       "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/Script/bootstrap-min").Include(
                       "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Script/dashboard-ecommerce").Include(
                       "~/Scripts/dashboard-ecommerce.js"));

            bundles.Add(new ScriptBundle("~/Script/main-js").Include(
                      "~/Scripts/main-js.js"));

            bundles.Add(new ScriptBundle("~/Script/image-option").Include(
                      "~/Scripts/image-option.js"));
        }
    }
}