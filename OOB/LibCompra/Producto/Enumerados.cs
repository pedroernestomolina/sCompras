using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Producto
{
    
    public class Enumerados
    {

        public enum EnumMetodoBusqueda { SnDefinir = -1, Codigo = 1, Nombre, Referencia, CodBarra };
        public enum EnumEstatus { SnDefinir = -1, Activo = 1, Inactivo };
        public enum EnumAdministradorPorDivisa { SnDefinir = -1, Si = 1, No };

    }

}