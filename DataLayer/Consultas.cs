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


        public static List<RolModel> OBTENER_ROLES()
        {
            List<RolModel> lts = new List<RolModel>();

            String Consulta = @"SELECT IDRol, Rol FROM roles ORDER BY Rol ASC;";
            DBOperacion operacion = new DBOperacion();

            try
            {
                DataTable dt = new DataTable();
                dt = operacion.Consultar(Consulta);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        RolModel op = new RolModel();
                        op.IdRol = Convert.ToInt32(dt.Rows[i]["IDRol"]);
                        op.Rol = Convert.ToString(dt.Rows[i]["Rol"]);


                        lts.Add(op);
                    }

                }

            }
            catch (Exception)
            {


            }

            return lts;
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

            string consulta = "SELECT IDUsuario, Usuario, Clave , IDEmpleado, IDRol FROM usuarios;";
            DBOperacion operacion = new DBOperacion(); // Asegúrate de tener esta clase definida para operaciones en la base de datos

            try
            {
                DataTable dt = operacion.Consultar(consulta);

                foreach (DataRow row in dt.Rows)
                {
                    UsuarioModel usuario = new UsuarioModel();
                    usuario.ID_Usuario = Convert.ToInt32(row["IDUsuario"]);
                    usuario.Usuario = Convert.ToString(row["Usuario"]);
                    usuario.Clave = "";
                    usuario.ID_Empleado = Convert.ToInt32(row["IDEmpleado"]);
                    usuario.ID_Rol = Convert.ToInt32(row["IDRol"]);
                    

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


            String Consulta = "select id_producto, producto, precio, stock, descripcion from productos p where LOWER(producto) like '%" + nombre + "%'";

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
                        //op.Image = (byte[])dt.Rows[i]["imagen"];
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

        public static void ELIMINAR_CLIENTE(Int32 id)
        {
            try
            {

                DBOperacion operacion = new DBOperacion();
                String consulta = "DELETE FROM clientes WHERE id_cliente = " + id;
                operacion.EjecutarSetencia(consulta);

            }
            catch (Exception e)
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

        public static List<ProveedorModel> OBTENER_PROVEEDORES()
        {
            List<ProveedorModel> proveedores = new List<ProveedorModel>();
            try
            {
                DBOperacion operacion = new DBOperacion();
                String consulta = "SELECT id_proveedor, proveedor, contacto, nit, direccion FROM proveedores";
                DataTable dt = operacion.Consultar(consulta);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ProveedorModel proveedor = new ProveedorModel
                        {
                            Id_proveedor = Convert.ToInt32(row["id_proveedor"]),
                            Proveedor = Convert.ToString(row["proveedor"]),
                            Contacto = Convert.ToString(row["contacto"]),
                            Nit = Convert.ToString(row["nit"]),
                            Direccion = Convert.ToString(row["direccion"])
                        };
                        proveedores.Add(proveedor);
                    }
                }
            }
            catch (Exception e)
            {
                // Handle the exception (log it, rethrow it, or manage it as appropriate)
                Console.WriteLine(e.Message);
            }
            return proveedores;
        }


        public static void AGREGAR_PROVEEDOR(ProveedorModel c)
        {
            try
            {

                DBOperacion operacion = new DBOperacion();
                String consulta = "INSERT INTO proveedores(proveedor,contacto,nit,direccion) values (@a,@b,@c,@d)";
                operacion.Comando.Parameters.AddWithValue("a", c.Proveedor);
                operacion.Comando.Parameters.AddWithValue("b", c.Contacto);
                operacion.Comando.Parameters.AddWithValue("c", c.Nit);
                operacion.Comando.Parameters.AddWithValue("d", c.Direccion);
                operacion.EjecutarSetencia(consulta);

            }
            catch (Exception e)
            {

            }
        }

        public static void ELIMINAR_PROVEEDOR(int id)
        {
            try
            {
                DBOperacion operacion = new DBOperacion();
                String consulta = "DELETE FROM proveedores WHERE id_proveedor = @id";
                operacion.Comando.Parameters.AddWithValue("@id", id);
                operacion.EjecutarSetencia(consulta);
            }
            catch (Exception e)
            {
                // Handle the exception (log it, rethrow it, or manage it as appropriate)
                Console.WriteLine(e.Message);
            }
        }


        public static void EDITAR_PROVEEDOR(ProveedorModel c)
        {
            try
            {
                DBOperacion operacion = new DBOperacion();
                String consulta = "UPDATE proveedores SET proveedor = @a, contacto = @b, nit = @c, direccion = @d WHERE id_proveedor = @id";
                operacion.Comando.Parameters.AddWithValue("a", c.Proveedor);
                operacion.Comando.Parameters.AddWithValue("b", c.Contacto);
                operacion.Comando.Parameters.AddWithValue("c", c.Nit);
                operacion.Comando.Parameters.AddWithValue("d", c.Direccion);
                operacion.Comando.Parameters.AddWithValue("id", c.Id_proveedor); // Assuming the model has an Id property to identify the record to update
                operacion.EjecutarSetencia(consulta);
            }
            catch (Exception e)
            {
                // Handle the exception (log it, rethrow it, or manage it as appropriate)
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

        public static void CREAR_COMPRA(CompraModel compra)
        {
            try
            {
                // Insertando compra
                DBOperacion operacion = new DBOperacion();
                string consulta = "INSERT INTO compras(total, no_compra, id_proveedor) VALUES (@total, @nocompra, @proveedor)";
                operacion.Comando.Parameters.AddWithValue("total", compra.Total);
                operacion.Comando.Parameters.AddWithValue("nocompra", compra.No_compra);
                operacion.Comando.Parameters.AddWithValue("proveedor", compra.Proveedor.Id_proveedor);
                operacion.EjecutarSetencia(consulta);

                // Obtenemos la compra creada
                CompraModel newCompra = OBTENER_COMPRA_POR_No(compra.No_compra);

                // Insertar los detalles
                StringBuilder stringDetalles = new StringBuilder();
                stringDetalles.Append("INSERT INTO detalles_compra(id_compra, id_producto, cantidad, precio, subtotal) VALUES ");

                foreach (DetalleCompraModel detalle in compra.Detalles)
                {
                    stringDetalles.AppendFormat("({0}, {1}, {2}, {3}, {4}), ",
                        newCompra.Id_compra, detalle.Id_producto, detalle.Cantidad, detalle.Precio, detalle.Subtotal);
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
                throw new Exception("Error al crear la compra", e);
            }
        }

        public static CompraModel OBTENER_COMPRA_POR_No(string no_compra)
        {
            CompraModel compra = null;
            try
            {
                DBOperacion operacion = new DBOperacion();
                string consulta = "SELECT id_compra, total, no_compra, id_proveedor FROM compras WHERE no_compra = @nocompra";
                operacion.Comando.Parameters.AddWithValue("@nocompra", no_compra);
                DataTable dt = operacion.Consultar(consulta);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    compra = new CompraModel
                    {
                        Id_compra = Convert.ToInt32(row["id_compra"]),
                        Total = Convert.ToDouble(row["total"]),
                        No_compra = Convert.ToString(row["no_compra"]),
                        Proveedor = new ProveedorModel
                        {
                            Id_proveedor = Convert.ToInt32(row["id_proveedor"])
                        }
                    };
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener la compra por número", e);
            }
            return compra;
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

        public static void CREAR_USUARIO(UsuarioModel u)
        {
            try
            {
                DBOperacion operacion = new DBOperacion();
                string consulta = "INSERT INTO usuarios (usuario, clave, IDEmpleado, IDRol) " +
                                  "VALUES ('" + u.Usuario + "', '" + u.Clave + "', " + u.ID_Empleado + ", " + u.ID_Rol + ")";

                // Asegúrate de abrir la conexión antes de ejecutar la sentencia
                operacion.EjecutarSetencia(consulta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void EDITAR_USUARIO(UsuarioModel c)
        {
            try
            {

                DBOperacion operacion = new DBOperacion();
                StringBuilder consulta = new StringBuilder();
                consulta.Append(" UPDATE usuarios ");
                consulta.Append(" SET Usuario =  '" + c.Usuario + "', ");
                consulta.Append("  Clave =  '" + c.Clave + "', ");
                consulta.Append("  IDEmpleado =  '" + c.ID_Empleado + "', ");
                consulta.Append("  IDRol =  '" + c.ID_Rol + "' ");
                consulta.Append(" WHERE IDUsuario =  " + c.ID_Usuario);
                operacion.EjecutarSetencia(consulta.ToString());

            }
            catch (Exception e)
            {
            }
        }

        public static void ELIMINAR_USUARIO(int id)
        {
            try
            {
                DBOperacion operacion = new DBOperacion();
                String consulta = "DELETE FROM usuarios WHERE IDUsuario = @id";
                operacion.Comando.Parameters.AddWithValue("@id", id);
                operacion.EjecutarSetencia(consulta);
            }
            catch (Exception e)
            {
                // Handle the exception (log it, rethrow it, or manage it as appropriate)
                Console.WriteLine(e.Message);
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
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }

            return Resultado;
        }
        public static List<EmpleadoModel> FILTRAR_EMPLEADOS(string filtro)
        {
            List<EmpleadoModel> listaEmpleadosFiltrados = new List<EmpleadoModel>();

            string consulta = @"SELECT IDEmpleado, Nombres, Apellidos, DUI, Direccion, Telefono 
                        FROM empleados 
                        WHERE LOWER(Nombres) LIKE '%" + filtro.ToLower() + "%' OR LOWER(Apellidos) LIKE '%" + filtro.ToLower() + "%';";

            DBOperacion operacion = new DBOperacion(); 

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

                    listaEmpleadosFiltrados.Add(empleado);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return listaEmpleadosFiltrados;
        }
        public static List<ClienteModel> FILTRAR_CLIENTES(string filtro)
        {
            List<ClienteModel> clientesFiltrados = new List<ClienteModel>();

            string consulta = @"SELECT * FROM clientes 
                        WHERE LOWER(cliente) LIKE '%" + filtro.ToLower() + @"%' 
                        OR LOWER(telefono) LIKE '%" + filtro.ToLower() + @"%' 
                        OR LOWER(correo) LIKE '%" + filtro.ToLower() + @"%' 
                        OR LOWER(dui) LIKE '%" + filtro.ToLower() + @"%';";

            DBOperacion operacion = new DBOperacion(); 

            try
            {
                DataTable dt = operacion.Consultar(consulta);

                foreach (DataRow row in dt.Rows)
                {
                    ClienteModel cliente = new ClienteModel();
                    cliente.Id_cliente = Convert.ToInt32(row["id_cliente"]);
                    cliente.Cliente = Convert.ToString(row["cliente"]);
                    cliente.Telefono = Convert.ToString(row["telefono"]);
                    cliente.Correo = Convert.ToString(row["correo"]);
                    cliente.Dui = Convert.ToString(row["dui"]);

                    clientesFiltrados.Add(cliente);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return clientesFiltrados;
        }

        public static List<ProductoModel> FILTRAR_PRODUCTOS(string filtro)
        {
            List<ProductoModel> productosFiltrados = new List<ProductoModel>();

            // Consulta SQL para filtrar productos por nombre
            string consulta = "SELECT * FROM productos WHERE LOWER(producto) LIKE '%" + filtro + "%'";

            DBOperacion operacion = new DBOperacion();

            try
            {
                DataTable dt = operacion.Consultar(consulta);

                foreach (DataRow row in dt.Rows)
                {
                    ProductoModel producto = new ProductoModel();
                    producto.Id_producto = Convert.ToInt32(row["id_producto"]);
                    producto.Producto = Convert.ToString(row["producto"]);
                    producto.Precio = Convert.ToDouble(row["precio"]);
                    producto.Stock = Convert.ToInt32(row["stock"]);
                    producto.Descripcion = Convert.ToString(row["descripcion"]);
                    producto.Image = (byte[])row["imagen"];

                    productosFiltrados.Add(producto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return productosFiltrados;
        }



    }
}