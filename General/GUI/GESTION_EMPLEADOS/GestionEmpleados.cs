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

namespace General.GUI.GESTION_EMPLEADOS
{
    public partial class GestionEmpleados : Form
    {
        public GestionEmpleados()
        {
            InitializeComponent();
            CargarEmpleados();
            

        }
        public int ContarRegistros()
        {
            return dtgEmpleados.Rows.Count;
        }
        public void CargarEmpleados()
        {
            List<EmpleadoModel> productoModels = Consultas.OBTENER_EMPLEADOS();
            dtgEmpleados.DataSource = productoModels;
            int totalRegistros = ContarRegistros();
            lblContador.Text = $": {totalRegistros}";

        }

        private void FiltrarEmpleados(string filtro)
        {
            try
            {
                List<EmpleadoModel> empleadosFiltrados = Consultas.FILTRAR_EMPLEADOS(filtro);
                dtgEmpleados.DataSource = empleadosFiltrados;
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
            FiltrarEmpleados(filtro.ToLower());
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditar f = new AgregarEditar();
            f.setEditar(false);
            f.ShowDialog();
            CargarEmpleados();
           
        }
      
     
        private void btnEditar_Click(object sender, EventArgs e)
        {
            AgregarEditar f = new AgregarEditar();
            EmpleadoModel empleadoSeleccionado = (EmpleadoModel)dtgEmpleados.CurrentRow.DataBoundItem;

            empleadoSeleccionado = Consultas.OBTENER_EMPLEADO(empleadoSeleccionado.ID_Empleado);

            f.setEditar(true);
            f.setEmpleado(empleadoSeleccionado);
            f.ShowDialog();
            CargarEmpleados();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EmpleadoModel empleadoSeleccionado = (EmpleadoModel)dtgEmpleados.CurrentRow.DataBoundItem;

            try
            {
                Consultas.ELIMINAR_EMPLEADO(empleadoSeleccionado.ID_Empleado);
                MessageBox.Show("Empleado eliminado con exito");
                CargarEmpleados();
            }
            catch
            {
                MessageBox.Show("Hubo un error al eliminar el empleado");
            }
        }


    }
}
