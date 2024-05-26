using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class FacturaModel
    {
        Int32 _id_factura;
        String _fecha;
        double _total;
        String no_factura;
        Int32 _id_cliente;
        String _exp_em;
        List<DetalleFacturaModel> _detalles;
        ClienteModel _cliente;
        public int Id_factura { get => _id_factura; set => _id_factura = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public double Total { get => _total; set => _total = value; }
        public string No_factura { get => no_factura; set => no_factura = value; }
        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public List<DetalleFacturaModel> Detalles { get => _detalles; set => _detalles = value; }
        public ClienteModel Cliente { get => _cliente; set => _cliente = value; }
        public string Exp_Em { get => _exp_em; set => _exp_em = value; }
    }
}
