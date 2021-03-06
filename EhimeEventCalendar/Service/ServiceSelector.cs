﻿using System;
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
            if (url == null) return null;

            if (url.Contains("doorkeeper.jp"))
            {
                return new Doorkeeper();
            }
            if (url.Contains("atnd.org"))
            {
                return new ATND();
            }
            if (url.Contains("connpass.com"))
            {
                return new Connpass();
            }
            if (url.Contains("zusaar.com"))
            {
                return new Zusaar();
            }
            return null;
        }
    }
}