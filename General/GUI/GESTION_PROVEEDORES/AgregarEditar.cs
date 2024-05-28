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

namespace General.GUI.GESTION_PROVEEDORES
{
    public partial class AgregarEditar : Form
    {
        ProveedorModel newProveedor = new ProveedorModel();
        
        bool isEdit = false;

        public delegate void UpdateDataGridViewEventHandler(object sender, EventArgs e);


        public event UpdateDataGridViewEventHandler UpdateDataGridView;

        public AgregarEditar()
        {
            InitializeComponent();
        }

        public void isEditForm(bool isedit)
        {
            this.isEdit = isedit;
            if(isEdit )
            {
                this.Text = "Editar proveedor";
            }
            else
            {
                this.Text = "Crear proveedor";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isEdit)
            {
                EditarProveedor();
            }
            else {
                AgregarProveedor();
            }
        }

        public void setProveedor(ProveedorModel p)
        {
            this.newProveedor = p;
            txbContacto.Text = p.Contacto;
            txbNIT.Text = p.Nit;
            txbProveedor.Text = p.Proveedor;
            txbDireccion.Text   = p.Direccion;
        }

        public void AgregarProveedor()
        {
            try
            {
                if (!Validaciones())
                {

                    return;
                }
                newProveedor.Contacto = txbContacto.Text;
                newProveedor.Nit = txbNIT.Text;
                newProveedor.Proveedor = txbProveedor.Text;
                newProveedor.Direccion = txbDireccion.Text;
                Consultas.AGREGAR_PROVEEDOR(newProveedor);
                MessageBox.Show("Se guardo el proveedor correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar\n" + ex.Message);
            }
        }

        public void EditarProveedor()
        {
            try
            {
                if (!Validaciones())
                {

                    return;
                }
                newProveedor.Contacto = txbContacto.Text;
                newProveedor.Nit = txbNIT.Text;
                newProveedor.Proveedor = txbProveedor.Text;
                newProveedor.Direccion = txbDireccion.Text;
                Consultas.EDITAR_PROVEEDOR(newProveedor);
                MessageBox.Show("Se guardo el proveedor correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar\n" + ex.Message);
            }
        }

        private bool Validaciones()
        {
            if (string.IsNullOrEmpty(txbContacto.Text))
            {
                MessageBox.Show("Debe de digitar el contacto");
                return false;
            }
            if (string.IsNullOrEmpty(txbDireccion.Text))
            {
                MessageBox.Show("Debe digitar la direecion");
                return false;
            }
            if (string.IsNullOrEmpty(txbNIT.Text))
            {
                MessageBox.Show("Debe de digitar el NIT");
                return false;
            }
            if (string.IsNullOrEmpty(txbProveedor.Text))
            {
                MessageBox.Show("Debe de digitar el proveedor");
                return false;
            }
            return true;
        }


    }
}
