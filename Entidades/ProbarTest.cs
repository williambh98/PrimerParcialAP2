using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProbarTest
    {
        [Key]
        public int IdP { get; set; }
        public  string nombre { get; set; }

        public ProbarTest()
        {
            IdP = 0;
            this.nombre = string.Empty;
        }

        public ProbarTest(int idP, string nombre)
        {
            IdP = idP;
            this.nombre = nombre;
        }
    }
}
