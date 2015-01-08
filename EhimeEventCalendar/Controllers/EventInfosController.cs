using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EhimeEventCalendar.Exteisions;
using EhimeEventCalendar.Models;
using EhimeEventCalendar.ViewModels;

namespace EhimeEventCalendar.Controllers
{
    public class EventInfosController : Controller
    {
        private AppDbContext db = new AppDbContext();

        [Route("EventInfos/Calendar/{year}/{month}", Name = "CalendarRoute")]
        public ActionResult Calendar(int year, int month)
        {
            var start = new DateTime(year, month, 1, 0, 0, 0);
            var model = new HomeIndexViewModel()
            {
                Year = year,
                Month = month,
                Days = start.AddMonths(1).AddDays(-1).Day,
                PrevMonth = start.AddMonths(-1),
                NextMonth = start.AddMonths(1),
            };
            var end = start.AddMonths(1);
            model.EventInfos = db.EventInfos.Where(x => x.StartTime >= start && x.StartTime < end).ToList();

            return View("../Home/Index", model);
        }

        // GET: EventInfos
        public async Task<ActionResult> Index()
        {
            return View(await db.EventInfos.ToListAsync());
        }

        // GET: EventInfos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventInfo = await db.EventInfos.FindAsync(id);
            if (eventInfo == null)
            {
                return HttpNotFound();
            }
            return View(eventInfo);
        }

        // GET: EventInfos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventInfos/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Url,TimeStamp")] EventInfo eventInfo,
            [ModelBinder(typeof(DateTimeBinder))]DateTime startTime,
            [ModelBinder(typeof(DateTimeBinder))]DateTime endTime
            )
        {
            if (ModelState.IsValid)
            {
                eventInfo.StartTime = startTime;
                eventInfo.EndTime = endTime;

                db.EventInfos.Add(eventInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eventInfo);
        }

        // GET: EventInfos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventInfo = await db.EventInfos.FindAsync(id);
            if (eventInfo == null)
            {
                return HttpNotFound();
            }
            return View(eventInfo);
        }

        // POST: EventInfos/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Url,TimeStamp")] EventInfo eventInfo,
            [ModelBinder(typeof(DateTimeBinder))]DateTime startTime,
            [ModelBinder(typeof(DateTimeBinder))]DateTime endTime
            )
        {
            if (ModelState.IsValid)
            {
                eventInfo.StartTime = startTime;
                eventInfo.EndTime = endTime;

                db.Entry(eventInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eventInfo);
        }

        // GET: EventInfos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInfo eventInfo = await db.EventInfos.FindAsync(id);
            if (eventInfo == null)
            {
                return HttpNotFound();
            }
            return View(eventInfo);
        }

        // POST: EventInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EventInfo eventInfo = await db.EventInfos.FindAsync(id);
            db.EventInfos.Remove(eventInfo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
