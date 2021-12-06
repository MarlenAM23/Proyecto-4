using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using MySql.Data.MySqlClient;
using System.Data;


namespace Datos
{
   public class DAOEmpleado
    {
        public Empleado autenticar(String usuario, String contrasenia)
        {
            //Armar la consulta a ejecutar
            String consulta = "select * from Empleados where usuario=@usuario " +
                "and contrasenia=@pass;";
            //Encapsular la consulta command
            MySqlCommand select = new MySqlCommand(consulta);
            //select.CommandText = consulta;
            select.Parameters.AddWithValue("@usuario", usuario);
            select.Parameters.AddWithValue("@pass", contrasenia);

            //Mandar a ejecutar la caonsulta 
            DataTable resultado = Conexion.ejecutarSelect(select);

            // Verificar si hubo respuesta exitosa
            if (resultado != null)
            {
                //Recorrer cada renglon de la tabla de resultados y llenar la lista
                if (resultado.Rows.Count > 0)
                {
                    Empleado obj = new Empleado(
                    int.Parse(resultado.Rows[0]["id"].ToString()),
                    resultado.Rows[0]["nombre"].ToString(),
                    resultado.Rows[0]["apellidos"].ToString(),
                    resultado.Rows[0]["usuario"].ToString(),
                    resultado.Rows[0]["contrasenia"].ToString(),
                    resultado.Rows[0]["puesto"].ToString()
                    );
                    return obj;
                }
            }

            return null;

        }
        public bool agregar(Empleado empleado)
        {
            //Indicar la sentencia y los parámetros
            String insert = "INSERT INTO Empleados(nombre, apellidos, usuario, contrasenia, puesto) " +
            "VALUES(@nombre, @apellidos, @usuario, @contrasenia, @puesto); ";

        MySqlCommand comando = new MySqlCommand(insert);

        //Enviar los valores que reemplazarán a cada parámetro
        comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
        comando.Parameters.AddWithValue("@apellidos", empleado.Apellidos);
        comando.Parameters.AddWithValue("@usuario", empleado.Usuario);
        comando.Parameters.AddWithValue("@contrasenia", empleado.Contrasenia);
        comando.Parameters.AddWithValue("@puesto", empleado.Puesto);

            int filas = Conexion.ejecutarSentencia(comando);
            if (filas > 0)
            {
                return true;
            }
            else {
                return false;
            }
            
            
        }

    public bool editar(Empleado empleado)
    {
        //Indicar la sentencia y los parámetros
        String sentencia = "UPDATE Empleados SET nombre=@nombre, apellidos=@apellidos, " +
                "puesto=@puesto WHERE id=@id;"; 

        MySqlCommand comando = new MySqlCommand(sentencia);

        //Enviar los valores que reemplazarán a cada parámetro
        comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
        comando.Parameters.AddWithValue("@apellidos", empleado.Apellidos);
        comando.Parameters.AddWithValue("@puesto", empleado.Puesto);
        comando.Parameters.AddWithValue("@id", empleado.Id);

        int filas = Conexion.ejecutarSentencia(comando);
        if (filas > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool eliminar(int id)
    {
        //Indicar la sentencia y los parámetros
        String sentencia = "DELETE FROM Empleados WHERE id=@id;";

        MySqlCommand comando = new MySqlCommand(sentencia);

        //Enviar los valores que reemplazarán a cada parámetro
        comando.Parameters.AddWithValue("@id", id);

        int filas = Conexion.ejecutarSentencia(comando);
        if (filas > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Empleado consultarUna(int id)
    {
        //Armar la consulta a ejecutar
        String consulta = "SELECT * FROM Empleados WHERE id=@id";

        //Encapsular la consulta en un command
        MySqlCommand select = new MySqlCommand(consulta);
        select.Parameters.AddWithValue("@id", id);

        //select.CommandText = consulta;

        //Mandar a ejecutar la consulta
        DataTable resultado = Conexion.ejecutarSelect(select);


        //Verificar si hubo respuesta exitósa
        if (resultado != null)
        {
            //Recorrer cada renglon de la tabla de resultados
            //y llenar la lista
            if (resultado.Rows.Count > 0)
            {
                Empleado obj = new Empleado(
                    int.Parse(resultado.Rows[0]["id"].ToString()),
                    resultado.Rows[0]["nombre"].ToString(), 
                    resultado.Rows[0]["apellidos"].ToString(),
                    resultado.Rows[0]["usuario"].ToString(),
                    resultado.Rows[0]["contrasenia"].ToString(),
                    resultado.Rows[0]["puesto"].ToString()
                );
                return obj;
            }
        }

        return null;
    }
    public List<Empleado> consultarTodas()
    {
        //Armar la consulta a ejecutar
        String consulta = "SELECT * FROM Empleados ORDER BY nombre;";

        //Encapsular la consulta en un command
        MySqlCommand select = new MySqlCommand(consulta);
        //select.CommandText = consulta;

        //Mandar a ejecutar la consulta
        DataTable resultado = Conexion.ejecutarSelect(select);

        List<Empleado> lista = new List<Empleado>();
        //Verificar si hubo respuesta exitósa
        if (resultado != null)
        {
            //Recorrer cada renglon de la tabla de resultados
            //y llenar la lista
            for (int i = 0; i < resultado.Rows.Count; i++)
            {
                Empleado obj = new Empleado(
                    int.Parse(resultado.Rows[i]["id"].ToString()),
                    resultado.Rows[i]["nombre"].ToString(),
                    resultado.Rows[i]["apellidos"].ToString(),
                    resultado.Rows[i]["usuario"].ToString(),
                    resultado.Rows[i]["contrasenia"].ToString(),
                    resultado.Rows[i]["puesto"].ToString()
                );
                lista.Add(obj);
                
            }
        }

        return lista;
    }
}
}
