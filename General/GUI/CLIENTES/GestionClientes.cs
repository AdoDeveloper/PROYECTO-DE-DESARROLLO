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

namespace General.GUI.CLIENTES
{
    public partial class GestionClientes : Form
    {
        public delegate void setClienteOnVentaEventHandler(object sender, EventArgs e, ClienteModel c);


        public event setClienteOnVentaEventHandler setClienteOnVenta;

        

        public GestionClientes()
        {
            InitializeComponent();
            btnSeleccionar.Visible = false;
            CargarClientes();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AgregarEditar f = new AgregarEditar();
            f.UpdateDataGridView += FormNuevo_UpdateDataGridView;
            f.setEditar(false);
            f.ShowDialog();
        }

        private void FormNuevo_UpdateDataGridView(object sender, EventArgs e)
        {
            // Aquí recargarás el DataGridView
            CargarClientes();
        }

        public void CargarClientes()
        {
            List<ClienteModel> clientes = Consultas.OBTENER_CLIENTES();
            dtgClientes.DataSource = clientes;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ClienteModel clienteSeleccionado = (ClienteModel)dtgClientes.CurrentRow.DataBoundItem;
            AgregarEditar f = new AgregarEditar();
            f.UpdateDataGridView += FormNuevo_UpdateDataGridView;
            f.setCliente(clienteSeleccionado);
            f.setEditar(true);
            f.ShowDialog();
        }

        public void isFormOpenOnVenta(bool open)
        {
            if(open)
            {
                btnSeleccionar.Visible = true;
            }
            
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            ClienteModel clienteSeleccionado = (ClienteModel)dtgClientes.CurrentRow.DataBoundItem;
            setClienteOnVenta?.Invoke(this, EventArgs.Empty, clienteSeleccionado);
            this.Close();
        }
    }
}
