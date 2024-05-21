using DataLayer;
using DataLayer.MODELOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI.GESTION_PRODUCTOS
{
    public partial class AgregarEditar : Form
    {
        ProductoModel newProducto = new ProductoModel();
        
        Boolean esEditar = false;

        
        public delegate void UpdateDataGridViewEventHandler(object sender, EventArgs e);

        
        public event UpdateDataGridViewEventHandler UpdateDataGridView;



        public AgregarEditar()
        {
            InitializeComponent();
        }

        public void setProducto(ProductoModel p)
        {
            this.newProducto = p;
            txbProducto.Text = p.Producto;
            txbPrecio.Text = Convert.ToString(p.Precio);
            txbStock.Text = Convert.ToString(p.Stock);
            txbDesc.Text = p.Descripcion;

            
            try
            {
                //MemoryStream ms = new MemoryStream(p.Image);
                //Console.WriteLine("Tamaño del MemoryStream: " + ms.Length);

                //Image.FromStream(ms);

                //Bitmap bm = new Bitmap(ms);

                pbImagen.Image = byteArrayToImage(p.Image);
                pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen del producto\n "+ ex.Message);
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
        }

        public void setEditar(bool edit)
        {
            esEditar = edit;
            if(esEditar)
            {
                this.Text = "EDITAR";
            }
            else
            {
                this.Text = "AGREGAR";
            }
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
            if (esEditar)
            {
                this.editarProducto();
            }
            else
            {
                this.agregarProducto();
            }
        }

        public void agregarProducto()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                newProducto.Producto = txbProducto.Text;
                newProducto.Precio = Convert.ToDouble(txbPrecio.Text);
                newProducto.Stock = Convert.ToInt32(txbStock.Text);
                newProducto.Descripcion = txbDesc.Text;
                pbImagen.Image.Save(ms, ImageFormat.Png);
                byte[] data = ms.ToArray();
                newProducto.Image = data;
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

        public void editarProducto()
        {
            try
            {
                newProducto.Producto = txbProducto.Text;
                newProducto.Precio = Convert.ToDouble(txbPrecio.Text);
                newProducto.Stock = Convert.ToInt32(txbStock.Text);
                newProducto.Descripcion = txbDesc.Text;
                newProducto.Image = ImageToByteArray(pbImagen.Image);
                Consultas.EDITAR_PRODUCTO(newProducto);
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

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                throw new ArgumentException("El array de bytes no puede ser nulo o estar vacío.");
            }

            try
            {
                using (var ms = new System.IO.MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al convertir byte array a imagen: " + ex.Message);
                return null;
            }
        }

        private MemoryStream ByteToImage(byte[] byteArrayIn)
        {
            MemoryStream memoryStream = new MemoryStream((byte[])byteArrayIn);
            return memoryStream;

        }


    }
}
