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
                Name = Util.GetValue(bindingContext, "Name"),
                Address = Util.GetValue(bindingContext, "Address"),
                Url = Util.GetValue(bindingContext, "Url")
            };
        }
    }
}
