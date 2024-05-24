using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MODELOS
{
    public class OpcionModel
    {
        Int32 _IDOpcion;
        String _Opcion;
        Int32 _IDPadre;
        Int32 submenu;
        List<OpcionModel> _SubOpciones = new List<OpcionModel>();



        public OpcionModel(int iDOpcion, string opcion, int iDPadre, int submenu, List<OpcionModel> subOpciones)
        {
            IDOpcion = iDOpcion;
            Opcion = opcion;
            _IDPadre = iDPadre;
            this.submenu = submenu;
            SubOpciones = subOpciones;
        }

        public OpcionModel() { }

        public int IDOpcion { get => _IDOpcion; set => _IDOpcion = value; }
        public string Opcion { get => _Opcion; set => _Opcion = value; }
        public int IDPadre { get => _IDPadre; set => _IDPadre = value; }
        public int Submenu { get => submenu; set => submenu = value; }
        public List<OpcionModel> SubOpciones { get => _SubOpciones; set => _SubOpciones = value; }


        //ctrl r e
        //


    }
}
