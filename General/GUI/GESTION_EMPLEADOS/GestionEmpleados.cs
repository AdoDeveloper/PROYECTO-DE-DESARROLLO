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

        public void CargarEmpleados()
        {
            List<EmpleadoModel> productoModels = Consultas.OBTENER_EMPLEADOS();
            dtgEmpleados.DataSource = productoModels;

        }
    }
}
