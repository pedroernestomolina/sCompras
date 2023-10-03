using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Componente.Administrador.Vistas
{
    public interface IAdmin: HlpGestion.IGestion, HlpGestion.IAbandonar
    {
        ILista data { get; }
        string Get_TituloAdm { get; }
        int Get_CntItem { get; }


        void Buscar();
        void AnularItem();
        void VisualizarDocumento();
        void Imprimir();
    }
}