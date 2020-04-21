using NUnit.Framework;
using searchFight;
 
namespace NUnitTestProject1
{
    public class ValidadorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void prueba_con_comas()
        {


            Assert.AreEqual("1000000", Validador.limpia("1000,000"));
        }

        [Test]
        public void prueba_con_espacios()
        {


            Assert.AreEqual("1000000", Validador.limpia("     1000,000       "));
        }

        [Test]
        public void prueba_con_espacios_principio()
        {


            Assert.AreEqual("1000000", Validador.limpia("1000,000       "));
        }
        [Test]
        public void prueba_con_espacios_fin()
        {


            Assert.AreEqual("1000000", Validador.limpia("      1000,000"));
        }

        [Test]
        public void prueba_con_espacios_con_punto()
        {


            Assert.AreEqual("1000000", Validador.limpia("1000.000"));
        }

        [Test]
        public void prueba_con_espacios_con_punto_espacio()
        {


            Assert.AreEqual("1000000", Validador.limpia("1000.000"));
        }


        [Test]
        public void prueba_con_espacios_con_punto_espacio_inicio()
        {


            Assert.AreEqual("1000000", Validador.limpia("    1000.000"));
        }

        [Test]
        public void prueba_con_espacios_con_punto_espacio_fin()
        {


            Assert.AreEqual("1000000", Validador.limpia("    1000.000"));
        }
    }
}