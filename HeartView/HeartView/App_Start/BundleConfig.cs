﻿using System.Web;
using System.Web.Optimization;

namespace HeartView
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


            bundles.Add(new ScriptBundle("~/bundles/doctorScript").Include(
                "~/Scripts/Custom/doctorModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/pacientScript").Include(
                "~/Scripts/Custom/pacientModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/recomandareScript").Include(
                "~/Scripts/Custom/recomandariModule.js"));


            bundles.Add(new ScriptBundle("~/bundles/commonScript").Include(
                "~/Scripts/Custom/commonModule.js",
                "~/Scripts/Custom/ajaxHelper.js"));

        }
    }
}
