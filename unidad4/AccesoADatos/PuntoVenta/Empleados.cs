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
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
            actualizarTabla();
        }

        private void actualizarTabla()
        {
            DAOEmpleado dao = new DAOEmpleado();
            DgvEmpleados.DataSource = dao.consultarTodas();
            this.DgvEmpleados.Columns["usuario"].Visible = false;
            this.DgvEmpleados.Columns["contrasenia"].Visible = false;
        }

        private void btnAgregarEmp_Click(object sender, EventArgs e)
        {
            new FrmRegistroEmpleado().ShowDialog();
            actualizarTabla();
        }

        private void btnEditarEmp_Click(object sender, EventArgs e)
        {
            //Identificar que si haya un elemento seleccionado en la tabla
            if (DgvEmpleados.SelectedRows.Count > 0)
            {
                //Obtener el id de la categoría que voy a editar
                int idEmpleados = int.Parse(DgvEmpleados.SelectedRows[0].Cells[0].Value.ToString());

                new FrmRegistroEmpleado(idEmpleados).ShowDialog();

                actualizarTabla();
            }
            else
            {
                MessageBox.Show("Selecciona un empleado");

            }
        }

        private void btnEliminarEmp_Click(object sender, EventArgs e)
        {
            //Identificar que si haya un elemento seleccionado en la tabla
            if (DgvEmpleados.SelectedRows.Count > 0)
            {
                //Obtener el id del empleado que voy a editar
                int idEmpleado = int.Parse(DgvEmpleados.SelectedRows[0].Cells[0].Value.ToString());

                string empleado = DgvEmpleados.SelectedRows[0].Cells[1].Value.ToString();

                //Solicitar confirmación
                DialogResult respuesta = MessageBox.Show(this, "Estás a punto de eliminar el empleado " + empleado + ", ¿deseas continuar?", "Confirmación", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    //Eliminar el empleado
                    DAOEmpleado dao = new DAOEmpleado();
                    bool resultado = dao.eliminar(idEmpleado);
                    if (resultado)
                    {
                        //informar la eliminación
                        MessageBox.Show("Se ha borrado el empleado");
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido realizar la operación, verifica que el empleado exista");
                    }
                    actualizarTabla();
                }



            }
            else
            {
                MessageBox.Show("Selecciona un empleado");


            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Close();
        }
    }
}
