using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Categoria
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        public Categoria(int id, String nombre) {
            Id = id;
            Nombre = nombre;
        }
        public Categoria(String nombre)
        {
            Nombre = nombre;
        }
    }
}
