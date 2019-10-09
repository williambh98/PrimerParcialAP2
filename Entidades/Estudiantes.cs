using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Estudiantes
    {
        [Key]
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }
        public decimal PuntoPerdidos { get; set; }
        public DateTime Fecha { get; set; }

        public Estudiantes()
        {
            this.EstudianteID = 0;
            this.Nombre = string.Empty;
            this.PuntoPerdidos = 0;
            this.Fecha = DateTime.Now;
        }

        public Estudiantes(int estudianteID, string nombre, decimal puntoPerdidos, DateTime fecha)
        {
            EstudianteID = estudianteID;
            Nombre = nombre;
            PuntoPerdidos = puntoPerdidos;
            Fecha = fecha;
        }
    }
}
