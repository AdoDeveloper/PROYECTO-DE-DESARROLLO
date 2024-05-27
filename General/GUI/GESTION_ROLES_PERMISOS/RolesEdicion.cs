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
    
    public partial class RolesEdicion : Form
    {
        bool isEditar = true;

        public delegate void UpdateDataGridViewEventHandler(object sender, EventArgs e);


        public event UpdateDataGridViewEventHandler UpdateDataGridView;

        private Boolean Validar()
        {
            Boolean Valido = true;
            try
            {

                if (txbRol.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbRol, "Este campo no puede quedar vacio");
                    Valido = false;
                }
            }
            catch (Exception)
            {
                Valido = false;
             
            }
            return Valido;
        }
        public RolesEdicion()
        {
            InitializeComponent();
        }

        public void isEditForm(bool ok)
        {
            this.isEditar = ok;
            if (isEditar)
            {
                this.Text = "Editar Rol";
                
            }
            else
            {
                this.label1.Visible = false;
                this.txbIDRol.Visible = false;
                this.Text = "Crear Rol";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                //CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                CLS.Roles oRol = new CLS.Roles();
                //SINCRONIZAMOS EL OBJETO CON LA GUI

                if (isEditar)
                {
                    if (Validar())
                    {
                    
                            oRol.IDRol = Convert.ToInt32(txbIDRol.Text);
                        
                            oRol.Rol = txbRol.Text;

                            //ACTUALIZAR REGISTRO
                            if (oRol.Actualizar())
                            {
                                MessageBox.Show("Registro Actualizado");
                                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                            Close();
                            }
                            else
                            {
                                MessageBox.Show("El registro no pude ser actualizado");
                            }

                    }
                    else
                    {
                        MessageBox.Show("Debe llenar los campos");
                    }
                }
                else
                {
                    if (Validar())
                    {

                        

                        oRol.Rol = txbRol.Text;
                        if (oRol.Insertar())
                        {
                            MessageBox.Show("Registro Guardado");
                            UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pude ser almacenado");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe llenar los campos");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void RolesEdicion_Load(object sender, EventArgs e)
        {

        }

        private void txbRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbIDRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
