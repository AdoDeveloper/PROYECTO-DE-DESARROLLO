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
        public void CargarUsuarios()
        {
            try
            {
                List<UsuarioModel> usuarioModels = Consultas.OBTENER_USUARIOS();
                dtgUsuarios.DataSource = usuarioModels;

                // Configurar la columna Imagen como tipo de celda de imagen
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "Imagen";
                imgColumn.HeaderText = "Imagen";
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dtgUsuarios.Columns.Add(imgColumn);

                // Ocultar la columna de byte[] y vincular la imagen o el texto a la columna de imagen
                foreach (DataGridViewRow row in dtgUsuarios.Rows)
                {
                    if (row.Cells["Imagen"].Value != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])row.Cells["Imagen"].Value;
                        row.Cells["Imagen"].Value = byteArrayToImage(imgBytes);
                    }
                    else
                    {
                        // Si la imagen es null, mostrar el texto "Sin imagen"
                        row.Cells["Imagen"].Value = "Sin imagen";
                    }
                }

                // Ocultar la columna de bytes de imagen original
                dtgUsuarios.Columns["Imagen"].Visible = false;
                dtgUsuarios.Columns["Clave"].Visible = false;
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
           // AgregarEditar f = new AgregarEditar();
            //f.setEditar(false);
            //f.ShowDialog();
            CargarUsuarios();
        }
    }
}
