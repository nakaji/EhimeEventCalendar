using EhimeEventCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EhimeEventCalendar.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<EventInfo> EventInfos { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Days { get; set; }
    }
}