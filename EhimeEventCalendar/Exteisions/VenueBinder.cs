using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EhimeEventCalendar.Models;

namespace EhimeEventCalendar.Exteisions
{
    public class VenueBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return new Venue
            {
                Name = GetValue(bindingContext, "Name"),
                Address = GetValue(bindingContext, "Address"),
                Url = GetValue(bindingContext, "Url")
            };
        }

        public string GetValue(ModelBindingContext bindingContext, string key)
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
