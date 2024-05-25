using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public  class DetalleFacturaModel
    {
        Int32 _id_fac_detalle;
        Int32 _id_factura;
        Int32 _id_producto;
        Int32 _cantidad;
        double _precio_unitario;
        double _subtotal;

        public int Id_fac_detalle { get => _id_fac_detalle; set => _id_fac_detalle = value; }
        public int Id_factura { get => _id_factura; set => _id_factura = value; }
        public int Id_producto { get => _id_producto; set => _id_producto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public double Precio_unitario { get => _precio_unitario; set => _precio_unitario = value; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }
    }
}
