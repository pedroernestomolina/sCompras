using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspAliadoPagServ
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha>
            Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(int idAliado);
        OOB.Resultado
            Transporte_Aliado_PagoServ_AgregarPago(OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago.Ficha ficha);
        OOB.Resultado
            Transporte_Aliado_PagoServ_AnularPago(int idMov);
        //
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha>
            Transporte_Aliado_PagoServ_GetLista(OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Filtro filtro);
    }
}