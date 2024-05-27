using DataLayer;
using DataLayer.MODELOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace General.GUI.GESTION_USUARIOS
{
    public partial class AddEdit : Form
    {
        List<EmpleadoModel> empleados = new List<EmpleadoModel> ();
        List<RolModel> roles = new List<RolModel>();
        bool isEdit = false;
        UsuarioModel newUsuario = new UsuarioModel();


        public delegate void UpdateDataGridViewEventHandler(object sender, EventArgs e);


        public event UpdateDataGridViewEventHandler UpdateDataGridView;
        public AddEdit()
        {
            InitializeComponent();
            fillEmpleadosCombo();
            fillRolCombo();
        }

        public void setUsuario(UsuarioModel rol)
        {
            this.newUsuario = rol;
            this.txbNombre.Text = this.newUsuario.Usuario;
            this.txbClave.Text = this.newUsuario.Clave;
            fillEmpleadosCombo ();
            fillRolCombo ();

        }

        public void isEditForm(bool isedit)
        {
            this.isEdit = isedit;
            if (isEdit )
            {
                this.Text = "Editar";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        public void fillEmpleadosCombo()
        {
            empleados = Consultas.OBTENER_EMPLEADOS();
            cmbEmpleados.Items.Clear();

            cmbEmpleados.Items.Add("Seleccionar");

            int index = 0;
            int count = 0;

            foreach (EmpleadoModel p in empleados)
            {
                //if (isEdit)
                //{
                    if(newUsuario != null)
                {
                    if (newUsuario.ID_Empleado == p.ID_Empleado)
                    {
                        index = count + 1;
                    }
                }

                //}
                
                cmbEmpleados.Items.Add(p.ID_Empleado + " - " + p.Nombres + " " + p.Apellidos);
                count++;
            }
            cmbEmpleados.SelectedIndex = index;
        }

        public void fillRolCombo()
        {
            roles = Consultas.OBTENER_ROLES();
            cmbRol.Items.Clear();

            cmbRol.Items.Add("Seleccionar");

            int index = 0;
            int count = 0;

            foreach (RolModel p in roles)
            {
                if (newUsuario != null)
                {
                    if (newUsuario.ID_Rol == p.IdRol)
                    {
                        index = count + 1;
                    }
                }
                cmbRol.Items.Add(p.IdRol + " - " + p.Rol);
            }
            cmbRol.SelectedIndex = index;
        }


        private void AddEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                EditarUsuario();
            }
            else
            {
                CrearUsuario();
            }
        }

        public void CrearUsuario()
        {
            try
            {
                if (!Validaciones())
                {

                    return;
                }
                newUsuario.Usuario = txbNombre.Text;
                newUsuario.Clave = txbClave.Text;
                newUsuario.ID_Rol = Convert.ToInt32(cmbRol.SelectedItem.ToString().Split('-')[0]);
                newUsuario.ID_Empleado = Convert.ToInt32(cmbEmpleados.SelectedItem.ToString().Split('-')[0]);
                Consultas.CREAR_USUARIO(newUsuario);
                MessageBox.Show("Se guardo el usuario correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar\n" + ex.Message);
            }
        }
        public void EditarUsuario()
        {
            try
            {
                if (!Validaciones())
                {

                    return;
                }
                newUsuario.Usuario = txbNombre.Text;

                    newUsuario.Clave = txbClave.Text;
                
                newUsuario.ID_Rol = Convert.ToInt32(cmbRol.SelectedItem.ToString().Split('-')[0]);
                newUsuario.ID_Empleado = Convert.ToInt32(cmbEmpleados.SelectedItem.ToString().Split('-')[0]);
                Consultas.EDITAR_USUARIO(newUsuario);
                MessageBox.Show("Se guardo el usuario correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar\n" + ex.Message);
            }
        }

        private bool Validaciones()
        {
            if (string.IsNullOrEmpty(txbNombre.Text))
            {
                MessageBox.Show("Debe de digitar el usuario");
                return false;
            }
            if (string.IsNullOrEmpty(txbClave.Text) && !isEdit)
            {
                MessageBox.Show("Debe digitar una clave");
                return false;
            }
            return true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
