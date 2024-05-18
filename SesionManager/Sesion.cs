using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer.MODELOS;


namespace SesionManager
{
    public class Sesion
    {
        private static Sesion _instance;
        private static readonly object _lock = new object();

        String _Usuario;
        String _IDRol;
        
        



        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string IDRol { get => _IDRol; set => _IDRol = value; }


        public static Sesion ObtenerInstancia()
        {
            if(_instance == null)
            {
                lock (_lock){
                    if(_instance == null)
                    {
                        _instance = new Sesion();
                    }
                }
            }
            return _instance;
        }

        private Sesion()
        {

        }

        public bool ValidarPermiso(int pIDOpcion)
        {
            bool result = false;

            DataTable Resultado = new DataTable();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("SELECT a.IDOpcion, c.Opcion FROM permisos a ");
            Sentencia.Append("INNER JOIN usuarios b ON b.IDRol = a.IDRol ");
            Sentencia.Append("INNER JOIN opciones c ON c.IDOpcion = a.IDOpcion ");
            Sentencia.Append("WHERE b.Usuario = '" + _Usuario + "'");
            Sentencia.Append("AND a.IDOpcion = " + pIDOpcion.ToString() + ";");

            DataLayer.DBOperacion operacion = new DataLayer.DBOperacion();
            Resultado = operacion.Consultar(Sentencia.ToString());

            if (Resultado.Rows.Count > 0)
            {
                result = true;
            }
            else
            {
                // El usuario no tiene permiso, muestra un mensaje
                MessageBox.Show("Acceso Denegado", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);

            }

            return result;
        }

        public List<OpcionModel> ObtenerOpciones()
        {
            List<OpcionModel> lstOpciones = new List<OpcionModel>();
            String Sentencia = "select o.* \r\nfrom opciones o \r\ninner join permisos p on p.IDOpcion  = o.IDOpcion and p.IDRol = " + IDRol;
            DataTable Resultado = new DataTable();

            try
            {
                DataLayer.DBOperacion operacion = new DataLayer.DBOperacion();
                Resultado = operacion.Consultar(Sentencia);

                if (Resultado.Rows.Count > 0)
                {
                    for (int i = 0; i < Resultado.Rows.Count; i++)
                    {
                        Int32 id = Convert.ToInt32(Resultado.Rows[i]["IDOpcion"]);
                        String opc = Convert.ToString(Resultado.Rows[i]["Opcion"]);
                        int idPadre = Resultado.Rows[i]["IDPadre"] != DBNull.Value ? Convert.ToInt32(Resultado.Rows[i]["IDPadre"]) : -1;
                        Int32 submenu = Convert.ToInt32(Resultado.Rows[i]["submenu"]);
                        
                        List<OpcionModel> subOpciones = new List<OpcionModel>();

                        if(submenu == 1)
                        {
                            subOpciones = ObtenerSubOpciones(id);
                        }
                        lstOpciones.Add(new OpcionModel(id, opc,idPadre,submenu,subOpciones));

                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Hubo un error y", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
            }
            return lstOpciones;
        }

        public List<OpcionModel> ObtenerSubOpciones(Int32 IDopc)
        {
            List<OpcionModel> lstOpciones = new List<OpcionModel>();
            String Sentencia = "select o.* \r\nfrom opciones o \r\n where IDPadre = " + IDopc;
            DataTable Resultado = new DataTable();

            try
            {
                DataLayer.DBOperacion operacion = new DataLayer.DBOperacion();
                Resultado = operacion.Consultar(Sentencia);

                if (Resultado.Rows.Count > 0)
                {
                    for (int i = 0; i < Resultado.Rows.Count; i++)
                    {
                        lstOpciones.Add(new OpcionModel(

                           Convert.ToInt32(Resultado.Rows[i]["IDOpcion"]),
                           Convert.ToString(Resultado.Rows[i]["Opcion"]),
                           (Resultado.Rows[i]["IDPadre"] != DBNull.Value ? Convert.ToInt32(Resultado.Rows[i]["IDPadre"]) : -1),
                           Convert.ToInt32(Resultado.Rows[i]["submenu"]),
                           new List<OpcionModel>()

                         ));

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Hubo un error x", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
            }
            return lstOpciones;
        }
    }
    
}
