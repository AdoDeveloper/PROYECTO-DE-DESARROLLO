using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class CompraModel
    {
        Int32 _id_compra;
        String _fecha;
        double _total;
        String _no_compra;
        Int32 _id_proveedor;
        List<DetalleCompraModel> _detalles;
        ProveedorModel _proveedor;

        public int Id_compra { get => _id_compra; set => _id_compra = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public double Total { get => _total; set => _total = value; }
        public string No_compra { get => _no_compra; set => _no_compra = value; }
        public int Id_proveedor { get => _id_proveedor; set => _id_proveedor = value; }
        public List<DetalleCompraModel> Detalles { get => _detalles; set => _detalles = value; }
        public ProveedorModel Proveedor { get => _proveedor; set => _proveedor = value; }
    }

}
