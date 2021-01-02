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
            Assert.IsFalse(metodo.comprobarURL("https://twitter.qwe"));
            Assert.IsTrue(metodo.comprobarURL("https://web.whatsapp.com"));
            Assert.IsTrue(metodo.comprobarURL("https://ubuvirtual.ubu.es/course"));
            Assert.IsTrue(metodo.comprobarURL("https://ubuvirtual.ubu.es"));
            Assert.IsFalse(metodo.comprobarURL(""));
        }
    }
}