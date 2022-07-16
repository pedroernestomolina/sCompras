using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros
{
    
    public interface IReporte
    {


        IFiltros Filtros { get; }


        void Generar();
        void setDataFiltros(data filtros);

    }

}