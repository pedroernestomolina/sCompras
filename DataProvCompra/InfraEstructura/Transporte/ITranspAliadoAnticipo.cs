using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspAliadoAnticipo
    {
        OOB.Resultado
            Transporte_Aliado_Anticipo_Agregar(OOB.LibCompra.Transporte.Aliado.Anticipo.Agregar.Ficha ficha);
        OOB.Resultado
            Transporte_Aliado_Anticipo_Anular(int idMov);
        //
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.Anticipo.Lista.Ficha>
            Transporte_Aliado_Anticipo_GetLista(OOB.LibCompra.Transporte.Aliado.Anticipo.Lista.Filtro filtro);
    }
}