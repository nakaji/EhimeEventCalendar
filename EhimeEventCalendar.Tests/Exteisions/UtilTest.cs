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

        [TestMethod]
        public void SanitizingHtml_入力がnullの場合はnullを返す()
        {
            Assert.IsNull( Util.SanitizingHtml(null));
        }

        [TestMethod]
        public void SanitizingHtml_scriptタグを無効化する()
        {
            Assert.AreEqual("<hr>&lt;script&gt;hoge();&lt;/script&gt;", Util.SanitizingHtml("<hr><script>hoge();</script>"));

            Assert.AreEqual("<hr>&lt;script type=\"javascript\"&gt;hoge();&lt;/script&gt;", Util.SanitizingHtml("<hr><script type=\"javascript\">hoge();</script>"));
        }

        [TestMethod]
        public void SanitizingHtml_iframeタグを無効化する()
        {
            Assert.AreEqual("<hr>&lt;iframe&gt;XXXXX&lt;/iframe&gt;", Util.SanitizingHtml("<hr><iframe>XXXXX</iframe>"));

            Assert.AreEqual("<hr>&lt;iframe src=\"http://example.com/\"&gt;XXXXX&lt;/iframe&gt;", Util.SanitizingHtml("<hr><iframe src=\"http://example.com/\">XXXXX</iframe>"));
        }

        [TestMethod]
        public void SanitizingHtml_タグの大文字小文字を区別しない()
        {
            Assert.AreEqual("<hr>&lt;SCRIPT&gt;hoge();&lt;/SCRIPT&gt;", Util.SanitizingHtml("<hr><SCRIPT>hoge();</SCRIPT>"));

            Assert.AreEqual("<hr>&lt;IFRAME&gt;XXXXX&lt;/IFRAME&gt;", Util.SanitizingHtml("<hr><IFRAME>XXXXX</IFRAME>"));
        }
    }
}
