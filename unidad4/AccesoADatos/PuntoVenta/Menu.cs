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
    public partial class Menu : Form
    {
        public Menu()
        {
        
            InitializeComponent();
        }


        private void btnCategorias_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().ShowDialog();
            
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            this.Close();
            new Empleados().ShowDialog();
            
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.Close();
            new Productos().ShowDialog();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
