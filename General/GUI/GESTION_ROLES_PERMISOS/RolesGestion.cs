﻿using General.GUI.GESTION_ROLES_PERMISOS;
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
    public partial class RolesGestion : Form
    {
        BindingSource _DATOS = new BindingSource();

        public RolesGestion()
        {

            InitializeComponent();
            Cargar();
            txbFiltro.TextChanged += (s, e) => FiltrarLocalmente();

        }
        public int ContarRegistros()
        {
            return dataGridView1.Rows.Count;
        }
        private void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.ROLES();
                FiltrarLocalmente();
                
            }
            catch (Exception)
            {
              
            }
            int totalRegistros = ContarRegistros();
            lblContador.Text = $": {totalRegistros}";
        }
  
        private void FiltrarLocalmente()
        {
            try
            {
                string filtro = txbFiltro.Text.Trim();
                _DATOS.Filter = string.IsNullOrEmpty(filtro) ? "" : $"Rol LIKE '%{filtro}%'";

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _DATOS;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al filtrar los datos: {ex.Message}");
            }
        }

        private void RolesGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Desea EDITAR el registro seleccionado?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RolesEdicion oRol = new RolesEdicion();
                    oRol.txbIDRol.Text = dataGridView1.CurrentRow.Cells["IDRol"].Value.ToString();
                    oRol.txbRol.Text = dataGridView1.CurrentRow.Cells["Rol"].Value.ToString();
                    oRol.ShowDialog();
                    Cargar();
                }
            }
            catch (Exception)
            {

               
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea ELIMINAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CLS.Roles oRol = new CLS.Roles();
                    oRol.IDRol = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDRol"].Value.ToString());
                    if (oRol.Eliminar())
                    {
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    {
                        MessageBox.Show("El registro NO fue eliminado");
                    }
                    Cargar();
                }
            }
            catch (Exception)
            {


            }
        }

        private void FormNuevo_UpdateDataGridView(object sender, EventArgs e)
        {
            // Aquí recargarás el DataGridView
            Cargar();
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Selected)
            {
                String rol = dataGridView1.CurrentRow.Cells["Rol"].Value.ToString();
                Int32 id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDRol"].Value.ToString());
                GestionPermisos gp = new GestionPermisos(rol,id);
                
                gp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un item");
            }

        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RolesEdicion oRol = new RolesEdicion();
            oRol.UpdateDataGridView += FormNuevo_UpdateDataGridView;
            oRol.isEditForm(false);
            oRol.ShowDialog();
        }

        private void RolesGestion_Load_1(object sender, EventArgs e)
        {

        }
    }
}
