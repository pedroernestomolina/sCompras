using ServiceCompra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.MyService
{
    public partial class Service: IService
    {
        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.ServPrestado.Ficha> 
            Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(int idAliado)
        {
            return ServiceProv.Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(idAliado);
        }
        public DtoLib.ResultadoId
            Transporte_Aliado_PagoServ_AgregarPago(DtoLibTransporte.Aliado.PagoServ.AgregarPago.Ficha ficha)
        {
            return ServiceProv.Transporte_Aliado_PagoServ_AgregarPago(ficha);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.PagoServ.AnularPago.Ficha> 
            Transporte_Aliado_PagoServ_AnularPago_ObtenerData(int idMovPago)
        {
            return ServiceProv.Transporte_Aliado_PagoServ_AnularPago_ObtenerData(idMovPago);
        }
        public DtoLib.Resultado 
            Transporte_Aliado_PagoServ_AnularPago(DtoLibTransporte.Aliado.PagoServ.AnularPago.Ficha ficha)
        {
            return ServiceProv.Transporte_Aliado_PagoServ_AnularPago(ficha);
        }
        //
        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.PagoServ.Lista.Ficha> 
            Transporte_Aliado_PagoServ_GetLista(DtoLibTransporte.Aliado.PagoServ.Lista.Filtro filtro)
        {
            return ServiceProv.Transporte_Aliado_PagoServ_GetLista(filtro);
        }
    }
}