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
        Metodos metodo;

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
    }
}