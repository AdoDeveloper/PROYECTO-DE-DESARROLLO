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
            f.Show();
        }

        private void FormNuevo_UpdateDataGridView(object sender, EventArgs e)
        {
            // Aquí recargarás el DataGridView
            CargarProductos();
        }

        public void CargarProductos()
        {
            List<ProductoModel> productoModels = Consultas.OBTENER_PRODUCTOS();
            dtgProductos.DataSource = productoModels;
        }
    }
}
