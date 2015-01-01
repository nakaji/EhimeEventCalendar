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

            var model = new HomeIndexViewModel()
            {
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                Days = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1).AddMonths(1).AddDays(-1).Day
            };
            model.EventInfos = db.EventInfos.Where(x => x.StartTime >= new DateTime(2015, 1, 1, 0, 0, 0) && x.StartTime <= new DateTime(2015, 2, 1, 0, 0, 0)).ToList();

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