using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace EhimeEventCalendar.Exteisions
{
    public static class Util
    {
        public static string GetValue(ModelBindingContext bindingContext, string key)
        {
            var result = bindingContext.ValueProvider.GetValue(string.Format("{0}.{1}", bindingContext.ModelName, key));
            if (result == null)
            {
                return string.Empty;
            }
            return (string)result.ConvertTo(typeof(string));
        }

        public static string SanitizingHtml(string html)
        {
            if (html==null) return null;

            //todo:後で綺麗にしたい
            var buf = Regex.Replace(html, "<script(?<opt>[^>]*)>", "&lt;script${opt}&gt;");
            buf = Regex.Replace(buf, "</script(?<opt>[^>]*)>", "&lt;/script${opt}&gt;");

            buf = Regex.Replace(buf, "<iframe(?<opt>[^>]*)>", "&lt;iframe${opt}&gt;");
            buf = Regex.Replace(buf, "</iframe(?<opt>[^>]*)>", "&lt;/iframe${opt}&gt;");

            return buf;
        }
    }
}