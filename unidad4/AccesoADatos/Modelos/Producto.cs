using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int Existencia { get; set; }
        public double Precio { get; set; }
        public int IdCategoria { get; set; }
        public String Categoria { get; set; }


        public Producto(int id, String nombre, int existencia, double precio, int idcategoria, String categoria)
        {
            Id = id;
            Nombre = nombre;
            Existencia = existencia;
            Precio = precio;
            IdCategoria = idcategoria;
            Categoria = categoria;
        }

        public Producto(String nombre, int existencia, double precio, int idcategoria, String categoria)
        {
            Nombre = nombre;
            Existencia = existencia;
            Precio = precio;
            IdCategoria = idcategoria;
            Categoria = categoria;
        }
    }

       

}
