using DataLayer;
using DataLayer.MODELOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI.GESTION_PRODUCTOS
{
    public partial class AgregarEditar : Form
    {
        ProductoModel newProducto = new ProductoModel();

        
        public delegate void UpdateDataGridViewEventHandler(object sender, EventArgs e);

        
        public event UpdateDataGridViewEventHandler UpdateDataGridView;

        public AgregarEditar()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            opfImagen.Filter = "Archivos de imagenes | *.png; *.jpg; *.jpeg";
            try
            {
                if(opfImagen.ShowDialog() == DialogResult.OK)
                {
                    String ruta = opfImagen.FileName;
                    pbImagen.Image = Image.FromFile(ruta);
                }

            }catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la imagen");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pbImagen_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                newProducto.Producto = txbProducto.Text;
                newProducto.Precio = Convert.ToDouble(txbPrecio.Text);
                newProducto.Stock = Convert.ToInt32(txbStock.Text);
                newProducto.Descripcion = txbDesc.Text;
                newProducto.Image = ImageToByteArray(pbImagen.Image);
                Consultas.AGREGAR_PRODUCTO(newProducto);
                MessageBox.Show("Se guardo el producto correctamente");
                UpdateDataGridView?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar el producto");
            }
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
