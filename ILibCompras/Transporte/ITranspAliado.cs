using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspAliado
    {
        DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Entidad.Ficha>
            Transporte_Aliado_GetFichaById(int id);

        DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Pendiente.Ficha>
            Transporte_Aliado_Pediente_GetLista();
        DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Pendiente.Ficha>
            Transporte_Aliado_Pediente_GetByIdAliado(int idAliado);
    }
}