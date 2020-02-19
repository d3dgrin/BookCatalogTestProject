﻿using System.Web;
using System.Web.Optimization;

namespace BookCatalogTestProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bookcatalog").Include(
                        "~/Scripts/polyfill.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/knockout.mapping-latest.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                      "~/Scripts/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/book").Include(
                      "~/Scripts/Book/Model/*.js",
                      "~/Scripts/Book/*.js",
                      "~/Scripts/Author/Model/AuthorModel.js"));

            bundles.Add(new ScriptBundle("~/bundles/author").Include(
                      "~/Scripts/Author/Model/*.js",
                      "~/Scripts/Author/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/jquery-ui.structure.css",
                      "~/Content/jquery-ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/DataTables/css/jquery.dataTables.css"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                      "~/Scripts/Home/Model/*.js",
                      "~/Scripts/Home/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins/datatables").Include(
                "~/Scripts/Plugins/Datatables/datatable.js",
                "~/Scripts/Plugins/Datatables/datatables.min.js",
                "~/Scripts/Plugins/Datatables/datatables.bootstrap.js"
                ));
        }
    }
}
