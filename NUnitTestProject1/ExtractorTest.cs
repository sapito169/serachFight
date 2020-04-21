using NUnit.Framework;
using searchFight;

namespace NUnitTestProject1
{
    public class ExtractorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void prueba_con_comas()
        {
            Extractor extractor =new Extractor();
            var result =extractor.extract("<html><span id=\"abc\">1000</span></html>", "<span id=\"abc\">", "</span>");
            Assert.AreEqual("1000", result);

        }


    }
}