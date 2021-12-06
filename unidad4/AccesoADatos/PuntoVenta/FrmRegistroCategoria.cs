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
    public partial class FrmRegistroCategoria : Form
    {
        //Se ejecuta cuando es agregar
        public FrmRegistroCategoria()
        {
            InitializeComponent();
        }

        //Se ejecuta cuando es editar
        public FrmRegistroCategoria(int id) {
            InitializeComponent();
            //Buscar la categoría que tenga ese id
            Categoria cat = new DAOCategoria().consultarUna(id);
            //Cargar los datos de las cajas con los datos de la categoría
            if (cat != null)
            {
                txtClave.Text = cat.Id + "";
                txtNombre.Text = cat.Nombre;
            }
            else {
                MessageBox.Show("La categoría no existe");
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Categoria obj;
            DAOCategoria dao = new DAOCategoria();
            bool resultado;
            //1 Crear la categoría con los datos que necesitamos
            if (txtClave.Text.Length > 0)
            {
                //Editar
                obj = new Categoria(int.Parse(txtClave.Text),txtNombre.Text);
                //2 Enviar la categoría a guardarse
                resultado = dao.editar(obj);
            }
            else
            {
                obj = new Categoria(txtNombre.Text);
                //2 Enviar la categoría a guardarse
                resultado= dao.agregar(obj);
            }
            MessageBox.Show(resultado+"");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
