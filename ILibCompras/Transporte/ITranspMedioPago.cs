using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras.Transporte
{
    public interface ITranspMedioPago
    {
        DtoLib.ResultadoLista<DtoLibTransporte.MedioPago.Lista.Ficha> 
            Transporte_MedioPago_GetLista();
        DtoLib.ResultadoEntidad<DtoLibTransporte.MedioPago.Entidad.Ficha> 
            Transporte_MedioPago_GetFichaById(string id);
    }
}