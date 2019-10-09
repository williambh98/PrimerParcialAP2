using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
   public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        public string Descripcion { get; set; }
        public decimal Perdida { get; set; }
        public DateTime Fecha { get; set; }

        public Categoria()
        {
            this.CategoriaID = 0;
            this.Descripcion = string.Empty;
            this.Perdida = 0;
            this.Fecha = DateTime.Now;
        }

        public Categoria(int categoriaID, string descripcion, decimal perdida, DateTime fecha)
        {
            CategoriaID = categoriaID;
            Descripcion = descripcion;
            Perdida = perdida;
            Fecha = fecha;
        }
    }
}
