using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDV.GUI
{
    public partial class Principal : Form
    {
        SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
        public Principal()
        {
            InitializeComponent();
        }

       

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oSesion.ValidarPermiso(1))
                {
                    General.GUI.RolesGestion f = new General.GUI.RolesGestion();
                    f.MdiParent = this;
                    f.Show();
                }
               
            }
            catch (Exception)
            {

                
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = oSesion.Usuario;
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oSesion.ValidarPermiso(1))
                {
                    General.GUI.EmpleadosGestion f = new General.GUI.EmpleadosGestion();
                    f.MdiParent = this;
                    f.Show();
                }

            }
            catch (Exception)
            {


            }
        }
    }
}
