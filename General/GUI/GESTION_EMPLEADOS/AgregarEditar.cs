using DataLayer;
using DataLayer.MODELOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI.GESTION_EMPLEADOS
{
    public partial class AgregarEditar : Form
    {
        EmpleadoModel newEmpleado = new EmpleadoModel();
        Boolean esEditar = false;


        public delegate void UpdateDataGridViewEventHandler(object sender, EventArgs e);


        public event UpdateDataGridViewEventHandler UpdateDataGridView;


        public AgregarEditar()
        {
            InitializeComponent();
        }

        public void setEmpleado(EmpleadoModel e)
        {
            this.newEmpleado = e;
            txbNombres.Text = e.Nombres;
            txbApellidos.Text = e.Apellidos;
            txbDUI.Text = e.DUI;
            txbDireccion.Text = e.Direccion;
            txbTelefono.Text = e.Telefono;
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

        public void agregarEmpleado()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                
                newEmpleado.Nombres = txbNombres.Text;
                newEmpleado.Apellidos = txbApellidos.Text;
                newEmpleado.DUI = txbDUI.Text;
                newEmpleado.Direccion = txbDireccion.Text;
                newEmpleado.Telefono = txbTelefono.Text;
                
                Consultas.AGREGAR_EMPLEADO(newEmpleado);
                MessageBox.Show("Se guardo el empleado correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar el empleado");
            }
        }

        public void editarEmpleado()
        {
            try
            {
                newEmpleado.Nombres = txbNombres.Text;
                newEmpleado.Apellidos = txbApellidos.Text;
                newEmpleado.DUI = txbDUI.Text;
                newEmpleado.Direccion = txbDireccion.Text;
                newEmpleado.Telefono = txbTelefono.Text;
                Consultas.EDITAR_EMPLEADO(newEmpleado);
                MessageBox.Show("Se guardo el empleado correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar el empleado");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (esEditar)
            {
                this.editarEmpleado();
            }
            else
            {
                this.agregarEmpleado();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
