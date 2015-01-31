using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Codeplex.Data;
using EhimeEventCalendar.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EhimeEventCalendar.Tests.Service
{
    [TestClass]
    public class ATNDTest
    {
        [TestMethod]
        public void GetEvent_URL指定でイベント情報を取得する()
        {
            var sut = new ATND();

            var @event = sut.GetEvent("https://atnd.org/events/61449");

            Assert.AreEqual("【参加費無料】AEDラボ 「ビジネスモデル・キャンバス ワークショップ」", @event.Title);
        }

    }
}
