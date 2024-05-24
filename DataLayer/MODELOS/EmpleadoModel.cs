using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class EmpleadoModel
    {
         Int32 _id_empleado;
         String _nombres;
         String _apellidos;
         String _dui;
         String _direccion;
         String _telefono;

        public int ID_Empleado { get => _id_empleado; set => _id_empleado = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string DUI { get => _dui; set => _dui = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
    }
}
