using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class UsuarioModel
    {
        Int32 _id_usuario;
        String _usuario;
        String _clave;
        Int32 _id_empleado;
        Int32 _id_rol;
        byte[] _imagen;

        public int ID_Usuario { get => _id_usuario; set => _id_usuario = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public int ID_Empleado { get => _id_empleado; set => _id_empleado = value; }
        public int ID_Rol { get => _id_rol; set => _id_rol = value; }
        public byte[] Imagen { get => _imagen; set => _imagen = value; }
    }
}
