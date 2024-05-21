using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class DBOperacion: DBConexion
    {

        public MySqlCommand Comando = new MySqlCommand();

        public DataTable Consultar(String pConsulta)
        {
            DataTable Resultado = new DataTable();
            MySqlDataAdapter Adaptador = new MySqlDataAdapter();
            //MySqlCommand Comando = new MySqlCommand(); 

            try {
                if (base.Conectar())
                {
                    Comando.Connection = base._CONEXION;
                    Comando.CommandType=System.Data.CommandType.Text;
                    Comando.CommandText = pConsulta;
                    Adaptador.SelectCommand = Comando;
                    Adaptador.Fill(Resultado);
                    base.Desconectar();
                }
            }
            catch(Exception ex) { 
                Resultado = new DataTable();
                
            }
            return Resultado;
        }

        public Int32 EjecutarSetencia(String pSetencia)
        {
            Int32 FilasAfectadas = 0;
            //MySqlCommand Comando=new MySqlCommand();

            try
            {
                if (base.Conectar())
                {
                    Comando.Connection=base._CONEXION;
                    Comando.CommandType= System.Data.CommandType.Text;
                    Comando.CommandText = pSetencia;
                    FilasAfectadas = Comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                FilasAfectadas = -1;
                Console.WriteLine(e.Message);
            }
            return FilasAfectadas;
        }
    }

}
