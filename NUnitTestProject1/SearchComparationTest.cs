using NUnit.Framework;
using searchFight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
namespace NUnitTestProject1
{
    public class SearchComparationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SearchComparation_with_one_search_engine()
        {
           

            var mock = new Mock<HttpRequester>();

            mock.Setup(m => m.request("https://www.bing.com/search?q=.net")).Returns("<html><body><span id=\"search\">1000</span class=\"important\"></body></html>");
            

            List<SearhEngineSource> searhEngineSources = new List<SearhEngineSource>();
        
            searhEngineSources.Add(new SearhEngineSource("<span id=\"search\">", "</span class=\"important\">", "https://www.bing.com/search?q=","msm"));

            SearchComparation searchComparation = new SearchComparation(mock.Object, new Extractor(),".net", searhEngineSources);
            List<SearchComparatorResult> list = searchComparation.obteinResults();
            SearchComparatorResult searchComparatorResult = list[0];
 
            Assert.AreEqual("1000", searchComparatorResult.result);
            Assert.AreEqual(".net", searchComparatorResult.competitor);
            Assert.AreEqual("msm", searchComparatorResult.searhEngineSource.smallName);
        }

         [Test]
        public void SearchComparation_with_many_search_engine()
        {


            Mock<HttpRequester> requester = new Mock<HttpRequester>();
            requester.Setup(m => m.request("https://www.bing.com/search?q=.net")).Returns("<html><body><span id=\"search\">1000</span class=\"important\"></body></html>");
            requester.Setup(m => m.request("https://www.google.com/search?q=.net")).Returns("<html><body><span id=\"search-go\">2000</span class=\"important\"></body></html>");



            List<SearhEngineSource> searhEngineSources = new List<SearhEngineSource>();

            searhEngineSources.Add(new SearhEngineSource("<span id=\"search-go\">", "</span class=\"important\">", "https://www.google.com/search?q=", "Google"));
            searhEngineSources.Add(new SearhEngineSource("<span id=\"search\">", "</span class=\"important\">", "https://www.bing.com/search?q=", "MSN"));
 
            SearchComparation searchComparation = new SearchComparation(requester.Object, new Extractor(), ".net", searhEngineSources);
             
            List<SearchComparatorResult> list = searchComparation.obteinResults();

            SearchComparatorResult firstComparationResult = list[0];
            SearchComparatorResult secondComparationResult = list[1];


            Assert.AreEqual("2000", firstComparationResult.result, "google count");
            Assert.AreEqual(".net", firstComparationResult.competitor, "google competitor");
            Assert.AreEqual("Google", firstComparationResult.searhEngineSource.smallName, "google name");

            Assert.AreEqual("1000", secondComparationResult.result,"bing count");
            Assert.AreEqual(".net", secondComparationResult.competitor, "bing competitor");
            Assert.AreEqual("MSN", secondComparationResult.searhEngineSource.smallName, "bing name");

             
            Assert.AreEqual(2000, searchComparation.max(), "maximun");
            Assert.AreEqual(".net: Google: 2000 MSN: 1000", searchComparation.parseToString(), "parse string"); 

            Assert.AreEqual(2, list.Count,"count");
        } 
    }
}