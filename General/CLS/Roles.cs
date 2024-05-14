using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Roles
    {
        Int32 _IDRol;
        String _Rol;

        //ctrl r e
        //
        public int IDRol { get => _IDRol; set => _IDRol = value; }
        public string Rol { get => _Rol; set => _Rol = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            //crando el obejto
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            //permiten construir cadenas los stringBuilder
            StringBuilder Setencia = new StringBuilder();

            Setencia.Append("INSERT INTO roles(rol) VALUES (");
            Setencia.Append("'" + _Rol + "');");

            try 
            {
                if (Operacion.EjecutarSetencia(Setencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else {
                    Resultado = false;
                }
                    
            }
            catch (Exception)
            {
                Resultado |= false;
            }

            return Resultado;
        }

        public Boolean Actualizar()
        {
            Boolean Resultado = false;
            //crando el obejto
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            //permiten construir cadenas los stringBuilder

            StringBuilder Setencia = new StringBuilder();
            Setencia.Append("UPDATE roles SET ");
            Setencia.Append("rol='" + _Rol + "'");
            Setencia.Append("WHERE IDRol =" + _IDRol + ";");

            try
            {
                if (Operacion.EjecutarSetencia(Setencia.ToString()) >= 0)
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
            //crando el obejto
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            //permiten construir cadenas los stringBuilder

            StringBuilder Setencia = new StringBuilder();
            Setencia.Append("DELETE FROM roles ");       
            Setencia.Append("WHERE IDRol =" + _IDRol + ";");

            try
            {
                if (Operacion.EjecutarSetencia(Setencia.ToString()) >= 0)
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
