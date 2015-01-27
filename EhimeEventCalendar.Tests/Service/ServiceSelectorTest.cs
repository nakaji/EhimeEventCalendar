using System;
using EhimeEventCalendar.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EhimeEventCalendar.Tests.Service
{
    [TestClass]
    public class ServiceSelectorTest
    {
        [TestMethod]
        public void Doorkeeper用のインスタンスを取得する()
        {
            var actual = ServiceSelector.GetService("http://agile459.doorkeeper.jp/events/19916");

            Assert.AreEqual(typeof(Doorkeeper), actual.GetType());
        }
    }
}
