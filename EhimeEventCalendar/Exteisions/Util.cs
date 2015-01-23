using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}