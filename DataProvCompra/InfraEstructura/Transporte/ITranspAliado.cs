using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspAliado
    {
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Aliado.Entidad.Ficha>
            Transporte_Aliado_GetFichaById(int id);
       OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha>
            Transporte_Aliado_Pediente_GetLista();
       OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha>
           Transporte_Aliado_Pediente_GetByIdAliado(int idAliado);
    }
}