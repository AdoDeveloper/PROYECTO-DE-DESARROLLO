using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class DetalleCompraModel
    {
        Int32 _id_detalle;
        Int32 _id_compra;
        Int32 _id_producto;
        Int32 _cantidad;
        double _precio;
        double _subtotal;

        public int Id_detalle { get => _id_detalle; set => _id_detalle = value; }
        public int Id_compra { get => _id_compra; set => _id_compra = value; }
        public int Id_producto { get => _id_producto; set => _id_producto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }
    }

}
