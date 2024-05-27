using DataLayer.MODELOS;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI.GESTION_PROVEEDORES
{
    public partial class GestionProveedor : Form
    {
        public GestionProveedor()
        {
            InitializeComponent();
            CargarProveedores();
        }

        private void FormNuevo_UpdateDataGridView(object sender, EventArgs e)
        {
            // Aquí recargarás el DataGridView
            CargarProveedores();
        }

        public void CargarProveedores()
        {
            List<ProveedorModel> p = Consultas.OBTENER_PROVEEDORES();
            dtgProveedores.DataSource = p;
        }

        private void GestionProveedor_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ProveedorModel ps = (ProveedorModel)dtgProveedores.CurrentRow.DataBoundItem;
            AgregarEditar agregarEditar = new AgregarEditar();
            agregarEditar.UpdateDataGridView += FormNuevo_UpdateDataGridView;
            agregarEditar.isEditForm(true);
            agregarEditar.setProveedor(ps);
            agregarEditar.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AgregarEditar agregarEditar = new AgregarEditar();
            agregarEditar.UpdateDataGridView += FormNuevo_UpdateDataGridView;
            agregarEditar.ShowDialog();
        }
    }
}
