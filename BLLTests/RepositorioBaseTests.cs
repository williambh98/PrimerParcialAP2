using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Linq.Expressions;

namespace BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            ProbarTest test = new ProbarTest();
            test.nombre = "william";

            RepositorioBase<ProbarTest> repositorioBase = new RepositorioBase<ProbarTest>();
            Assert.IsTrue(repositorioBase.Guardar(test));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            ProbarTest test = new ProbarTest();
            test.IdP = 1;
            test.nombre = "williamb";

            RepositorioBase<ProbarTest> repositorioBase = new RepositorioBase<ProbarTest>();
            Assert.IsTrue(repositorioBase.Modificar(test));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            ProbarTest test = new ProbarTest();
            RepositorioBase<ProbarTest> repositorioBase = new RepositorioBase<ProbarTest>();
            test = repositorioBase.Buscar(id);
            Assert.AreEqual(true, test != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<ProbarTest> repositorioBase = new RepositorioBase<ProbarTest>();
            List<ProbarTest> lista = new List<ProbarTest>();
            Expression<Func<ProbarTest, bool>> prueba = u => true;
            lista = repositorioBase.GetList(prueba);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            ProbarTest probar = new ProbarTest();
            RepositorioBase<ProbarTest> repositorioBase = new RepositorioBase<ProbarTest>();
            probar.IdP = 1;
            Assert.AreEqual(true, repositorioBase.Eliminar(probar.IdP));
        }
    }
}