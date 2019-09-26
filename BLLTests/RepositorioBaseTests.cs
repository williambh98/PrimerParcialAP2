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
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.nombre = "william";

            RepositorioBase<Evaluacion> repositorioBase = new RepositorioBase<Evaluacion>();
            Assert.IsTrue(repositorioBase.Guardar(evaluacion));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Evaluacion test = new Evaluacion();
            test.EvaluacionID = 1;
            test.nombre = "williamb";

            RepositorioBase<Evaluacion> repositorioBase = new RepositorioBase<Evaluacion>();
            Assert.IsTrue(repositorioBase.Modificar(test));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Evaluacion test = new Evaluacion();
            RepositorioBase<Evaluacion> repositorioBase = new RepositorioBase<Evaluacion>();
            test = repositorioBase.Buscar(id);
            Assert.AreEqual(true, test != null);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Evaluacion probar = new Evaluacion();
            RepositorioBase<Evaluacion> repositorioBase = new RepositorioBase<Evaluacion>();
            probar.EvaluacionID = 1;
            Assert.AreEqual(true, repositorioBase.Eliminar(probar.EvaluacionID));
        }
    }
}