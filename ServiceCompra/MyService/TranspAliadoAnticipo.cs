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
        public DtoLib.Resultado 
            Transporte_Aliado_Anticipo_Agregar(DtoLibTransporte.Aliado.Anticipo.Agregar.Ficha ficha)
        {
            return ServiceProv.Transporte_Aliado_Anticipo_Agregar(ficha);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Anticipo.Anular.Ficha>
            Transporte_Aliado_Anticipo_Anular_ObtenerData(int idMov)
        {
            return ServiceProv.Transporte_Aliado_Anticipo_Anular_ObtenerData(idMov);
        }
        public DtoLib.Resultado 
            Transporte_Aliado_Anticipo_Anular(DtoLibTransporte.Aliado.Anticipo.Anular.Ficha ficha)
        {
            return ServiceProv.Transporte_Aliado_Anticipo_Anular(ficha);
        }
    }
}