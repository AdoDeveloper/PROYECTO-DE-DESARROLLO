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
                case 11:
                    return Resource1.maintain;
                case 16:
                    return Resource1.proveedor;
                case 12:
                    return Resource1.productos;
                case 6:
                    return Resource1.buscarproducto;
                case 7:
                    return Resource1.factura;
                case 8:
                    return Resource1.makeventas;
                case 20:
                    return Resource1.empleados;
                case 24:
                    return Resource1.clientes;
                case 29:
                    return Resource1.usuarios;
                case 34:
                    return Resource1.report;
                case 35:
                    return Resource1.vent;
                case 36:
                    return Resource1.about;
                case 38:
                    return Resource1.realizar_compra;
                case 37:
                    return Resource1.compras;
                default:
                    return null;
            }
        }
    }
}
