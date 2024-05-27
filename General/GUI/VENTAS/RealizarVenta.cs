using DataLayer;
using DataLayer.MODELOS;
using General.CLS;
using General.GUI.CLIENTES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI.VENTAS
{
    public partial class RealizarCompra : Form
    {
        ClienteModel cliente = new ClienteModel();

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

            // Cambiar el nombre de la columna "Stock" a "Cantidad"
            if (dtgProductos.Columns["Stock"] != null)
            {
                dtgProductos.Columns["Stock"].HeaderText = "Cantidad";
            }



            // Agregar columna "Subtotal"
            if (!dtgProductos.Columns.Contains("Subtotal"))
            {
                DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Subtotal",
                    HeaderText = "Subtotal",
                    ReadOnly = true
                };
                dtgProductos.Columns.Add(subtotalColumn);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void onBuscarProducto(object sender, EventArgs e)
        {

        }

        private void setCliente(object sender, EventArgs e, ClienteModel c)
        {
            this.cliente = c;
            txbNomCliente.Text = this.cliente.Cliente;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GestionClientes c = new GestionClientes();
            c.isFormOpenOnVenta(true);
            c.setClienteOnVenta += setCliente;
            c.ShowDialog();
        }

        private void onBuscarProducto(object sender, KeyPressEventArgs e)
        {
            try {
                
                ltsBuscados =  Consultas.BUSCAR_PRODUCTOS(txbProducto.Text.ToLower());
                
                cmbProducto.Items.Clear();
                cmbProducto.Items.Add("Seleccionar");

                foreach (ProductoModel p in ltsBuscados)
                {
                    cmbProducto.Items.Add(p.Id_producto + " - " + p.Producto + " - $" + p.Precio.ToString());
                }
                cmbProducto.SelectedIndex = 0;
            } 
            catch { 
            
            }
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

                seleccionado.Stock = Convert.ToInt32(txbCantidad.Text);
                ltsSeleccionados.Add(seleccionado);
                ActualizarSubtotales();
                MostrarMensaje("¡Actualizar cambio!", Color.Red);
            }
            else
            {
                MessageBox.Show("Debe buscar un producto");
            }

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

   

        private void ActualizarSubtotales()
        {
            double total = 0;
            foreach (DataGridViewRow row in dtgProductos.Rows)
            {
                if (row.DataBoundItem is ProductoModel producto)
                {
                    // Suponiendo que la clase ProductoModel tiene una propiedad Precio
                    double subtotal = producto.Precio * producto.Stock;
                    total += subtotal;
                    row.Cells["Subtotal"].Value = subtotal;
                }
            }
            txbTotal.Text = total.ToString();
        }

        private void onRecibidoEnter(object sender, KeyEventArgs e)
        {
            // Verifica si la tecla presionada es Enter
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    // Intentar convertir los textos a double
                    double total = Convert.ToDouble(txbTotal.Text);
                    double recibido = Convert.ToDouble(txbRecibido.Text);

                    // Verificar si el recibido es menor que el total
                    if (recibido < total)
                    {
                        MessageBox.Show("El monto recibido no puede ser menor que el total.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbCanbio.Text = string.Empty; // Limpiar el campo de cambio
                        txbRecibido.Text = string.Empty;
                    }
                    else
                    {
                        // Calcular el cambio
                        double cambio = recibido - total;

                        // Mostrar el resultado en el textbox de cambio
                        txbCanbio.Text = cambio.ToString("F2"); // "F2" para formato con 2 decimales
                        MostrarMensaje("Cambio actualizado.", Color.Green);
                    }
                }
                catch (FormatException)
                {
                    // Mostrar mensaje de error si las conversiones fallan
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos Total y Recibido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbCanbio.Text = string.Empty; // Limpiar el campo de cambio en caso de error
                    txbRecibido.Text = string.Empty;
                }
            }
        }


        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validacionesProcesar())
                {
                    return; // Detener el proceso si alguna validación falla
                }

                List<DetalleFacturaModel> ltsDetalles = new List<DetalleFacturaModel>();
                FacturaModel fact = new FacturaModel();

                foreach (ProductoModel p in ltsSeleccionados)
                {
                    DetalleFacturaModel detalle = new DetalleFacturaModel
                    {
                        Precio_unitario = p.Precio,
                        Id_producto = p.Id_producto,
                        Cantidad = p.Stock,
                        Subtotal = p.Precio * p.Stock
                    };
                    ltsDetalles.Add(detalle);
                }

                fact.No_factura = HashHelper.Generate(5);
                fact.Total = Convert.ToDouble(txbTotal.Text);
                fact.Cliente = cliente;
                fact.Detalles = ltsDetalles;
                fact.Exp_Em = txbVendedor.Text;

                Consultas.CREAR_FACTURA(fact);
                MessageBox.Show("Se ha registrado la venta exitosamente");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool validacionesProcesar()
        {
            if (ltsSeleccionados.Count == 0)
            {
                MessageBox.Show("¡Sin productos! Debe agregar productos");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbRecibido.Text))
            {
                MessageBox.Show("Debe de digitar el importe recibido");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbNomCliente.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbVendedor.Text))
            {
                MessageBox.Show("Debe de digitar el No expediente del vendedor");
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            // Limpiando objetos
            cliente = new ClienteModel();
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
            txbRecibido.Text = "";
            txbCanbio.Text = "";
            lblMensaje.Text = "";
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
                    MostrarMensaje("¡Actualizar cambio!", Color.Red);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar.");
            }
        }

        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
