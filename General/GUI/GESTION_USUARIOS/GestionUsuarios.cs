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
using System.IO;

namespace General.GUI.GESTION_USUARIOS
{
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }
        public int ContarRegistros()
        {
            return dtgUsuarios.Rows.Count;
        }

        private void FormNuevo_UpdateDataGridView(object sender, EventArgs e)
        {
            // Aquí recargarás el DataGridView
            CargarUsuarios();
        }
        public void CargarUsuarios()
        {
            try
            {
                List<UsuarioModel> usuarioModels = Consultas.OBTENER_USUARIOS();
                dtgUsuarios.DataSource = usuarioModels;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            int totalRegistros = ContarRegistros();
            lblContador.Text = $": {totalRegistros}";
        }
        // Método para convertir los bytes de imagen en un objeto Image
public Image byteArrayToImage(byte[] byteArrayIn)
{
    if (byteArrayIn == null || byteArrayIn.Length == 0)
    {
        // Retorna null si los bytes de imagen son nulos o vacíos
        return null;
    }

    System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
    Image img = (Image)converter.ConvertFrom(byteArrayIn);

    return img;
}

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddEdit f = new AddEdit();
            f.UpdateDataGridView += FormNuevo_UpdateDataGridView;
            f.ShowDialog(); 
            CargarUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            UsuarioModel usuario = (UsuarioModel)dtgUsuarios.CurrentRow.DataBoundItem;
            AddEdit f = new AddEdit();
            f.UpdateDataGridView += FormNuevo_UpdateDataGridView;
            f.setUsuario(usuario);
            f.isEditForm(true);
            f.ShowDialog();
            CargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea ELIMINAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    
                    int id = Convert.ToInt32(dtgUsuarios.CurrentRow.Cells["ID_Usuario"].Value.ToString());
                    Consultas.ELIMINAR_USUARIO(id);
                    MessageBox.Show("Registro eliminado");
                    
                    
                    CargarUsuarios();
                }
            }
            catch (Exception)
            {


            }
        }
    }
}
