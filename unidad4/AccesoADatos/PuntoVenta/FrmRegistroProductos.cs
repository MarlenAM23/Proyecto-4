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
    public partial class FrmRegistroProductos : Form
    {
        public FrmRegistroProductos()
        {
            InitializeComponent();
            DAOCategoria dao = new DAOCategoria();
            List<Categoria> lista = dao.consultarTodas();
          

            cmbCategoria.DataSource = lista;
            cmbCategoria.ValueMember = "Id";
            cmbCategoria.DisplayMember = "Nombre";

        }

        public FrmRegistroProductos(int id)
        {
            InitializeComponent();
            //Buscar la categoría que tenga ese id
            Producto pro = new DAOProducto().consultarUna(id);
            //Cargar los datos de las cajas con los datos de la categoría
            if (pro != null)
            {
                txtId.Text = pro.Id + "";
                txtNombre.Text = pro.Nombre;
                txtExistente.Text = pro.Existencia + "";
                txtPrecio.Text = pro.Precio + "";
                cmbCategoria.Text = pro.IdCategoria + ""; 
            }
            else
            {
                MessageBox.Show("El producto no existe");
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto obj;
            DAOProducto dao = new DAOProducto();
            bool resultado;
            //1 Crear el producto con los datos que necesitamos
            if (txtId.Text.Length > 0)
            {
                //Editar
                obj = new Producto(int.Parse(txtId.Text), txtNombre.Text, int.Parse(txtExistente.Text),
                    double.Parse(txtPrecio.Text), dao.consultarCategoria(cmbCategoria.Text), cmbCategoria.Text);
                //2 Enviar el producto a guardarse
                resultado = dao.editar(obj);
                lblprueba.Text= dao.consultarCategoria(cmbCategoria.Text).ToString();
            }
            else
            {
                obj = new Producto(txtNombre.Text, int.Parse(txtExistente.Text),
                    double.Parse(txtPrecio.Text), dao.consultarCategoria(cmbCategoria.Text), cmbCategoria.Text);
                //2 Enviar el producto a guardarse
                resultado = dao.agregar(obj);
                lblprueba.Text = dao.consultarCategoria(cmbCategoria.Text).ToString();
            }
            MessageBox.Show(resultado + "");
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //this.Close();
            
        }
    }
}
