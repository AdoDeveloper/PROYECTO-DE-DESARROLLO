using DataLayer.MODELOS;
using General.CLS;
using SDV.CLS;
using SDV.Properties;
using SesionManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
            generarOpciones();

        }

        public void generarOpciones()
        {
            Sesion oSesion = Sesion.ObtenerInstancia();
            List<OpcionModel> ltsOpciones = oSesion.ObtenerOpciones();

            foreach (OpcionModel opcion in ltsOpciones)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(opcion.Opcion);
                if (opcion.IDPadre == -1)
                {
                    item.Image = IconManager.obtenerIconPorOpcion(opcion.IDOpcion);
                    item.Click += (sender, e) => MenuItem_Click(sender, e, opcion.IDOpcion);
                    if (opcion.Submenu == 1)
                    {

                        foreach (OpcionModel sub in opcion.SubOpciones)
                        {
                            ToolStripMenuItem item2 = new ToolStripMenuItem(sub.Opcion);
                            item2.Image = IconManager.obtenerIconPorOpcion(sub.IDOpcion);
                            item2.Click += (sender, e) => MenuItem_Click(sender, e, sub.IDOpcion);
                            item.DropDownItems.Add(item2);  

                        }

                    }

                    MainMenuStrip.Items.Add(item);

                }
                
                

                
            }
        }

        private void MenuItem_Click(object sender, EventArgs e, Int32 IDOpcion)
        {
            switch (IDOpcion)
            {
                case 5:

                    break;
                case 9:
                    // Abre la ventana de usuario
                    General.GUI.RolesGestion f = new General.GUI.RolesGestion();
                    f.ShowDialog();
                    break;
                
                default:
                    
                    break;
            }
        }
    }
}
