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

  

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Validar())
                {
                    //CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                    CLS.Roles oRol = new CLS.Roles();
                    //SINCRONIZAMOS EL OBJETO CON LA GUI
                   
                    try
                    {
                        oRol.IDRol = Convert.ToInt32(txbIDRol.Text);
                    }
                    catch (Exception)
                    {

                        oRol.IDRol = 0;
                    }
                    oRol.Rol = txbRol.Text;
                    //PROCEDER
                    if(txbIDRol.Text.Trim().Length == 0)
                    {
                        //GUARDAR NUEVO REGISTROS
                        if (oRol.Insertar())
                        {
                            MessageBox.Show("Registro Guardado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pude ser almacenado");
                        }
                    }
                    else
                    {
                        //ACTUALIZAR REGISTRO
                        if (oRol.Actualizar())
                        {
                            MessageBox.Show("Registro Actualizado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pude ser actualizado");
                        }
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
