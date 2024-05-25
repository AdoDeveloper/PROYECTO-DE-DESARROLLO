using DataLayer;
using DataLayer.MODELOS;
using General.GUI.CLIENTES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI.VENTAS
{
    public partial class RealizarVenta : Form
    {
        ClienteModel cliente = new ClienteModel();

        List<ProductoModel> ltsBuscados = new List<ProductoModel>();

        List<ProductoModel> ltsSeleccionados = new List<ProductoModel>();

        public RealizarVenta()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void onBuscarProducto(object sender, EventArgs e)
        {

        }

        private void setCliente(object sender, EventArgs e, ClienteModel c)
        {
            this.cliente = c;
            txbNomCliente.Text = this.cliente.Cliente;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GestionClientes c = new GestionClientes();
            c.isFormOpenOnVenta(true);
            c.setClienteOnVenta += setCliente;
            c.ShowDialog();
        }

        private void onBuscarProducto(object sender, KeyPressEventArgs e)
        {
            try {
                
                ltsBuscados =  Consultas.BUSCAR_PRODUCTOS(txbProducto.Text.ToLower());
                
                cmbProducto.Items.Clear();
                cmbProducto.Items.Add("Seleccionar");

                foreach (ProductoModel p in ltsBuscados)
                {
                    cmbProducto.Items.Add(p.Id_producto + " - " + p.Producto + " - $" + p.Precio.ToString());
                }
                cmbProducto.SelectedIndex = 0;
            } 
            catch { 
            
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem != null && !cmbProducto.SelectedItem.ToString().Equals("Seleccionar"))
            {
                Int32 id_producto = Convert.ToInt32(cmbProducto.SelectedItem.ToString().Split('-')[0]);

                ProductoModel seleccionado = ltsBuscados.Find(element => element.Id_producto == id_producto);

                ltsSeleccionados.Add(seleccionado);

                dtgProductos.DataSource = ltsSeleccionados;
                dtgProductos.Columns["Image"].Visible = false;
                dtgProductos.Refresh();
            }
            else
            {
                MessageBox.Show("Debe buscar un producto");
            }

        }
    }
}
