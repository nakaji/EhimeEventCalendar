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
                var date =
                    bindingContext.ValueProvider.GetValue(string.Format("{0}.Date", bindingContext.ModelName))
                        .ConvertTo(typeof(string));
                var hour =
                    bindingContext.ValueProvider.GetValue(string.Format("{0}.Hour", bindingContext.ModelName))
                        .ConvertTo(typeof(string));
                var minute =
                    bindingContext.ValueProvider.GetValue(string.Format("{0}.Minute", bindingContext.ModelName))
                        .ConvertTo(typeof(string));
                result = DateTime.Parse(string.Format("{0} {1}:{2}", date, hour, minute));
            }
            catch { }

            return result;
        }
    }
}