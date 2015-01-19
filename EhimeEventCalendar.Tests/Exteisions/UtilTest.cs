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
        private ModelBindingContext _bindingContext;

        [TestInitialize]
        public void SetUp()
        {
            var mock = new Mock<IValueProvider>();
            mock.Setup(c => c.GetValue("Venue.Name")).Returns(new ValueProviderResult("会場名", "会場名", null));

            _bindingContext = new ModelBindingContext
            {
                ModelName = "Venue",
                ValueProvider = mock.Object
            };
        }

        [TestMethod]
        public void GetValue_指定した値が存在する場合はその値を返す()
        {
            Assert.AreEqual("会場名", Util.GetValue(_bindingContext, "Name"));
        }

        [TestMethod]
        public void GetValue_指定した値が存在する場合は空文字列を返す()
        {
            Assert.AreEqual("", Util.GetValue(_bindingContext, "Address"));
        }
    }
}
