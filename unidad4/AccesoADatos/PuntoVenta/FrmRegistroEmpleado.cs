using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;
using Datos;

namespace PuntoVenta
{
    public partial class FrmRegistroEmpleado : Form
    {
        public FrmRegistroEmpleado()
        {
            InitializeComponent();
        }

        public FrmRegistroEmpleado(int id)
        {
            InitializeComponent();
            //Buscar la categoría que tenga ese id
            Empleado emp = new DAOEmpleado().consultarUna(id);
            //Cargar los datos de las cajas con los datos de la categoría
            if (emp != null)
            {
                txtId.Text = emp.Id + "";
                txtNombre.Text = emp.Nombre;
                txtApellidos.Text = emp.Apellidos;
                txtUsuario.Text = emp.Usuario;
                txtContrasenia.Text = emp.Contrasenia;
                txtPuesto.Text = emp.Puesto;
            }
            else
            {
                MessageBox.Show("El empleado no existe");
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Empleado obj;
            DAOEmpleado dao = new DAOEmpleado();
            bool resultado;
            //1 Crear el Empleado con los datos que necesitamos
            if (txtId.Text.Length > 0)
            {
                //Editar
                obj = new Empleado(int.Parse(txtId.Text), txtNombre.Text, txtApellidos.Text,
                    txtUsuario.Text, txtContrasenia.Text, txtPuesto.Text);
                //2 Enviar el empleado a guardarse
                resultado = dao.editar(obj);
            }
            else
            {
                obj = new Empleado(txtNombre.Text, txtApellidos.Text,
                    txtUsuario.Text, txtContrasenia.Text, txtPuesto.Text);
                //2 Enviar el empleado a guardarse
                resultado = dao.agregar(obj);
            }
            MessageBox.Show(resultado + "");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
