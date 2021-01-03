using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesarrolloDirigidoPorPruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDirigidoPorPruebas.Tests
{
    [TestClass()]
    public class MetodosTests
    {
        Metodos metodo = new Metodos();

        [TestInitialize]
        public void MetodoInicialice()
        {
        }

        [TestMethod()]
        public void comprobarContrasena2Test()
        {
            Assert.IsTrue(metodo.comprobarContrasena2("Password55_"));
            Assert.IsFalse(metodo.comprobarContrasena2("Short5-"));
            Assert.IsFalse(metodo.comprobarContrasena2("PASSWORD55_"));
            Assert.IsTrue(metodo.comprobarContrasena2("Password214#"));
            Assert.IsFalse(metodo.comprobarContrasena2("password343-"));
            Assert.IsTrue(metodo.comprobarContrasena2("Password1234*"));
            Assert.IsFalse(metodo.comprobarContrasena2("234235435346"));
            Assert.IsFalse(metodo.comprobarContrasena2("PasswordWrong_"));
            Assert.IsTrue(metodo.comprobarContrasena2("Password1234*"));
            Assert.IsFalse(metodo.comprobarContrasena2("Password1234"));
            Assert.IsFalse(metodo.comprobarContrasena2(""));
        }

        [TestMethod()]
        public void comprobarURLTest()
        {
            Assert.IsTrue(metodo.comprobarURL("http://Cosas.org"));
            Assert.IsTrue(metodo.comprobarURL("https://ubuvirtual.ubu.es"));
            Assert.IsFalse(metodo.comprobarURL("Htt://malescrito.com"));
            Assert.IsTrue(metodo.comprobarURL("https://ubuvirtual.ubu.es"));
            Assert.IsTrue(metodo.comprobarURL("https://twitter.com"));
            Assert.IsFalse(metodo.comprobarURL("https://twitter.ar"));
            Assert.IsTrue(metodo.comprobarURL("https://web.whatsapp.com"));
            Assert.IsTrue(metodo.comprobarURL("https://ubuvirtual.ubu.es/course"));
            Assert.IsTrue(metodo.comprobarURL("https://ubuvirtual.ubu.es"));
            Assert.IsFalse(metodo.comprobarURL(""));
        }

        [TestMethod()]
        public void transformaHoraTest()
        {
            Assert.AreEqual(metodo.transformaHora("05:34"), "05:34 AM");
            Assert.AreEqual(metodo.transformaHora("20:45"), "08:45 PM");
            Assert.AreEqual(metodo.transformaHora("15.23"), null);
            Assert.AreEqual(metodo.transformaHora("09:67"), null);
            Assert.AreEqual(metodo.transformaHora("90:11"), null);
            Assert.AreEqual(metodo.transformaHora("04:56:34"), null);
            Assert.AreEqual(metodo.transformaHora("12345"), null);
            Assert.AreEqual(metodo.transformaHora(""), null);
        }

        [TestMethod()]
        public void anosDesdeTest()
        {
            Assert.AreEqual(metodo.anosDesde("05/04/2011"), 10);
            Assert.AreEqual(metodo.anosDesde("07/12/2003"), 18);
            Assert.AreEqual(metodo.anosDesde("05:04:2011"), -1);
            Assert.AreEqual(metodo.anosDesde("05/34/2003"), -1);
            Assert.AreEqual(metodo.anosDesde("56/12/2012"), -1);
            Assert.AreEqual(metodo.anosDesde("31/02/2013"), -1);
            Assert.AreEqual(metodo.anosDesde("12/12/2009/56"), -1);
            Assert.AreEqual(metodo.anosDesde("15/12/9999"), -1);
            Assert.AreEqual(metodo.anosDesde(""), -1);
        }

        [TestMethod()]
        public void anosMesesDiasDesdeTest()
        {
            Dictionary<string, int> diccionario1 = new Dictionary<string, int>();
            diccionario1.Add("Años", 9);
            diccionario1.Add("Meses", 8);
            diccionario1.Add("Dias", 28);
            Dictionary<string, int> diccionario2 = new Dictionary<string, int>();
            diccionario2.Add("Años", 17);
            diccionario2.Add("Meses", 0);
            diccionario2.Add("Dias", 26);

            Assert.IsTrue(metodo.anosMesesDiasDesde("05/04/2011", "02/01/2021").SequenceEqual(diccionario1));
            Assert.IsTrue(metodo.anosMesesDiasDesde("07/12/2003", "02/01/2021").SequenceEqual(diccionario2));
            Assert.AreEqual(metodo.anosMesesDiasDesde("05:04:2011", "02/01/2021"), null);
            Assert.AreEqual(metodo.anosMesesDiasDesde("05/34/2003", "02/01/2021"), null);
            Assert.AreEqual(metodo.anosMesesDiasDesde("56/12/2012", "02/01/2021"), null);
            Assert.AreEqual(metodo.anosMesesDiasDesde("31/02/2013", "02/01/2021"), null);
            Assert.AreEqual(metodo.anosMesesDiasDesde("12/12/2009/56", "02/01/2021"), null);
            Assert.AreEqual(metodo.anosMesesDiasDesde("12/12/9999", "02/01/2021"), null);
            Assert.AreEqual(metodo.anosMesesDiasDesde("", ""), null);
        }

        [TestMethod()]
        public void trieniosDesdeTest()
        {
            Assert.AreEqual(metodo.trieniosDesde("05/04/2011"), 3);
            Assert.AreEqual(metodo.trieniosDesde("07/12/2003"), 6);
            Assert.AreEqual(metodo.trieniosDesde("05:04:2011"), -1);
            Assert.AreEqual(metodo.trieniosDesde("05/34/2003"), -1);
            Assert.AreEqual(metodo.trieniosDesde("56/12/2012"), -1);
            Assert.AreEqual(metodo.trieniosDesde("31/02/2013"), -1);
            Assert.AreEqual(metodo.trieniosDesde("12/12/2009/56"), -1);
            Assert.AreEqual(metodo.trieniosDesde("15/12/9999"), -1);
            Assert.AreEqual(metodo.trieniosDesde(""), -1);
        }

        [TestMethod()]
        public void quinqueniosDesdeTest()
        {
            Assert.AreEqual(metodo.quinqueniosDesde("05/04/2011"), 2);
            Assert.AreEqual(metodo.quinqueniosDesde("07/12/2003"), 3);
            Assert.AreEqual(metodo.quinqueniosDesde("05:04:2011"), -1);
            Assert.AreEqual(metodo.quinqueniosDesde("05/34/2003"), -1);
            Assert.AreEqual(metodo.quinqueniosDesde("56/12/2012"), -1);
            Assert.AreEqual(metodo.quinqueniosDesde("31/02/2013"), -1);
            Assert.AreEqual(metodo.quinqueniosDesde("12/12/2009/56"), -1);
            Assert.AreEqual(metodo.quinqueniosDesde("15/12/9999"), -1);
            Assert.AreEqual(metodo.quinqueniosDesde(""), -1);
        }
    }
}