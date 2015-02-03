using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EhimeEventCalendar.Service;

namespace EhimeEventCalendar.Tests.Service
{
    [TestClass]
    public class ConnpassTest
    {
        [TestMethod]
        public void GetEvent_URL指定でイベント情報を取得する()
        {
            var sut = new Connpass();

            var @event = sut.GetEvent("http://connpass.com/event/6150/");

            Assert.AreEqual("2013.5.25第3回旭館上映会「幸福の黄色いハンカチ」", @event.Title);
        }
    }
}
