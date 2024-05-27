using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class ProveedorModel
    {
        Int32 _id_proveedor;
        String _proveedor;
        String _contacto;
        String _nit;
        String _direccion;

        public int Id_proveedor { get => _id_proveedor; set => _id_proveedor = value; }
        public string Proveedor { get => _proveedor; set => _proveedor = value; }
        public string Contacto { get => _contacto; set => _contacto = value; }
        public string Nit { get => _nit; set => _nit = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
    }
}
