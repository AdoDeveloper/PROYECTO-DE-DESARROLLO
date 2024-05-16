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
        

        public OpcionModel(int iDOpcion, string opcion)
        {
            IDOpcion = iDOpcion;
            Opcion = opcion;
            
        }

        public OpcionModel() { }

        public int IDOpcion { get => _IDOpcion; set => _IDOpcion = value; }
        public string Opcion { get => _Opcion; set => _Opcion = value; }
        

        //ctrl r e
        //


    }
}
