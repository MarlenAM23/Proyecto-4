using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Empleado
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Usuario { get; set; }
        public String Contrasenia { get; set; }
        public String Puesto { get; set; }


        public Empleado(int id, String nombre, String apellidos, String usuario, String contrasenia,
            String puesto)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Usuario = usuario;
            Contrasenia = contrasenia;
            Puesto = puesto;

        }

        

        public Empleado(String nombre, String apellidos, String usuario, String contrasenia,
            String puesto)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Usuario = usuario;
            Contrasenia = contrasenia;
            Puesto = puesto;
        }
    }


}
