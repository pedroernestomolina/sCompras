using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Proveedor
{
    
    public class Enumerados
    {

        public enum EnumMetodoBusqueda { SnDefinir = -1, Codigo = 1, Nombre, CiRif };
        public enum EnumEstatus { SnDefinir = -1, Activo = 1, Inactivo };
        public enum EnumDenominacionFiscal { SnDefinir = -1, Contribuyente = 1, NoContribuyente };

    }

}