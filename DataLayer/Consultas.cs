using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public static class Consultas
    {
        public static DataTable ROLES()
        {
            DataTable Resultado = new DataTable();

            String Consulta = @"SELECT IDRol, Rol FROM roles ORDER BY Rol ASC;";
            DBOperacion operacion = new DBOperacion();

            try
            {
                Resultado = operacion.Consultar(Consulta);

            }
            catch (Exception)
            {

             
            }

            return Resultado;
        }

        public static DataTable EMPLEADOS()
        {
            DataTable Resultado = new DataTable();

            String Consulta = @"SELECT IDEmpleado, Nombres, Apellidos FROM empleados ORDER BY Nombres ASC;";
            DBOperacion operacion = new DBOperacion();

            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception)
            {
                // Manejar la excepción si es necesario
            }

            return Resultado;
        }


        public static DataTable ORDENES_SEGUN_PERIODO(string pFechaInicio, string pFechaFinal)
        {
            DataTable Resultado = new DataTable();

            String Consulta = @"select a.OrderID, a.OrderDate, b.CompanyName, 
                                CONCAT(c.FirstName,' ',c.LastName) Empleado,
                                SUM(d.UnitPrice*d.Quantity) SubTotal,
                                SUM(d.Discount*(d.UnitPrice*d.Quantity)) Descuento,
                                SUM(d.UnitPrice*d.Quantity*(1-d.Discount)) Total
                                from orders a
                                inner join customers b on b.CustomerID = a.CustomerID
                                inner join employees c on c.EmployeeID = a.EmployeeID
                                inner join orderdetails d on d.OrderID = a.OrderID
                                WHERE CAST(a.OrderDate AS DATE) between '"+pFechaInicio+"' AND '"+pFechaFinal+@"';
                                group by a.OrderID;";
            DBOperacion operacion = new DBOperacion();

            try
            {
                Resultado = operacion.Consultar(Consulta);

            }
            catch (Exception)
            {


            }

            return Resultado;
        }
    }
}
