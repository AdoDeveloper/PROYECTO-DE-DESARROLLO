using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class ProductoModel
    {
        Int32 _id_producto;
        String _producto;
        Double _precio;
        Int32 _stock;
        String _descripcion;
        byte[] _image;

        public int Id_producto { get => _id_producto; set => _id_producto = value; }
        public string Producto { get => _producto; set => _producto = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public byte[] Image { get => _image; set => _image = value; }
    }
}
