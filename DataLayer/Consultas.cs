using DataLayer.MODELOS;
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

        public static List<OpcionModel> OBTENER_TODAS_LAS_OPCIONES()
        {
            List<OpcionModel> lts = new List<OpcionModel>(); 

            String Consulta = "select IDOpcion, Opcion from opciones;";

            DBOperacion operacion = new DBOperacion();
            try
            {
                DataTable dt = new DataTable();
                dt = operacion.Consultar(Consulta);
                
                if (dt.Rows.Count > 0)
                {
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        OpcionModel op = new OpcionModel();
                        op.IDOpcion = Convert.ToInt32( dt.Rows[i]["IDOpcion"] );
                        op.Opcion = Convert.ToString(dt.Rows[i]["Opcion"]);
                        

                        lts.Add(op);
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return lts;
        }

        public static List<OpcionModel> OBTENER_OPCIONES_ROL(Int32 id)
        {
            List<OpcionModel> lts = new List<OpcionModel>();

            String Consulta = "select op.IDOpcion, op.Opcion  from opciones op\r\ninner join permisos p on p.IDOpcion  = op.IDOpcion \r\nwhere p.IDRol = " + id ;

            DBOperacion operacion = new DBOperacion();
            try
            {
                DataTable dt = new DataTable();
                dt = operacion.Consultar(Consulta);
                Console.WriteLine(id);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Console.WriteLine(dt.Rows[i]["Opcion"]);
                        OpcionModel op = new OpcionModel();
                        op.IDOpcion = Convert.ToInt32(dt.Rows[i]["IDOpcion"]);
                        op.Opcion = Convert.ToString(dt.Rows[i]["Opcion"]);


                        lts.Add(op);
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return lts;
        }

        public static void AGREGAR_OPCION_ROL(Int32 rol, Int32 opc)
        {
            try
            {
                
                DBOperacion operacion = new DBOperacion();
                String consulta = "INSERT INTO permisos(IDRol,IDOpcion) values ("+rol+", "+opc+")";
                operacion.EjecutarSetencia(consulta);

            }catch(Exception e)
            {
               
            }
        }

        public static void ELIMINAR_OPCION_ROL(Int32 rol, Int32 opc)
        {
            try
            {

                DBOperacion operacion = new DBOperacion();
                String consulta = "DELETE FROM permisos WHERE IDRol = " + rol + "  and IDOpcion = " + opc;
                operacion.EjecutarSetencia(consulta);

            }
            catch (Exception e)
            {

            }
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
