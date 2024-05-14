using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDV.GUI
{
    public partial class Login : Form
    {
        //Atributo
        private Boolean _Autorizado = false;
        //para hacer una propieda hay que hacer primero un atributo
        //esta es la propiedad
        //se le borra lo demas para que solo se pueda leer crt+r+e
        public bool Autorizado { get => _Autorizado; }

        //String _Usuario = "Gaby";
        //String _Clave = "12345";
        public Login()
        {
            InitializeComponent();
        }

     

        private void Login_Load(object sender, EventArgs e)
        {
            txbUsuario.Text = "Gaby";
            txbClave.Text = "12345";
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DataLayer.DBOperacion oOperacion = new DataLayer.DBOperacion();
            DataTable dt = new DataTable();
            string query = @"SELECT usuario
                IDUsuario, usuario,
                IDEmpleado, IDRol
                FROM usuarios
                WHERE usuario = '" + txbUsuario.Text + @"'
                AND Clave = MD5('" + txbClave.Text + @"');";

            dt = oOperacion.Consultar(query);
            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
                    oSesion.Usuario = txbUsuario.Text;
                    _Autorizado = true;
                    this.Close();
                }
                else
                {
                    _Autorizado = false;
                    lblMensaje.Text = "Usuario o Clave incorrectos";
                }
            }
            else
            {
                _Autorizado = false;
                lblMensaje.Text = "Usuario o Clave incorrectos";
            }


        }

       
    }
}
