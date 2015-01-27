using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EhimeEventCalendar.Service;

namespace EhimeEventCalendar.Tests.Service
{
    [TestClass]
    public class DoorkeeperTest
    {
        [TestMethod]
        public void GetById_イベントID指定でイベント情報を取得する()
        {
            var sut = new Doorkeeper();

            var @event = sut.GetEvent(19916);

            Assert.AreEqual("Agile459 #29 今年をアジャイルプランニング！", @event.Title);
        }

        [TestMethod]
        public void GetById_該当するデータがない場合は空のクラスを返す()
        {
            var sut = new Doorkeeper();

            var @event = sut.GetEvent(0);

            Assert.AreEqual("", @event.Title);
        }
    }
}
