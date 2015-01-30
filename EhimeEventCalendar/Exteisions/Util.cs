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
            if (html == null) return null;

            var buf = html;
            buf = IgnoreTag(buf, "script");
            buf = IgnoreTag(buf, "iframe");

            return buf;
        }

        private static string IgnoreTag(string src, string tag)
        {
            var buf = Regex.Replace(src, string.Format("<(?<tag>/*{0})(?<opt>[^>]*)>", tag), "&lt;${tag}${opt}&gt;", RegexOptions.IgnoreCase);
            return buf;
        }
    }
}