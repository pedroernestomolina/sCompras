using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces.Transporte
{
    public interface ITranspAliadoPagServ
    {
        DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.ServPrestado.Ficha>
            Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(int idAliado);
        DtoLib.ResultadoId
            Transporte_Aliado_PagoServ_AgregarPago(DtoLibTransporte.Aliado.PagoServ.AgregarPago.Ficha ficha);
        DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.PagoServ.AnularPago.Ficha>
            Transporte_Aliado_PagoServ_AnularPago_ObtenerData(int idMovPago);
        DtoLib.Resultado
            Transporte_Aliado_PagoServ_AnularPago(DtoLibTransporte.Aliado.PagoServ.AnularPago.Ficha ficha);
        //
        DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.Lista.Ficha>
            Transporte_Aliado_PagoServ_GetLista(DtoLibTransporte.Aliado.PagoServ.Lista.Filtro filtro);
    }
}