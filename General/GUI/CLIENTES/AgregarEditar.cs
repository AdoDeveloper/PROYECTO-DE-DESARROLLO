using DataLayer;
using DataLayer.MODELOS;
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
    public partial class AgregarEditar : Form
    {
        ClienteModel newCliente = new ClienteModel();

        Boolean esEditar = false;

        public delegate void UpdateDataGridViewEventHandler(object sender, EventArgs e);


        public event UpdateDataGridViewEventHandler UpdateDataGridView;

        public AgregarEditar()
        {
            InitializeComponent();
        }

        public void setCliente(ClienteModel c)
        {   
            this.newCliente = c;
            txbNombre.Text = this.newCliente.Cliente;
            txbTelefono.Text = this.newCliente.Telefono;
            txbCorreo.Text = this.newCliente.Correo;
            txbDUI.Text = this.newCliente.Dui;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (esEditar)
            {
                EditarCliente();
            }
            else
            {
                AgregarCliente();
            }
        }

        public void EditarCliente()
        {
            try
            {
                newCliente.Cliente = txbNombre.Text;
                newCliente.Telefono = txbTelefono.Text;
                newCliente.Correo = txbCorreo.Text;
                newCliente.Dui = txbDUI.Text;
                Consultas.EDITAR_CLIENTE(newCliente);
                MessageBox.Show("Se guardo el cliente correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar\n" + ex.Message);
            }
        }

        public void AgregarCliente()
        {
            try
            {
                newCliente.Cliente = txbNombre.Text;
                newCliente.Telefono = txbTelefono.Text;
                newCliente.Correo = txbCorreo.Text;
                newCliente.Dui  = txbDUI.Text;
                Consultas.AGREGAR_CLIENTE(newCliente);
                MessageBox.Show("Se guardo el cliente correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar\n" + ex.Message);
            }
        }


        public void setEditar(bool edit)
        {
            esEditar = edit;
            if (esEditar)
            {
                this.Text = "EDITAR";
            }
            else
            {
                this.Text = "AGREGAR";
            }
        }
    }
}
