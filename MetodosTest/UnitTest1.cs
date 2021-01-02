using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesarrolloDirigidoPorPruebas.Tests
{
    public class MetodosTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [TestCleanup]
        public void CleanUp()
        {
        }

        [TestMethod()]
        public void ComprobarContrasena2Test()
        {
            Assert.IsTrue(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("Password55_"));
            Assert.IsFalse(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("Short5-"));
            Assert.IsFalse(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("PASSWORD55_"));
            Assert.IsTrue(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("Password214#"));
            Assert.IsFalse(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("password343-"));
            Assert.IsTrue(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("Password1234*"));
            Assert.IsFalse(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("234235435346"));
            Assert.IsFalse(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("PasswordWrong_"));
            Assert.IsTrue(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("Password1234*"));
            Assert.IsFalse(DesarrolloDirigidoPorPruebas.ComprobarContrasena2("Password1234"));
            Assert.IsFalse(DesarrolloDirigidoPorPruebas.ComprobarContrasena2(""));
        }
    }
}