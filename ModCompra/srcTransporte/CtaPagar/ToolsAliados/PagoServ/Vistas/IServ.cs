using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Vistas
{
    public interface IServ
    {
        int Get_CntItem { get; }
        decimal Get_MontoPendiente { get; }
        decimal Get_MontoSeleccionadoPagar { get; }
        BindingSource Get_Source { get; }
        string Get_DescripcionServicioActual { get; }

        void Inicializa();
        void CargarData();
        void setDataCargar(List<IdataServ> lst);
        void SeleccionarItem();
    }
}