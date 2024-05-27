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
            lblRol.Text = oSesion.Rol;
            lblConexion.Text = oSesion.Conexion;
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
                case 8:
                    General.GUI.VENTAS.RealizarVenta v = new General.GUI.VENTAS.RealizarVenta();
                    v.ShowDialog();
                    break;
                case 9:
                    
                    General.GUI.RolesGestion f = new General.GUI.RolesGestion();
                    f.ShowDialog();
                    break;
                case 12:
                    
                   General.GUI.PRODUCTOS.GestionProductos fd = new General.GUI.PRODUCTOS.GestionProductos();
                    fd.ShowDialog();
                    break;
                case 20:

                    General.GUI.GESTION_EMPLEADOS.GestionEmpleados empleados = new General.GUI.GESTION_EMPLEADOS.GestionEmpleados();
                    empleados.ShowDialog();
                    break;
                case 24:

                    General.GUI.CLIENTES.GestionClientes c = new General.GUI.CLIENTES.GestionClientes();
                    c.ShowDialog();
                    break;
                case 29:

                    General.GUI.GESTION_USUARIOS.GestionUsuarios usuarios = new General.GUI.GESTION_USUARIOS.GestionUsuarios();
                    usuarios.ShowDialog();
                    break;
                case 35:

                    Reportes.GUI.Ventas reporte = new Reportes.GUI.Ventas();
                    reporte.ShowDialog();
                    break;
                case 36:

                    General.GUI.ACERCADE.About about = new General.GUI.ACERCADE.About();
                    about.ShowDialog();
                    break;
                default:
                    
                    break;
            }
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oSesion.ValidarPermiso(1))
                {
                    General.GUI.GESTION_EMPLEADOS.GestionEmpleados f = new General.GUI.GESTION_EMPLEADOS.GestionEmpleados();
                    f.MdiParent = this;
                    f.Show();
                }

            }
            catch (Exception)
            {


            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oSesion.ValidarPermiso(1))
                {
                    General.GUI.GESTION_USUARIOS.GestionUsuarios f = new General.GUI.GESTION_USUARIOS.GestionUsuarios();
                    f.MdiParent = this;
                    f.Show();
                }

            }
            catch (Exception)
            {


            }
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form != this)
                {
                    form.Close();
                }
            }
            Application.Exit();
        }


        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.GUI.Ventas f = new Reportes.GUI.Ventas();
            f.MdiParent = this;
            f.Show();
        }
    }
}
