using DataLayer;
using DataLayer.MODELOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI.GESTION_USUARIOS
{
    public partial class AgregarEditar : Form
    {
        UsuarioModel newUsuario = new UsuarioModel();
        Boolean esEditar = false;

        public delegate void UpdateDataGridViewEventHandler(object sender, EventArgs e);
        public event UpdateDataGridViewEventHandler UpdateDataGridView;

        public AgregarEditar()
        {
            InitializeComponent();
            CargarEmpleados();
            //CargarRoles();
        }

        private void CargarEmpleados()
        {
            List<EmpleadoModel> empleados = Consultas.OBTENER_EMPLEADOS();
            cbEmpleado.DataSource = empleados;
            cbEmpleado.DisplayMember = "Nombres";
            cbEmpleado.ValueMember = "ID_Empleado";
        }

        /*private void CargarRoles()
        {
            List<RolModel> roles = Consultas.OBTENER_ROLES();
            cbRol.DataSource = roles;
            cbRol.DisplayMember = "Nombre";
            cbRol.ValueMember = "ID_Rol";
        }*/

        public void setProducto(UsuarioModel u)
        {
            this.newUsuario = u;
            txbUsuario.Text = u.Usuario;
            txbClave.Text = u.Clave;
            cbEmpleado.SelectedValue = u.ID_Empleado;
            cbRol.SelectedValue = u.ID_Rol;

            try
            {
                pbImagen.Image = byteArrayToImage(u.Imagen);
                pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen del usuario\n " + ex.Message);
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
        }

        public void setEditar(bool edit)
        {
            esEditar = edit;
            this.Text = esEditar ? "EDITAR" : "AGREGAR";
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            opfImagen.Filter = "Archivos de imagenes | *.png; *.jpg; *.jpeg";
            try
            {
                if (opfImagen.ShowDialog() == DialogResult.OK)
                {
                    String ruta = opfImagen.FileName;
                    pbImagen.Image = Image.FromFile(ruta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la imagen");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (esEditar)
            {
                // Llamar a editarUsuario()
            }
            else
            {
                agregarUsuario();
            }
        }

        public void agregarUsuario()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                newUsuario.Usuario = txbUsuario.Text;
                newUsuario.Clave = txbClave.Text;
                newUsuario.ID_Empleado = Convert.ToInt32(cbEmpleado.SelectedValue);
                newUsuario.ID_Rol = Convert.ToInt32(cbRol.SelectedValue);

                if (pbImagen.Image != null)
                {
                    pbImagen.Image.Save(ms, ImageFormat.Png);
                    newUsuario.Imagen = ms.ToArray();
                }
                else
                {
                    newUsuario.Imagen = null; // O asigna una imagen por defecto
                }

                // Consultas.AGREGAR_USUARIO(newUsuario);
                MessageBox.Show("Se guardó el usuario correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar el usuario: " + ex.Message);
            }
        }
    }
}
