using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI
{
    public partial class EmpleadosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();

        private void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.EMPLEADOS();
                dataGridView1.DataSource = _DATOS;
               // FiltrarLocalmente();

            }
            catch (Exception)
            {

            }
        }
        public EmpleadosGestion()
        {
            InitializeComponent();
            Cargar();
        }

        private void EmpleadosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
