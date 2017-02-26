using NUnit.Framework;
using WebMonitoring.PingStore;
using Assert = NUnit.Framework.Assert;

namespace WebMonitory.UTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestHeadersAccessTrue()
        {
            string url = "http://google.com";
            var obj = new HttPingScheduleItem();
            obj.Execute(url);
            Assert.AreEqual(obj.Execute(url).IsAccessible, true);
        }
        [Test]
        public void TestHeadersAccessFalse()
        {
            string url = "qweqweqwe";
            var obj = new HttPingScheduleItem();
            obj.Execute(url);
            Assert.AreNotEqual(obj.Execute(url).IsAccessible, true);
        }
        [Test]
        public void TestPingNegateTrue()
        {
            string url = "http://google.com";
            var obj = new HttPingScheduleItem();
            obj.Execute(url);
            Assert.AreEqual(obj.Execute(url).Latency > 0, true);
        }
        [Test]
        public void TestPingNegateFalse()
        {
            string url = "qweqweqwe";
            var obj = new HttPingScheduleItem();
            obj.Execute(url);
            Assert.AreNotEqual(obj.Execute(url).Latency > 0, true);
        }
        [Test]
        public void TestUrlEquals()
        {
            string url = "http://google.com";
            var obj = new HttPingScheduleItem();
            obj.Execute(url);
            Assert.AreNotEqual(obj.Execute(url).Url, url);
        }
    }
}
