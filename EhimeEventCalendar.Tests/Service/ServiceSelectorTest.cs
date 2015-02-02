using System;
using EhimeEventCalendar.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EhimeEventCalendar.Tests.Service
{
    [TestClass]
    public class ServiceSelectorTest
    {
        [TestMethod]
        public void 該当するサービスがない場合はnullを返す()
        {
            var actual = ServiceSelector.GetService("http://example.com/events/99999");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Doorkeeper用のインスタンスを取得する()
        {
            var actual = ServiceSelector.GetService("http://agile459.doorkeeper.jp/events/19916");

            Assert.AreEqual(typeof(Doorkeeper), actual.GetType());
        }

        [TestMethod]
        public void ATND用のインスタンスを取得する()
        {
            var actual = ServiceSelector.GetService("https://atnd.org/events/48796");

            Assert.AreEqual(typeof(ATND), actual.GetType());
        }
    }
}
