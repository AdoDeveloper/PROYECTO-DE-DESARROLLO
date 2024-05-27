using DataLayer;
using DataLayer.MODELOS;
using General.GUI.GESTION_PRODUCTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI.PRODUCTOS
{
    public partial class GestionProductos : Form
    {
        public GestionProductos()
        {
            InitializeComponent();
            CargarProductos();
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AgregarEditar f = new AgregarEditar();
            f.UpdateDataGridView += FormNuevo_UpdateDataGridView;
            f.setEditar(false);
            f.Show();
        }

        private void FormNuevo_UpdateDataGridView(object sender, EventArgs e)
        {
            // Aquí recargarás el DataGridView
            CargarProductos();
        }
        public int ContarRegistros()
        {
            return dtgProductos.Rows.Count;
        }
        public void CargarProductos()
        {
            List<ProductoModel> productoModels = Consultas.OBTENER_PRODUCTOS();
            dtgProductos.DataSource = productoModels;
            if (dtgProductos.Columns["Image"] != null)
            {
                dtgProductos.Columns["Image"].Visible = false;
            }

            int totalRegistros = ContarRegistros();
            lblContador.Text = $": {totalRegistros}";
        }
        private void FiltrarProductos(string filtro)
        {
            try
            {
                List<ProductoModel> productosFiltrados = Consultas.FILTRAR_PRODUCTOS(filtro);
                dtgProductos.DataSource = productosFiltrados;
                int totalRegistros = ContarRegistros();
                lblContador.Text = $": {totalRegistros}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al filtrar los datos: {ex.Message}");
            }
        }

        private void txbFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txbFiltro.Text.Trim();
            FiltrarProductos(filtro.ToLower());
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AgregarEditar f = new AgregarEditar();
            ProductoModel productoSeleccionado = (ProductoModel)dtgProductos.CurrentRow.DataBoundItem;

            productoSeleccionado = Consultas.OBTENER_PRODUCTO(productoSeleccionado.Id_producto);

            f.UpdateDataGridView += FormNuevo_UpdateDataGridView;
            f.setEditar(true);
            f.setProducto(productoSeleccionado);
            f.Show();
        }

       
    }
}
