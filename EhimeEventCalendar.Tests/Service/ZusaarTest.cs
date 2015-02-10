using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EhimeEventCalendar.Service;

namespace EhimeEventCalendar.Tests.Service
{
    [TestClass]
    public class ZusaarTest
    {
        [TestMethod]
        public void GetEvent_URL指定でイベント情報を取得する()
        {
            var sut = new Zusaar();

            var @event = sut.GetEvent("http://www.zusaar.com/event/12877005");

            Assert.AreEqual("プロが教える！初心者のためのカメラ教室～シャッタースピードで世界を変える～", @event.Title);
        }
    }
}
