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

namespace General.GUI.GESTION_ROLES_PERMISOS
{
    public partial class GestionPermisos : Form
    {
        private Int32 IDRol;
        private List<OpcionModel> ltsOpciones = new List<OpcionModel>();
        private List<OpcionModel> ltsOpcionesRol = new List<OpcionModel>();
        public GestionPermisos(String rol, Int32 id)
        {

            InitializeComponent();
            setRol(rol, id);
            obtenerOpciones();
            obtenerOpcionesRol();
        }

        private void setRol(String rol, Int32 id)
        {
            this.rolLabel.Text = rol;
            this.IDRol = id;
        }

        private void obtenerOpciones()
        {
            ltsOpciones =  DataLayer.Consultas.OBTENER_TODAS_LAS_OPCIONES();
            dtgPermisos.DataSource = ltsOpciones;
        }

        private void obtenerOpcionesRol()
        {
            ltsOpcionesRol = DataLayer.Consultas.OBTENER_OPCIONES_ROL(this.IDRol);
            dtgAsignados.DataSource = ltsOpcionesRol;
            dtgAsignados.Refresh();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 opcionDelete = Convert.ToInt32(dtgPermisos.CurrentRow.Cells["IDOpcion"].Value.ToString());
            var exists = ltsOpcionesRol.Where(opc => opc.IDOpcion == opcionDelete);

            if (!exists.Any())
            {
                MessageBox.Show("No existe permiso para elminar");
            }
            else
            {
                DataLayer.Consultas.ELIMINAR_OPCION_ROL(this.IDRol, opcionDelete);
                MessageBox.Show("El permiso se elimino correctamente");
                obtenerOpcionesRol();

            }
        }

            private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Int32 opcionAgg = Convert.ToInt32( dtgPermisos.CurrentRow.Cells["IDOpcion"].Value.ToString() );
            var exists = ltsOpcionesRol.Where(opc => opc.IDOpcion == opcionAgg);

            if (exists.Any())
            {
                MessageBox.Show("El permiso ya esta agregado al rol");
            }
            else
            {
                DataLayer.Consultas.AGREGAR_OPCION_ROL(this.IDRol, opcionAgg);
                MessageBox.Show("El permiso se agrego correctamente");
                obtenerOpcionesRol();
            }
        }
    }
}
