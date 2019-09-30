using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public  string Nombre { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<DetalleEvaluacion> Detalles { get; set; }


        public Evaluacion()
        {
            EvaluacionID = 0;
            this.Nombre = string.Empty;
            this.Total = 0;
            Fecha = DateTime.Now;
            Detalles = new List<DetalleEvaluacion>();
        }

      /*  public Evaluacion(int evaluacionID, string nombre, decimal total, DateTime fecha, List<DetalleEvaluacion> detalles)
        {
            EvaluacionID = evaluacionID;
            this.Nombre = nombre;
            Total = total;
            Fecha = fecha;
            this.Detalles = detalles;
        }*/

        public void AgragarDetalle(int DetalleID,int EvaluacionID , string nombre, decimal Valor, decimal Logrado,decimal Perdido, DateTime fecha)
        {
            this.Detalles.Add(new DetalleEvaluacion(DetalleID, EvaluacionID , nombre, Valor, Logrado, Perdido, fecha));
        }

        public void RemoverDetalle(int Index)
        {
            this.Detalles.RemoveAt(Index);
        }

    }
}
