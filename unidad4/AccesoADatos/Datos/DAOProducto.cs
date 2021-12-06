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
   public class DAOProducto
    {
        public bool agregar(Producto producto)
        {
            //Indicar la sentencia y los parámetros
            String insert = "INSERT INTO Productos(nombre, existencia, precio, idcategoria) " +
            "VALUES(@nombre, @existencia, @precio, @idcategoria); ";

            MySqlCommand comando = new MySqlCommand(insert);

            //Enviar los valores que reemplazarán a cada parámetro
            comando.Parameters.AddWithValue("@nombre", producto.Nombre);
            comando.Parameters.AddWithValue("@existencia", producto.Existencia);
            comando.Parameters.AddWithValue("@precio", producto.Precio);
            comando.Parameters.AddWithValue("@idcategoria", producto.IdCategoria);

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

        public bool editar(Producto producto)
        {
            //Indicar la sentencia y los parámetros
            String sentencia = "UPDATE Productos SET nombre=@nombre, exitencia=@existencia, " +
               "precio=@precio, idcategoria=@idcategoria WHERE id=@id;";

            MySqlCommand comando = new MySqlCommand(sentencia);

            //Enviar los valores que reemplazarán a cada parámetro
            comando.Parameters.AddWithValue("@nombre", producto.Nombre);
            comando.Parameters.AddWithValue("@existencia", producto.Existencia);
            comando.Parameters.AddWithValue("@precio", producto.Precio);
            comando.Parameters.AddWithValue("@idcategoria", producto.IdCategoria);
            comando.Parameters.AddWithValue("@id", producto.Id);

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
            String sentencia = "DELETE FROM Productos WHERE id=@id;";

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

        public Producto consultarUna(int id)
        {
            //Armar la consulta a ejecutar
            String consulta = "SELECT * FROM Productos WHERE id=@id";

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
                    Producto obj = new Producto(
                        int.Parse(resultado.Rows[0]["id"].ToString()),
                        resultado.Rows[0]["nombre"].ToString(),
                        int.Parse(resultado.Rows[0]["existencia"].ToString()),
                        double.Parse(resultado.Rows[0]["precio"].ToString()),
                        int.Parse(resultado.Rows[0]["idcategoria"].ToString()),
                        resultado.Rows[0]["categoria"].ToString()
                    );
                    return obj;
                }
            }

            return null;
        }
        public List<Producto> consultarTodas()
        {
            //Armar la consulta a ejecutar
            String consulta = "SELECT * FROM Productos ORDER BY nombre;";

            //Encapsular la consulta en un command
            MySqlCommand select = new MySqlCommand(consulta);
            //select.CommandText = consulta;

            //Mandar a ejecutar la consulta
            DataTable resultado = Conexion.ejecutarSelect(select);

            List<Producto> lista = new List<Producto>();
            //Verificar si hubo respuesta exitósa
            if (resultado != null)
            {
                //Recorrer cada renglon de la tabla de resultados
                //y llenar la lista
                for (int i = 0; i < resultado.Rows.Count; i++)
                {
                    Producto obj = new Producto(
                        int.Parse(resultado.Rows[i]["id"].ToString()),
                        resultado.Rows[i]["nombre"].ToString(),
                       int.Parse(resultado.Rows[i]["existencia"].ToString()),
                        double.Parse(resultado.Rows[i]["precio"].ToString()),
                        int.Parse(resultado.Rows[i]["idCategoria"].ToString()),
                        resultado.Rows[i]["categoria"].ToString()
                    );
                    lista.Add(obj);
                }
            }

            return lista;
        }
        public int consultarCategoria(String nombre)
        {
            int categoria = 0;
            String consulta = "select id from categorias where nombre=@nombre;";

            MySqlCommand comando = new MySqlCommand(consulta);

            //Enviar los valores que reemplazarán a cada parámetro
            comando.Parameters.AddWithValue("@nombre", nombre);

            categoria = Conexion.ejecutarSentencia(comando);
            
            return categoria;
        }
        public List<Producto> consultarTodos()
        {
            //Armar la consulta a ejecutar
            String consulta = "SELECT p.Id,p.nombre,p.existencia,p.precio, c.id as idcategoria," +
                " c.nombre as categoria" +
                " FROM Productos as p" +
                " JOIN Categorias as c ON p.idCategoria = c.id" +
                " ORDER BY p.nombre";

            //Encapsular la consulta en un command
            MySqlCommand select = new MySqlCommand(consulta);
            //select.CommandText = consulta;

            //Mandar a ejecutar la consulta
            DataTable resultado = Conexion.ejecutarSelect(select);

            List<Producto> lista = new List<Producto>();
            //Verificar si hubo respuesta exitósa
            if (resultado != null)
            {
                //Recorrer cada renglon de la tabla de resultados
                //y llenar la lista
                for (int i = 0; i < resultado.Rows.Count; i++)
                {
                    Producto obj = new Producto(
                    int.Parse(resultado.Rows[i]["id"].ToString()),
                    resultado.Rows[i]["nombre"].ToString(),
                    int.Parse(resultado.Rows[i]["existencia"].ToString()),
                    double.Parse(resultado.Rows[i]["precio"].ToString()),
                    int.Parse(resultado.Rows[i]["idcategoria"].ToString()),
                    resultado.Rows[i]["categoria"].ToString()
                    );
                lista.Add(obj);
                }
            }

            return lista;
        }
    }
}
