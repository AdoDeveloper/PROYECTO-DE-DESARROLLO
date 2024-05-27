﻿using DataLayer.MODELOS;
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
            catch
            {

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
            catch { }
             return lts;
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
                string consulta = "INSERT INTO facturas(total,no_factura,id_cliente,exp_em) VALUES (@total,@nofa,@cliente, @vendedor)";
                operacion.Comando.Parameters.AddWithValue("total", factura.Total);
                operacion.Comando.Parameters.AddWithValue("nofa", factura.No_factura);
                operacion.Comando.Parameters.AddWithValue("cliente", factura.Cliente.Id_cliente);
                operacion.Comando.Parameters.AddWithValue("vendedor", factura.Exp_Em);
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

        public static bool CONSULTAR_EXP(string exp)
        {
            try
            {
                // Crear la instancia de DBOperacion
                DBOperacion operacion = new DBOperacion();

                // Definir la consulta SQL para verificar si el expediente existe
                string consulta = "SELECT COUNT(*) AS cantidad FROM empleados WHERE no_expediente = @exp";

                // Agregar el parámetro a la consulta
                operacion.Comando.Parameters.Clear();
                operacion.Comando.Parameters.AddWithValue("@exp", exp);

                // Ejecutar la consulta y obtener el resultado en un DataTable
                DataTable resultado = operacion.Consultar(consulta);

                // Verificar si el resultado tiene filas y obtener la cantidad
                if (resultado.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(resultado.Rows[0]["cantidad"]);
                    // Retornar true si el expediente existe (count > 0), de lo contrario false
                    return count > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                // Manejar la excepción (puedes agregar log o cualquier otro manejo de error aquí)
                throw new Exception("Error al consultar el expediente", e);
            }
        }

        // Método para actualizar el stock de un producto en la base de datos
        public static void ACTUALIZAR_STOCK_PRODUCTO(ProductoModel producto)
        {
            try
            {
                DBOperacion operacion = new DBOperacion();
                string consulta = "UPDATE productos SET stock = stock - @cantidadVendida WHERE id_producto = @idProducto";
                operacion.Comando.Parameters.AddWithValue("cantidadVendida", producto.Stock); // Recibir la cantidad vendida en lugar del nuevo stock
                operacion.Comando.Parameters.AddWithValue("idProducto", producto.Id_producto);
                operacion.EjecutarSetencia(consulta);
            }
            catch (Exception e)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al actualizar el stock del producto: " + e.Message);
            }
        }



        public static void GUARDAR_MOVIMIENTO(MovimientoModel mov)
        {
            try
            {
                DBOperacion operacion = new DBOperacion();
                string insertMovimiento = "INSERT INTO movimientos (monto, concepto, fecha, id_cuenta) VALUES (@monto, @concepto, NOW(), @idCuenta)";
                operacion.Comando.Parameters.AddWithValue("monto", mov.Monto);
                operacion.Comando.Parameters.AddWithValue("concepto", mov.Concepto);
                operacion.Comando.Parameters.AddWithValue("idCuenta", mov.Id_cuenta);
                operacion.EjecutarSetencia(insertMovimiento);
            }
            catch (Exception e)
            {
                throw new Exception("Error al guardar el movimiento", e);
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
                consulta.Append("  dui =  '" + c.Dui + "' ");
                consulta.Append(" WHERE id_cliente =  " + c.Id_cliente);
                operacion.EjecutarSetencia(consulta.ToString());

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



        public static DataTable VENTAS_SEGUN_PERIODO(string pFechaInicio, string pFechaFinal)
        {
            DataTable Resultado = new DataTable();

            String Consulta = @"SELECT 
                f.id_factura AS ID_Factura,
                f.fecha AS Fecha,
                f.no_factura AS No_Factura,
                c.cliente AS Cliente,
                CONCAT(MAX(e.Nombres),' ',MAX(e.Apellidos)) AS Empleado,
                GROUP_CONCAT(CONCAT(p.producto, ' (', df.cantidad, ')') SEPARATOR ', ') AS Detalles_Productos,
                SUM(df.subtotal) AS Total_Venta
                FROM 
                    facturas f
                INNER JOIN 
                    clientes c ON f.id_cliente = c.id_cliente
                LEFT JOIN 
                    detalles_factura df ON f.id_factura = df.id_factura
                LEFT JOIN 
                    productos p ON df.id_producto = p.id_producto
                LEFT JOIN 
                    empleados e ON f.exp_em = e.no_expediente
                WHERE
                    f.fecha BETWEEN '" + pFechaInicio + "' AND '" + pFechaFinal + @"'
                GROUP BY 
                    f.id_factura, f.fecha, f.total, f.no_factura, c.cliente;";
            DBOperacion operacion = new DBOperacion();

            try
            {
                Resultado = operacion.Consultar(Consulta);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }

            return Resultado;
        }
    }
}