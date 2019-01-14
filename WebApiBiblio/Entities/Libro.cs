using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Libro
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int GeneroID { get; set; }
    }
}
