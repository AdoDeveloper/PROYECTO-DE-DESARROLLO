using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class RolModel
    {
        Int32 _idRol;
        String _Rol;

        public int IdRol { get => _idRol; set => _idRol = value; }
        public string Rol { get => _Rol; set => _Rol = value; }
    }
}
