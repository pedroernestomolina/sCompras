using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspMedioPago
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.MedioPago.Lista.Ficha>
            Transporte_MedioPago_GetLista();
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.MedioPago.Entidad.Ficha>
            Transporte_MedioPago_GetFichaById(string id);
    }
}