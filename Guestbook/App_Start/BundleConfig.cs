using System.Web.Optimization;

namespace Guestbook
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery", "http://yandex.st/jquery/2.1.1/jquery.min.js").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/validate", "http://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.0/jquery.validate.min.js").Include("~/Scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/unobtrusiveValidate", "http://ajax.aspnetcdn.com/ajax/mvc/5.1/jquery.validate.unobtrusive.min.js").Include("~/Scripts/jquery.validate.unobtrusive.js"));
            bundles.Add(new ScriptBundle("~/bundles/kendo", "http://cdn.kendostatic.com/2014.2.716/js/kendo.web.min.js").Include("~/Scripts/kendo/kendo.web.js"));
            bundles.Add(new ScriptBundle("~/bundles/kendoRu", "http://cdn.kendostatic.com/2014.2.716/js/cultures/kendo.culture.ru.min.js").Include("~/Scripts/kendo/kendo.culture.ru.js"));
            bundles.Add(new ScriptBundle("~/bundles/otherJs").Include("~/Scripts/messages_ru.js", "~/Scripts/kendo/kendo.messages.ru-RU.js", "~/Scripts/guestbook.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap", "http://ajax.aspnetcdn.com/ajax/bootstrap/3.2.0/css/bootstrap.min.css").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/kendoCommon", "http://cdn.kendostatic.com/2014.2.716/styles/kendo.common.min.css").Include("~/Content/kendo/kendo.common.css"));
            bundles.Add(new StyleBundle("~/Content/kendoDefault", "http://cdn.kendostatic.com/2014.2.716/styles/kendo.default.min.css").Include("~/Content/kendo/kendo.default.css"));
            bundles.Add(new StyleBundle("~/Content/otherCss").Include("~/Content/boxSizing.css", "~/Content/kendoOverride.css", "~/Content/recaptchaOverride.css"));
        }
    }
}