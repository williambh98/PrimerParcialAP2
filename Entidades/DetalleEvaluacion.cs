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
    public class DetalleEvaluacion
    {
        [Key]
        public int DetalleID { get; set; }
        public int EvaluacionID { get; set; }
        public string Categoria { get; set;}
        public decimal Valor { get; set;}
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }
        public DateTime Fecha { get; set; }
        

        [ForeignKey("EvaluacionID")]
        public virtual Evaluacion  evaluacion { get; set; }

        public DetalleEvaluacion()
        {
            this.DetalleID = 0;
            this.EvaluacionID = 0;
            this.Categoria = string.Empty;
            this.Valor = 0;
            this.Logrado = 0;
            this.Perdido = 0;
            this.Fecha = DateTime.Now;
        }

        public DetalleEvaluacion(int detalleID, int evaluacionID, string categoria, decimal valor, decimal logrado,decimal perdido ,DateTime fecha)
        {
            DetalleID = detalleID;
            EvaluacionID = evaluacionID;
            Categoria = categoria;
            Valor = valor;
            Logrado = logrado;
            Perdido = perdido;
            Fecha = fecha;
        }
    }
}
