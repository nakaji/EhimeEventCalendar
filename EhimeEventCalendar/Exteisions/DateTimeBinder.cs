using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EhimeEventCalendar.Exteisions
{
    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = default(DateTime);

            try
            {
                var date = Util.GetValue(bindingContext, "Date");
                var hour = Util.GetValue(bindingContext, "Hour");
                var minute = Util.GetValue(bindingContext, "Minute");
                result = DateTime.Parse(string.Format("{0} {1}:{2}", date, hour, minute));
            }
            catch { }

            return result;
        }
    }
}