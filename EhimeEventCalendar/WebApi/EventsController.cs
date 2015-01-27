using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EhimeEventCalendar.Models;
using EhimeEventCalendar.Service;

namespace EhimeEventCalendar.WebApi
{
    public class EventsController : ApiController
    {
        public EventInfo Get(string url)
        {
            var webApi = new Doorkeeper();
            return webApi.GetEvent(url);
        }
    }
}
