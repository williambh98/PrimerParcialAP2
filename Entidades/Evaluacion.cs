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
        public  string nombre { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public List<DetalleEvaluacion> detalles;
        public Evaluacion()
        {
            EvaluacionID = 0;
            this.nombre = string.Empty;
            this.Total = 0;
        }

        public Evaluacion(int evaluacionID, string nombre, decimal total, DateTime fecha, List<DetalleEvaluacion> detalles)
        {
            EvaluacionID = evaluacionID;
            this.nombre = nombre;
            Total = total;
            Fecha = fecha;
            this.detalles = detalles;
        }

        public void AgragarDetalle(int DetalleID,int EvaluacionID , string nombre, decimal Valor, decimal Logrado, DateTime fecha)
        {
            this.detalles.Add(new DetalleEvaluacion(DetalleID, EvaluacionID , nombre, Valor, Logrado, fecha));
        }

        public void RemoverDetalle(int Index)
        {
            this.detalles.RemoveAt(Index);
        }

    }
}
