using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldSayHelloJames_WhenSuppliedWithJames()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                MapsCore.Program.Main(new string[] { "James" });

                var result = sw.ToString().Trim();
                Assert.AreEqual("Hello James!", result);
            }
        }
    }
}
