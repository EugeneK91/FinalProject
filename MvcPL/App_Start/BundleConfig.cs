using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MvcPL.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/alertify").Include(
                "~/Scripts/alertify.js-0.3.11/src/alertify.js"));

            bundles.Add(new ScriptBundle("~/bundles/Site").Include(
            "~/Scripts/Site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-{verdion}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jRate").Include(
                "~/Plugins/jRate/dist/jRate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-confirm").Include(
                "~/Scripts/jquery-confirm/dist/jquery-confirm.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/themes/base/jquery-ui.min.css",
                "~/Content/Site.css",
                "~/Content/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Scripts/jquery-confirm/dist/jquery-confirm.min.css",
                "~/Content/bootstrap-theme.css",
                "~/Scripts/alertify.js-0.3.11/themes/alertify.bootstrap.css",
                "~/Scripts/alertify.js-0.3.11/themes/alertify.core.css",
                "~/Scripts/alertify.js-0.3.11/themes/alertify.default.css"));
        }
    }
}