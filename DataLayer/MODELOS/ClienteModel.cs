using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class ClienteModel
    {
        Int32 id_cliente;
        String cliente;
        String telefono;
        String correo;
        String dui;

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Dui { get => dui; set => dui = value; }
    }
}
