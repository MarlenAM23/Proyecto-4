using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace PuntoVenta
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            actualizarTabla();

        }

        private void actualizarTabla()
        {
            DAOProducto dao = new DAOProducto();
            DgvProductos.DataSource = dao.consultarTodos();
            this.DgvProductos.Columns["idcategoria"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new FrmRegistroProductos().ShowDialog();
            actualizarTabla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Identificar que si haya un elemento seleccionado en la tabla
            if (DgvProductos.SelectedRows.Count > 0)
            {
                //Obtener el id del producto que voy a editar
                int idProducto = int.Parse(DgvProductos.SelectedRows[0].Cells[0].Value.ToString());

                new FrmRegistroProductos(idProducto).ShowDialog();

                actualizarTabla();
            }
            else
            {
                MessageBox.Show("Selecciona un producto");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             //Identificar que si haya un elemento seleccionado en la tabla
            if (DgvProductos.SelectedRows.Count > 0)
            {
                //Obtener el id del empleado que voy a editar
                int idProducto = int.Parse(DgvProductos.SelectedRows[0].Cells[0].Value.ToString());

                string producto = DgvProductos.SelectedRows[0].Cells[1].Value.ToString();

                //Solicitar confirmación
                DialogResult respuesta = MessageBox.Show(this, "Estás a punto de eliminar el producto " + producto + ", ¿deseas continuar?", "Confirmación", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    //Eliminar el producto
                    DAOProducto dao = new DAOProducto();
                    bool resultado = dao.eliminar(idProducto);
                    if (resultado)
                    {
                        //informar la eliminación
                        MessageBox.Show("Se ha borrado el producto");
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido realizar la operación, verifica que el producto exista");
                    }
                    actualizarTabla();
                }



            }
            else
            {
                MessageBox.Show("Selecciona un producto");


            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Close();
        }
    }
}
