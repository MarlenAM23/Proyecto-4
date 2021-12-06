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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DAOEmpleado dao = new DAOEmpleado();
            Empleado empleado = dao.autenticar(txtUsuario.Text, txtcontrasenia.Text);
            if (empleado != null)
            {
                new Menu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }
    }
}
