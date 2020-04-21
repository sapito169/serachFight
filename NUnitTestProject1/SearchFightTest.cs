using NUnit.Framework;
using searchFight; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace NUnitTestProject1
{
    public class SearchFightTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void prueba_global()
        {

       

            Extractor extractor = new Extractor();
            var mock = new Mock<Action<string>>();
            var requester = new Mock<HttpRequester>();

            requester.Setup(m => m.request("https://www.google.com/search?q=.net")).Returns("<html><body><span id=\"search-go\">1000</span class=\"important\"></body></html>");
            requester.Setup(m => m.request("https://www.bing.com/search?q=.net")).Returns("<html><body><span id=\"search\">2050</span class=\"important\"></body></html>");
            requester.Setup(m => m.request("https://www.google.com/search?q=java")).Returns("<html><body><span id=\"search-go\">2000</span class=\"important\"></body></html>");
            requester.Setup(m => m.request("https://www.bing.com/search?q=java")).Returns("<html><body><span id=\"search\">50</span class=\"important\"></body></html>");

            string mensaje = "";
            Action<string> writer = (m) => { mensaje += m; };
            

             

            SerachFight serachFight = new SerachFight(writer);

            List<SearhEngineSource> searhEngineSources = new List<SearhEngineSource>();

            searhEngineSources.Add(new SearhEngineSource("<span id=\"search-go\">", "</span class=\"important\">", "https://www.google.com/search?q=", "Google"));
            searhEngineSources.Add(new SearhEngineSource("<span id=\"search\">", "</span class=\"important\">", "https://www.bing.com/search?q=", "MSN"));


             

            serachFight.addAndExecute(new SearchComparation(requester.Object, extractor, ".net", searhEngineSources));
            serachFight.addAndExecute(new SearchComparation(requester.Object, extractor, "java", searhEngineSources));
            serachFight.terminateAndWrite();

            var expexted = "";
            expexted += ".net: Google: 1000 MSN: 2050\n";
            expexted += "java: Google: 2000 MSN: 50\n";
            expexted += "Total winner: .net";

             Assert.AreEqual(expexted, mensaje );

        }


    }
}