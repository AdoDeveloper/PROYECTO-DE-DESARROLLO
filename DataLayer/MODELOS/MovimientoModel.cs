using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class MovimientoModel
    {
        Int32 _id_movimiento;
        Double _monto;
        String _concepto;
        DateTime _fecha;
        Int32 _id_cuenta;

        public int Id_movimiento { get => _id_movimiento; set => _id_movimiento = value; }
        public double Monto { get => _monto; set => _monto = value; }
        public string Concepto { get => _concepto; set => _concepto = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public int Id_cuenta { get => _id_cuenta; set => _id_cuenta = value; }
    }
}
