using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EhimeEventCalendar.Models;
using EhimeEventCalendar.ViewModels;

namespace EhimeEventCalendar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new AppDbContext();
            var start = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            var model = new HomeIndexViewModel()
            {
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                Days = start.AddMonths(1).AddDays(-1).Day,
                PrevMonth = start.AddMonths(-1),
                NextMonth = start.AddMonths(1),
            };
            var end = start.AddMonths(1);
            // 当月のイベント
            model.EventInfos = db.EventInfos.Where(x => x.StartTime >= start && x.StartTime < end)
                .OrderBy(x=>x.StartTime).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}