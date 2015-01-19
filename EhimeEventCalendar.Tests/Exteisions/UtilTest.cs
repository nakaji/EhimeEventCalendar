using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EhimeEventCalendar.Exteisions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Moq;

namespace EhimeEventCalendar.Tests.Exteisions
{
    [TestClass]
    public class UtilTest
    {
        [TestMethod]
        public void GetValue_指定した値が存在する場合はその値を返す()
        {
            var mock = new Mock<IValueProvider>();
            mock.Setup(c => c.GetValue("Venue.Name")).Returns(new ValueProviderResult("会場名", "会場名", null));

            var bindingContext = new ModelBindingContext
            {
                ModelName = "Venue",
                ValueProvider = mock.Object
            };

            Assert.AreEqual("会場名", Util.GetValue(bindingContext, "Name"));
        }

        [TestMethod]
        public void GetValue_指定した値が存在する場合は空文字列を返す()
        {
            var mock = new Mock<IValueProvider>();
            mock.Setup(c => c.GetValue("Venue.Name")).Returns(new ValueProviderResult("会場名", "会場名", null));

            var bindingContext = new ModelBindingContext
            {
                ModelName = "Venue",
                ValueProvider = mock.Object
            };

            Assert.AreEqual("", Util.GetValue(bindingContext, "Address"));
        }
    }
}
