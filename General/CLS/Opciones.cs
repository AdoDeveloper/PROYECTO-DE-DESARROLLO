using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    public class Opciones
    {
        Int32 _IDOpcion;
        String _Opcion;
        Int32 _IDPadre;

        public Opciones(int iDOpcion, string opcion, int iDPadre)
        {
            IDOpcion = iDOpcion;
            Opcion = opcion;
            IDPadre = iDPadre;
        }

        public int IDOpcion { get => _IDOpcion; set => _IDOpcion = value; }
        public string Opcion { get => _Opcion; set => _Opcion = value; }
        public int IDPadre { get => _IDPadre; set => _IDPadre = value; }

        //ctrl r e
        //


    }
}
