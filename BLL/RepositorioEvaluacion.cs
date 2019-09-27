using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioEvaluacion : RepositorioBase<Evaluacion>
    {
        public override Evaluacion Buscar(int id)
        {
            Evaluacion Evaluaciones = new Evaluacion();
            Contexto contexto = new Contexto();
            try
            {
                Evaluaciones = contexto.Evaluacion.Include(x => x.Detalles).Where(x => x.EvaluacionID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Evaluaciones;
        }
        public override bool Modificar(Evaluacion evaluacion)
        {
            var Anterior = Buscar(evaluacion.EvaluacionID);
            bool paso = false;

            try
            {
                using (Contexto contexto = new Contexto())
                {
                    foreach (var item in Anterior.Detalles.ToList())
                    {
                        if (!evaluacion.Detalles.Exists(d => d.DetalleID == item.DetalleID))
                        {
                            contexto.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        }
                    }
                    contexto.SaveChanges();
                }
                foreach (var item in evaluacion.Detalles)
                {
                    var estado = item.DetalleID > 0 ? EntityState.Unchanged : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }
                _contexto.Entry(evaluacion).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch
            {
                throw;
            }
            return paso;
        }

    }

}


