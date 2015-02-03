using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EhimeEventCalendar.Models;
using EhimeEventCalendar.Service;

namespace EhimeEventCalendar.WebApi
{
    public class EventsController : ApiController
    {
        public EventInfo Get(string url)
        {
            var service = ServiceSelector.GetService(url);

            if (service == null) throw new HttpResponseException(HttpStatusCode.BadRequest);

            return service.GetEvent(url);
        }
    }
}
