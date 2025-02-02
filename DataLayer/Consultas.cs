﻿using DataLayer.MODELOS;
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

        public static List<ProductoModel> OBTENER_PRODUCTOS()
        {
            List<ProductoModel> lts = new List<ProductoModel>();

            String Consulta = "select * from productos";

            DBOperacion operacion = new DBOperacion();
            try
            {
                DataTable dt = new DataTable();
                dt = operacion.Consultar(Consulta);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        ProductoModel op = new ProductoModel();
                        op.Id_producto = Convert.ToInt32(dt.Rows[i]["id_producto"]);
                        op.Producto = Convert.ToString(dt.Rows[i]["producto"]);
                        op.Precio = Convert.ToDouble(dt.Rows[i]["precio"]);
                        op.Stock = Convert.ToInt32(dt.Rows[i]["stock"]);
                        op.Descripcion = Convert.ToString(dt.Rows[i]["descripcion"]);
                        op.Image = (byte[])dt.Rows[i]["imagen"];
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

        public static List<EmpleadoModel> OBTENER_EMPLEADOS()
        {
            List<EmpleadoModel> listaEmpleados = new List<EmpleadoModel>();

            string consulta = "SELECT IDEmpleado, Nombres, Apellidos, DUI, Direccion, Telefono FROM empleados;";
            DBOperacion operacion = new DBOperacion(); // Asegúrate de tener esta clase definida para operaciones en la base de datos

            try
            {
                DataTable dt = operacion.Consultar(consulta);

                foreach (DataRow row in dt.Rows)
                {
                    EmpleadoModel empleado = new EmpleadoModel();
                    empleado.ID_Empleado = Convert.ToInt32(row["IDEmpleado"]);
                    empleado.Nombres = Convert.ToString(row["Nombres"]);
                    empleado.Apellidos = Convert.ToString(row["Apellidos"]);
                    empleado.DUI = Convert.ToString(row["DUI"]);
                    empleado.Direccion = Convert.ToString(row["Direccion"]);
                    empleado.Telefono = Convert.ToString(row["Telefono"]);

                    listaEmpleados.Add(empleado);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return listaEmpleados;
        }

        public static List<UsuarioModel> OBTENER_USUARIOS()
        {
            List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

            string consulta = "SELECT IDUsuario, Usuario, IDEmpleado, IDRol, Imagen FROM usuarios;";
            DBOperacion operacion = new DBOperacion(); // Asegúrate de tener esta clase definida para operaciones en la base de datos

            try
            {
                DataTable dt = operacion.Consultar(consulta);

                foreach (DataRow row in dt.Rows)
                {
                    UsuarioModel usuario = new UsuarioModel();
                    usuario.ID_Usuario = Convert.ToInt32(row["IDUsuario"]);
                    usuario.Usuario = Convert.ToString(row["Usuario"]);
                    //usuario.Clave = Convert.ToString(row["Clave"]);
                    usuario.ID_Empleado = Convert.ToInt32(row["IDEmpleado"]);
                    usuario.ID_Rol = Convert.ToInt32(row["IDRol"]);
                    usuario.Imagen = row["Imagen"] == DBNull.Value ? null : (byte[])row["Imagen"];

                    listaUsuarios.Add(usuario);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return listaUsuarios;
        }


        public static ProductoModel OBTENER_PRODUCTO(Int32 id)
        {
            

            String Consulta = "select * from productos where id_producto = " + id + " limit 1";

            DBOperacion operacion = new DBOperacion();
            ProductoModel op = new ProductoModel();
            try
            {
                DataTable dt = new DataTable();
                dt = operacion.Consultar(Consulta);

                if (dt.Rows.Count > 0)
                {

                    int i = 0;

                       
                        op.Id_producto = Convert.ToInt32(dt.Rows[i]["id_producto"]);
                        op.Producto = Convert.ToString(dt.Rows[i]["producto"]);
                        op.Precio = Convert.ToDouble(dt.Rows[i]["precio"]);
                        op.Stock = Convert.ToInt32(dt.Rows[i]["stock"]);
                        op.Descripcion = Convert.ToString(dt.Rows[i]["descripcion"]);
                        op.Image = (byte[])dt.Rows[i]["imagen"];
                        
                    

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return op;
        }

        public static EmpleadoModel OBTENER_EMPLEADO(Int32 id)
        {
            String consulta = "SELECT * FROM empleados WHERE IDEmpleado = " + id + " LIMIT 1";

            DBOperacion operacion = new DBOperacion();
            EmpleadoModel empleado = new EmpleadoModel();

            try
            {
                DataTable dt = operacion.Consultar(consulta);

                if (dt.Rows.Count > 0)
                {
                    int i = 0;

                    empleado.ID_Empleado = Convert.ToInt32(dt.Rows[i]["IDEmpleado"]);
                    empleado.Nombres = Convert.ToString(dt.Rows[i]["Nombres"]);
                    empleado.Apellidos = Convert.ToString(dt.Rows[i]["Apellidos"]);
                    empleado.DUI = Convert.ToString(dt.Rows[i]["DUI"]);
                    empleado.Direccion = Convert.ToString(dt.Rows[i]["Direccion"]);
                    empleado.Telefono = Convert.ToString(dt.Rows[i]["Telefono"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return empleado;
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

        public static void ELIMINAR_EMPLEADO(Int32 id)
        {
            try
            {

                DBOperacion operacion = new DBOperacion();
                String consulta = "DELETE FROM empleados WHERE IDEmpleado = " + id;
                operacion.EjecutarSetencia(consulta);
            }
            catch (Exception e)
            {

            }
        }

        public static void AGREGAR_PRODUCTO(ProductoModel p)
        {
            try
            {

                DBOperacion operacion = new DBOperacion();
                String consulta = "INSERT INTO productos(producto,precio,stock,descripcion, imagen) values ('"+p.Producto+"',"+p.Precio+", "+p.Stock+",'"+p.Descripcion+"', @image)";
                operacion.Comando.Parameters.AddWithValue("image", p.Image);
                operacion.EjecutarSetencia(consulta);

            }
            catch (Exception e)
            {

            }
        }

        public static void AGREGAR_EMPLEADO(EmpleadoModel e)
        {
            try
            {
                DBOperacion operacion = new DBOperacion();
                string consulta = "INSERT INTO empleados(Nombres, Apellidos, DUI, Direccion, Telefono) " +
                                  "VALUES ('" + e.Nombres + "', '" + e.Apellidos + "', '" + e.DUI + "', '" + e.Direccion + "', '" + e.Telefono + "')";

                // Asegúrate de abrir la conexión antes de ejecutar la sentencia
                operacion.EjecutarSetencia(consulta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void EDITAR_PRODUCTO(ProductoModel p)
        {
            try
            {

                DBOperacion operacion = new DBOperacion();
                StringBuilder consulta = new StringBuilder();
                consulta.Append(" UPDATE productos ");
                consulta.Append(" SET producto =  '" + p.Producto +"', ");
                consulta.Append("  precio =  " + p.Precio + ", ");
                consulta.Append("  stock =  " + p.Stock + ", ");
                consulta.Append("  imagen =  @image, ");
                consulta.Append("  descripcion =  '" + p.Descripcion + "' ");
                consulta.Append(" WHERE id_producto =  " + p.Id_producto);
                operacion.Comando.Parameters.AddWithValue("image", p.Image);
                operacion.EjecutarSetencia(consulta.ToString());

            }
            catch (Exception e)
            {

            }
        }

        public static bool VALIDAR_DUI_EMPLEADO(EmpleadoModel e)
        {
            try
            {
                DBOperacion operacion = new DBOperacion();
                string consulta = "SELECT COUNT(*) FROM empleados WHERE DUI = '" + e.DUI + "' AND IDEmpleado != " + e.ID_Empleado;
                DataTable dt = operacion.Consultar(consulta);

                // Verificar si el resultado tiene al menos una fila
                if (dt.Rows.Count > 0)
                {
                    // Obtener el valor del primer registro en la primera columna
                    int count = Convert.ToInt32(dt.Rows[0][0]);

                    // Si count es 0, significa que el DUI es válido
                    return count == 0;
                }
                else
                {
                    // No se encontraron resultados, retornar false por precaución
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hubo un error al validar el DUI del empleado: " + ex.Message);
                return false; // En caso de error, retorna false
            }
        }


        public static void EDITAR_EMPLEADO(EmpleadoModel e)
        {
            try
            {
                DBOperacion operacion = new DBOperacion();
                StringBuilder consulta = new StringBuilder();
                consulta.Append("UPDATE empleados ");
                consulta.Append("SET Nombres = '" + e.Nombres + "', ");
                consulta.Append("Apellidos = '" + e.Apellidos + "', ");
                consulta.Append("DUI = '" + e.DUI + "', ");
                consulta.Append("Direccion = '" + e.Direccion + "', ");
                consulta.Append("Telefono = '" + e.Telefono + "' ");
                consulta.Append("WHERE IDEmpleado = " + e.ID_Empleado);

                operacion.EjecutarSetencia(consulta.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
