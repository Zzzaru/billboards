using System.Web.Optimization;

namespace Billboards
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery", "http://yandex.st/jquery/2.1.1/jquery.min.js").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/validate", "http://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.0/jquery.validate.min.js").Include("~/Scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/unobtrusiveValidate", "http://ajax.aspnetcdn.com/ajax/mvc/5.1/jquery.validate.unobtrusive.min.js").Include("~/Scripts/jquery.validate.unobtrusive.js"));
            bundles.Add(new ScriptBundle("~/bundles/validateExt").Include("~/Scripts/jquery.validate.extensions.js", "~/Scripts/messages_ru.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/kendo/kendo.core.js",
                                                                    "~/Scripts/kendo/kendo.calendar.js",
                                                                    "~/Scripts/kendo/kendo.popup.js",
                                                                    "~/Scripts/kendo/kendo.datepicker.js",
                                                                    "~/Scripts/kendo/kendo.timepicker.js",
                                                                    "~/Scripts/kendo/kendo.datetimepicker.js",
                                                                    "~/Scripts/kendo/kendo.culture.ru.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ymapfunc").Include("~/Scripts/ymapfunc.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bootstrap", "http://ajax.aspnetcdn.com/ajax/bootstrap/3.2.0/css/bootstrap.css").Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include("~/Content/kendo/kendo.common.css", "~/Content/kendo/kendo.default.css"));
        }
    }
}