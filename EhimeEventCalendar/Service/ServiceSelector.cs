using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EhimeEventCalendar.Models;

namespace EhimeEventCalendar.Service
{
    public static class ServiceSelector
    {
        public static IService GetService(string url)
        {
            return new Doorkeeper();
        }
    }
}