using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Administrador.Handler
{
    public class dataFiltro: Vistas.IdataFiltro
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }


        public dataFiltro()
        {
            Desde = null;
            Hasta = null;
        }
        public void Inicializa()
        {
            Desde = null;
            Hasta = null;
        }
    }
}