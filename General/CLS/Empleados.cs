using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace General.CLS
{
    public class Empleados
    {
        Int32 _IDEmpleado;
        String _Nombres;
        String _Apellidos;

        public int IDEmpleado { get => _IDEmpleado; set => _IDEmpleado = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            StringBuilder Sentencia = new StringBuilder();

            Sentencia.Append("INSERT INTO empleados(Nombres, Apellidos) VALUES (");
            Sentencia.Append("'" + _Nombres + "', ");
            Sentencia.Append("'" + _Apellidos + "');");

            try
            {
                if (Operacion.EjecutarSetencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }

            return Resultado;
        }

        public Boolean Actualizar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            StringBuilder Sentencia = new StringBuilder();

            Sentencia.Append("UPDATE empleados SET ");
            Sentencia.Append("Nombres='" + _Nombres + "', ");
            Sentencia.Append("Apellidos='" + _Apellidos + "' ");
            Sentencia.Append("WHERE IDEmpleado=" + _IDEmpleado + ";");

            try
            {
                if (Operacion.EjecutarSetencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }

            return Resultado;
        }

        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            StringBuilder Sentencia = new StringBuilder();

            Sentencia.Append("DELETE FROM empleados ");
            Sentencia.Append("WHERE IDEmpleado=" + _IDEmpleado + ";");

            try
            {
                if (Operacion.EjecutarSetencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }

            return Resultado;
        }
    }
}