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
    /*
    CRUD (Create, Read, Update, Delete)
    Catálogo (ABC-> Altas, Bajas y Cambios y Consultas)
    */

    /// <summary>
    /// Contiene todos las operaciones de acceso a datos (acceso la BD)
    /// Es decir, operaciones para añadir, editar, eliminar y 
    /// consultar una o todas las categorías
    /// </summary>
    
    public class DAOCategoria
    {
        public bool agregar(Categoria categoria) {
            //Indicar la sentencia y los parámetros
            String insert="INSERT INTO Categorias(nombre) "+
                "VALUES(@nombre);";

            MySqlCommand comando = new MySqlCommand(insert);

            //Enviar los valores que reemplazarán a cada parámetro
            comando.Parameters.AddWithValue("@nombre", categoria.Nombre);

            int filas=Conexion.ejecutarSentencia(comando);
            if (filas > 0)
            {
                return true;
            }
            else {
                return false;
            }
            
            
        }

        public bool editar(Categoria categoria)
        {
            //Indicar la sentencia y los parámetros
            String sentencia = "UPDATE Categorias SET nombre=@nombre" +
                " WHERE id=@id;";

            MySqlCommand comando = new MySqlCommand(sentencia);

            //Enviar los valores que reemplazarán a cada parámetro
            comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
            comando.Parameters.AddWithValue("@id", categoria.Id);

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
            String sentencia = "DELETE FROM Categorias WHERE id=@id;";

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

        public Categoria consultarUna(int id)
        {
            //Armar la consulta a ejecutar
            String consulta = "SELECT * FROM Categorias WHERE id=@id";

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
                if(resultado.Rows.Count>0)
                {
                    Categoria obj = new Categoria(
                        int.Parse(resultado.Rows[0]["id"].ToString()),
                        resultado.Rows[0]["nombre"].ToString()
                    );
                    return obj;
                }
            }

            return null;
        }
        public List<Categoria> consultarTodas()
        {
            //Armar la consulta a ejecutar
            String consulta = "SELECT * FROM Categorias ORDER BY nombre;";

            //Encapsular la consulta en un command
            MySqlCommand select = new MySqlCommand(consulta);
            //select.CommandText = consulta;

            //Mandar a ejecutar la consulta
            DataTable resultado = Conexion.ejecutarSelect(select);

            List<Categoria> lista = new List<Categoria>();
            //Verificar si hubo respuesta exitósa
            if (resultado != null) {
                //Recorrer cada renglon de la tabla de resultados
                //y llenar la lista
                for (int i = 0; i < resultado.Rows.Count; i++)
                {
                    Categoria obj = new Categoria(
                        int.Parse(resultado.Rows[i]["id"].ToString()),
                        resultado.Rows[i]["nombre"].ToString()
                    );
                    lista.Add(obj);
                }
            }
            
            return lista;
        }
    }
}
