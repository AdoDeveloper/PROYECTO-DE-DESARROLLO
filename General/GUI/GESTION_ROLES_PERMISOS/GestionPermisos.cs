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
            List<OpcionModel> lts =  DataLayer.Consultas.OBTENER_TODAS_LAS_OPCIONES();
            dtgPermisos.DataSource = lts;
        }

        private void obtenerOpcionesRol()
        {
            List<OpcionModel> lts = DataLayer.Consultas.OBTENER_OPCIONES_ROL(this.IDRol);
            dtgAsignados.DataSource = lts;
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

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
