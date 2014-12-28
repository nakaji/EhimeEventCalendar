using System;
using System.Linq;
using EhimeEventCalendar.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EhimeEventCalendar.Tests.Models
{
    [TestClass]
    public class AppDbContextTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new AppDbContext();
            db.EventInfos.Add(new EventInfo()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
            });
            db.SaveChanges();

            Assert.AreEqual(1, db.EventInfos.Count());
        }
    }
}
