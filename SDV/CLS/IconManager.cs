using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV.CLS
{
    static class IconManager
    {

        static public Image obtenerIconPorOpcion(Int32 IDOpc)
        {
            switch (IDOpc)
            {
                case 5:
                    return Resource1.ventas;
                case 9:
                    return Resource1.rolespermisos;
                default:
                    return null;
            }
        }
    }
}
