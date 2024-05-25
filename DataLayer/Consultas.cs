using DataLayer.MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public static List<ClienteModel> OBTENER_CLIENTES()
        {
            List<ClienteModel> lts = new List<ClienteModel>();

            String Consulta = "select * from clientes";

            DBOperacion operacion = new DBOperacion();
            try
            {
                DataTable dt = new DataTable();
                dt = operacion.Consultar(Consulta);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        ClienteModel c = new ClienteModel();
                        c.Id_cliente = Convert.ToInt32(dt.Rows[i]["id_cliente"]);
                        c.Cliente = Convert.ToString(dt.Rows[i]["cliente"]);
                        c.Telefono = Convert.ToString(dt.Rows[i]["telefono"]);
                        c.Correo = Convert.ToString(dt.Rows[i]["correo"]);
                        c.Dui = Convert.ToString(dt.Rows[i]["dui"]);
                        lts.Add(c);
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return lts;
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

        public static List<ProductoModel> BUSCAR_PRODUCTOS(String nombre)
        {


            String Consulta = "select * from productos where LOWER(producto) like '%" + nombre + "%'";

            DBOperacion operacion = new DBOperacion();
            List<ProductoModel> lts = new List<ProductoModel>();
            try
            {
                DataTable dt = new DataTable();
                dt = operacion.Consultar(Consulta);

                if (dt.Rows.Count > 0)
                {

                    for(int i = 0; i < dt.Rows.Count; i++)
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

        public static void AGREGAR_CLIENTE(ClienteModel c)
        {
            try
            {

                DBOperacion operacion = new DBOperacion();
                String consulta = "INSERT INTO clientes(cliente,telefono,correo,dui) values (@cliente,@telefono,@correo,@dui)";
                operacion.Comando.Parameters.AddWithValue("cliente", c.Cliente);
                operacion.Comando.Parameters.AddWithValue("telefono", c.Telefono);
                operacion.Comando.Parameters.AddWithValue("correo", c.Correo);
                operacion.Comando.Parameters.AddWithValue("dui", c.Dui);
                operacion.EjecutarSetencia(consulta);

            }
            catch (Exception e)
            {

            }
        }

        public static FacturaModel OBTENER_FACTURA_POR_No(String NoFac)
        {


            String Consulta = "select * from facturas where no_factura = '" + NoFac + "' limit 1";

            DBOperacion operacion = new DBOperacion();
            FacturaModel op = new FacturaModel();
            try
            {
                DataTable dt = new DataTable();
                dt = operacion.Consultar(Consulta);

                if (dt.Rows.Count > 0)
                {

                    int i = 0;


                    op.Id_factura = Convert.ToInt32(dt.Rows[i]["id_factura"]);
                    op.Total = Convert.ToDouble(dt.Rows[i]["total"]);
                    op.Fecha = Convert.ToString(dt.Rows[i]["fecha"]);
                    op.Id_cliente = Convert.ToInt32(dt.Rows[i]["id_cliente"]);


                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return op;
        }

        public static void CREAR_FACTURA(FacturaModel factura)
        {
            try
            {
                // Insertando factura
                DBOperacion operacion = new DBOperacion();
                string consulta = "INSERT INTO facturas(total,no_factura,id_cliente) VALUES (@total,@nofa,@cliente)";
                operacion.Comando.Parameters.AddWithValue("total", factura.Total);
                operacion.Comando.Parameters.AddWithValue("nofa", factura.No_factura);
                operacion.Comando.Parameters.AddWithValue("cliente", factura.Cliente.Id_cliente);
                operacion.EjecutarSetencia(consulta);

                // Obtenemos la factura creada
                FacturaModel newFac = OBTENER_FACTURA_POR_No(factura.No_factura);

                // Insertar los detalles
                StringBuilder stringDetalles = new StringBuilder();
                stringDetalles.Append("INSERT INTO detalles_factura(id_factura,id_producto,cantidad,precio_unitario,subtotal) VALUES ");

                foreach (DetalleFacturaModel detalle in factura.Detalles)
                {
                    stringDetalles.AppendFormat("({0}, {1}, {2}, {3}, {4}), ",
                        newFac.Id_factura, detalle.Id_producto, detalle.Cantidad, detalle.Precio_unitario, detalle.Subtotal);
                }

                // Remover la última coma y espacio
                if (stringDetalles.Length > 0)
                {
                    stringDetalles.Remove(stringDetalles.Length - 2, 2); // Eliminar la última coma y espacio
                }

                string query = stringDetalles.ToString();
                Console.WriteLine(query);

                DBOperacion operacion2 = new DBOperacion();
                operacion2.EjecutarSetencia(query);
            }
            catch (Exception e)
            {
                throw new Exception("Error al crear la factura", e);
            }
        }




        public static void EDITAR_CLIENTE(ClienteModel c)
        {
            try
            {

                DBOperacion operacion = new DBOperacion();
                StringBuilder consulta = new StringBuilder();
                consulta.Append(" UPDATE clientes ");
                consulta.Append(" SET cliente =  '" + c.Cliente + "', ");
                consulta.Append("  telefono =  '" + c.Telefono + "', ");
                consulta.Append("  correo =  '" + c.Correo + "', ");
                consulta.Append("  dui =  '" + c.Dui + "' ") ;
                consulta.Append(" WHERE id_cliente =  " + c.Id_cliente);
                operacion.EjecutarSetencia(consulta.ToString());

            }
            catch (Exception e)
            {

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
