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
        public DtoLib.ResultadoLista<DtoLibTransporte.MedioPago.Lista.Ficha> 
            Transporte_MedioPago_GetLista()
        {
            return ServiceProv.Transporte_MedioPago_GetLista();
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.MedioPago.Entidad.Ficha> 
            Transporte_MedioPago_GetFichaById(string id)
        {
            return ServiceProv.Transporte_MedioPago_GetFichaById(id);
        }
    }
}
