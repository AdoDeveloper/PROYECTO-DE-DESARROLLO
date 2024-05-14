using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class DBConexion
    {
        //Atributo
        protected MySqlConnection _CONEXION= new MySqlConnection();

        protected Boolean Conectar()
        {
            Boolean Resultado = true;
            try
            {
                _CONEXION.ConnectionString = "Server=localhost;Port=3306;Database=sistema;Uid=root;Pwd=12345; SSL Mode=None";
                _CONEXION.Open();
                Resultado = true;
            }

            catch(Exception) {
                Resultado = false;
            }
            return Resultado;
        }
        protected void Desconectar()
        {
            try
            {
                if (_CONEXION.State==System.Data.ConnectionState.Open)
                {
                    _CONEXION.Close();
                }
            }
            catch(Exception)
            {

            }
        }
    }
}
