using DataLayer;
using DataLayer.MODELOS;
using General.CLS;
using General.GUI.CLIENTES;
using General.GUI.GESTION_PROVEEDORES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI.COMPRAS
{
    public partial class RealizarCompra : Form
    {
        ProveedorModel proveedor = new ProveedorModel();

        List<ProductoModel> ltsBuscados = new List<ProductoModel>();

        private BindingList<ProductoModel> ltsSeleccionados = new BindingList<ProductoModel>();

        public RealizarCompra()
        {
            InitializeComponent();
            confDataGridViewProductos();
            txbCantidad.Text = "1";

        }


        public void confDataGridViewProductos()
        {
            // Configura el DataGridView para usar BindingList
            dtgProductos.DataSource = ltsSeleccionados;

            // Ocultar la columna "Image"
            if (dtgProductos.Columns["Image"] != null)
            {
                dtgProductos.Columns["Image"].Visible = false;
            }

            if (dtgProductos.Columns["Cantidad"] != null)
            {
                dtgProductos.Columns["Cantidad"].ReadOnly = false;
            }

            if (dtgProductos.Columns["Descripcion"] != null)
            {
                dtgProductos.Columns["Descripcion"].Visible = false;
            }

            // Cambiar el nombre de la columna "Stock" a "Cantidad y precio a Precio compra"
            if (dtgProductos.Columns["Stock"] != null)
            {
                dtgProductos.Columns["Stock"].ReadOnly = false;
                dtgProductos.Columns["Stock"].HeaderText = "Stock de Ingreso";

                dtgProductos.Columns["Precio"].ReadOnly = false;
                dtgProductos.Columns["Precio"].HeaderText = "Precio de Compra";


            }




            // Agregar columna "Subtotal"

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (cmbProducto.SelectedItem != null && !cmbProducto.SelectedItem.ToString().Equals("Seleccionar"))
            {
                Int32 id_producto = Convert.ToInt32(cmbProducto.SelectedItem.ToString().Split('-')[0]);

                ProductoModel seleccionado = ltsBuscados.Find(element => element.Id_producto == id_producto);

                var exists = ltsSeleccionados.Where(opc => opc.Id_producto == seleccionado.Id_producto);

                if (exists.Any())
                {
                    MessageBox.Show("El producto ya se agregó a la lista");
                    return;
                }
                seleccionado.Stock = Convert.ToInt32(txbCantidad.Text.ToString());
                seleccionado.Precio = Convert.ToDouble(txbPrecioCompra.Text);
                ltsSeleccionados.Add(seleccionado);
                ActualizarSubtotales();
                
            }
            else
            {
                MessageBox.Show("Debe buscar un producto");
            }

        }


        private void ActualizarSubtotales()
        {
            double total = 0;
            foreach (DataGridViewRow row in dtgProductos.Rows)
            {
                if (row.DataBoundItem is ProductoModel producto)
                {
                    // Suponiendo que la clase ProductoModel tiene una propiedad Precio
                    
                    total += producto.Precio;

                }
            }
            txbTotal.Text = total.ToString();
        }

        private void txbProducto_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txbProducto_Enter(object sender, EventArgs e)
        {

        }

        private void txbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                ltsBuscados = Consultas.BUSCAR_PRODUCTOS(txbProducto.Text.ToLower());

                cmbProducto.Items.Clear();
                cmbProducto.Items.Add("Seleccionar");

                foreach (ProductoModel p in ltsBuscados)
                {
                    cmbProducto.Items.Add(p.Id_producto + " - " + p.Producto + " - $" + p.Precio.ToString());
                }
                cmbProducto.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void setProveedor(object sender, EventArgs e, ProveedorModel c)
        {
            this.proveedor = c;
            txbNomCliente.Text = this.proveedor.Proveedor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GestionProveedor c = new GestionProveedor();
            c.isFormOpenOnVenta(true);
            c.setProveedorOnCompra += setProveedor;
            c.ShowDialog();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validacionesProcesar())
                {
                    return; // Detener el proceso si alguna validación falla
                }

                List<DetalleCompraModel> ltsDetalles = new List<DetalleCompraModel>();
                CompraModel compra = new CompraModel();

                foreach (ProductoModel p in ltsSeleccionados)
                {
                    DetalleCompraModel detalle = new DetalleCompraModel
                    {
                        Precio = p.Precio,
                        Id_producto = p.Id_producto,
                        Cantidad = p.Stock,
                        Subtotal = p.Precio
                    };
                    ltsDetalles.Add(detalle);
                }

                compra.No_compra = HashHelper.Generate(5);
                compra.Total = Convert.ToDouble(txbTotal.Text);
                compra.Proveedor = proveedor; // Asumiendo que tienes un objeto proveedor disponible
                compra.Detalles = ltsDetalles;

                Consultas.CREAR_COMPRA(compra);
                MessageBox.Show("Se ha registrado la compra exitosamente");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LimpiarFormulario()
        {
            // Limpiando objetos
            proveedor = new ProveedorModel();
            ltsBuscados = new List<ProductoModel>();

            // Recrear la lista ltsSeleccionados para eliminar referencias antiguas
            ltsSeleccionados = new BindingList<ProductoModel>();

            // Configurar el DataGridView con la nueva lista vacía
            dtgProductos.DataSource = ltsSeleccionados;

            // Limpiar todos los TextBox y ComboBox
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Clear();
                }
                else if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndex = -1;
                }
            }

            // Limpiar el DataGridView
            dtgProductos.Rows.Clear();
            txbTotal.Text = "0";
            lblMensaje.Text = "";
        }
        private bool validacionesProcesar()
        {
            if (ltsSeleccionados.Count == 0)
            {
                MessageBox.Show("¡Sin productos! Debe agregar productos");
                return false;
            }



            if (string.IsNullOrWhiteSpace(txbNomCliente.Text))
            {
                MessageBox.Show("Debe seleccionar un proveedor");
                return false;
            }


            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (dtgProductos.SelectedRows.Count > 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dtgProductos.SelectedRows[0];

                // Obtiene el producto de la fila seleccionada
                if (selectedRow.DataBoundItem is ProductoModel productoSeleccionado)
                {
                    // Elimina el producto de la lista de seleccionados
                    ltsSeleccionados.Remove(productoSeleccionado);

                    // Actualiza los subtotales
                    ActualizarSubtotales();
                    
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar.");
            }
        }
    }
}
