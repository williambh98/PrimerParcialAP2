using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Evaluacion
    {
        [Key]
        public int EvaluacionID { get; set; }
        public int EstudianteID { get; set; }
        [ForeignKey("EstudianteID")]
        public virtual Estudiantes Estudiantes { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<DetalleEvaluacion> Detalles { get; set; }


        public Evaluacion()
        {
            EvaluacionID = 0;
            EstudianteID = 0;
            this.Total = 0;
            Fecha = DateTime.Now;
            Detalles = new List<DetalleEvaluacion>();
        }

        public Evaluacion(int evaluacionID, int estudianteID, decimal total, DateTime fecha, List<DetalleEvaluacion> detalles)
        {
            EvaluacionID = evaluacionID;
            EstudianteID = estudianteID;
            Total = total;
            Fecha = fecha;
            Detalles = detalles;
        }

        public void AgragarDetalle(int DetalleID,int EvaluacionID,int categoriaID,decimal Valor, decimal Logrado,decimal Perdido)
        {
            this.Detalles.Add(new DetalleEvaluacion(DetalleID, EvaluacionID , categoriaID, Valor, Logrado, Perdido));
        }

        public void RemoverDetalle(int Index)
        {
            this.Detalles.RemoveAt(Index);
        }

    }
}
