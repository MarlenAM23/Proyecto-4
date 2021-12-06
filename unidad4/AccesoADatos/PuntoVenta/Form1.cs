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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            actualizarTabla();

        }

        private void actualizarTabla() {
            DAOCategoria dao = new DAOCategoria();
            dgvLista.DataSource = dao.consultarTodas();
        }
     

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new FrmRegistroCategoria().ShowDialog();
            actualizarTabla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Identificar que si haya un elemento seleccionado en la tabla
            if (dgvLista.SelectedRows.Count > 0)
            {
                //Obtener el id de la categoría que voy a editar
                int idCategoria = int.Parse(dgvLista.SelectedRows[0].Cells[0].Value.ToString());
                
                new FrmRegistroCategoria(idCategoria).ShowDialog();
                
                actualizarTabla();
            }
            else {
                MessageBox.Show("Selecciona una categoría");
            
            
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Identificar que si haya un elemento seleccionado en la tabla
            if (dgvLista.SelectedRows.Count > 0)
            {
                //Obtener el id de la categoría que voy a editar
                int idCategoria = int.Parse(dgvLista.SelectedRows[0].Cells[0].Value.ToString());

                string categoria = dgvLista.SelectedRows[0].Cells[1].Value.ToString();

                //Solicitar confirmación
                DialogResult respuesta = MessageBox.Show(this, "Estás a punto de eliminar la categoría " + categoria + ", ¿deseas continuar?", "Confirmación", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes) {
                    //Eliminar la categoría
                    DAOCategoria dao = new DAOCategoria();
                    bool resultado = dao.eliminar(idCategoria);
                    if (resultado)
                    {
                        //informar la eliminación
                        MessageBox.Show("Se ha borrado la categoría");
                    }
                    else {
                        MessageBox.Show("No se ha podido realizar la operación, verifica que la categoría exista y que no tenga productos asociados");
                    }
                    actualizarTabla();
                }
                

                
            }
            else
            {
                MessageBox.Show("Selecciona una categoría");


            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Close();
        }
    }
}
