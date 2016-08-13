using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdaptorDemo.Model;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace UnitTest.AdaptorDemo
{
    [TestClass]
    public class AdaptorDemoUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataRenderer dr = new DataRenderer(new StubDBAdapter());
            var writer = new StringWriter();

            dr.Renderer(writer);

            string result = writer.ToString();
            Console.Write(writer.ToString());

            int linecount = result.Count(c => c == '\n');
            Assert.AreEqual(3, linecount);
        }

        [TestMethod]
        public void TestMethod2()
        {
            PatternDataRenderer dr = new PatternDataRenderer();

            List<Pattern> myList= new List<Pattern>
            {
                new Pattern {Id = "Pattern1", Description = "Pattern one description" },
                new Pattern {Id = "Pattern12", Description = "Pattern two description" },
            };
            string result = dr.ListPatterns(myList);

            Console.Write(result.ToString());

            int linecount = result.Count(c => c == '\n');
            Assert.AreEqual(4, linecount);
        }

    }
}
