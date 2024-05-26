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
    public partial class RealizarVenta : Form
    {
        ClienteModel cliente = new ClienteModel();

        List<ProductoModel> ltsBuscados = new List<ProductoModel>();

        private BindingList<ProductoModel> ltsSeleccionados = new BindingList<ProductoModel>();

        public RealizarVenta()
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
                seleccionado.Stock = Convert.ToInt32(txbCantidad.Text);
                ltsSeleccionados.Add(seleccionado);
                ActualizarSubtotales();
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

                    // Calcular el cambio
                    double cambio = recibido - total;

                    // Mostrar el resultado en el textbox de cambio
                    txbCanbio.Text = cambio.ToString("F2"); // "F2" para formato con 2 decimales
                }
                catch (FormatException)
                {
                    // Mostrar mensaje de error si las conversiones fallan
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos Total y Recibido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {

                List<DetalleFacturaModel> ltsDetalles = new List<DetalleFacturaModel>();
                FacturaModel fact = new FacturaModel();

                validacionesProcesar();

                foreach (ProductoModel p in ltsSeleccionados)
                {
                    DetalleFacturaModel detalle = new DetalleFacturaModel();
                    detalle.Precio_unitario = p.Precio;
                    detalle.Id_producto = p.Id_producto;
                    detalle.Cantidad = p.Stock;
                    detalle.Subtotal = p.Precio * p.Stock;
                    ltsDetalles.Add(detalle);
                }

                fact.No_factura = HashHelper.Generate(5);
                fact.Total = Convert.ToDouble(txbTotal.Text);
                fact.Cliente = cliente;
                fact.Detalles = ltsDetalles;

                Consultas.CREAR_FACTURA(fact);
                MessageBox.Show("Se ha registro la venta exitosamente");
                LimpiarFormulario();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

               
        }

        private void validacionesProcesar()
        {
            if (ltsSeleccionados.Count == 0)
            {
                MessageBox.Show("Sin productos! Debe agregar productos");
                return;
            }

            if (txbRecibido.Text.Equals(""))
            {
                MessageBox.Show("Debe de digitar el importe recibido");
                return;
            }
            if (txbNomCliente.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            if (txbVendedor.Text.Equals(""))
            {
                MessageBox.Show("Debe de digitar el No expediente del vendedor");
                return;
            }
        }

        private void LimpiarFormulario()
        {
            // Limpiando objetos
            cliente = new ClienteModel();
            ltsBuscados = new List<ProductoModel>();
            ltsSeleccionados = new BindingList<ProductoModel>();

            // Limpiar todos los TextBox
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
                else if (control is DataGridView)
                {
                    (control as DataGridView).Rows.Clear();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
