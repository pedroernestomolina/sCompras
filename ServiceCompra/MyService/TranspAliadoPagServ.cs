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
        public DtoLib.Resultado 
            Transporte_Aliado_PagoServ_AgregarPago(DtoLibTransporte.Aliado.PagoServ.AgregarPago.Ficha ficha)
        {
            return ServiceProv.Transporte_Aliado_PagoServ_AgregarPago(ficha);
        }
    }
}