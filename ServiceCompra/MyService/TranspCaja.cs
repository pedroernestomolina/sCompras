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
        public DtoLib.ResultadoLista<DtoLibTransporte.Caja.Lista.Ficha> 
            Transporte_Caja_GetLista()
        {
            return ServiceProv.Transporte_Caja_GetLista();
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Crud.Entidad.Ficha>
            Transporte_Caja_GetById(int idCja)
        {
            return ServiceProv.Transporte_Caja_GetById(idCja);
        }
    }
}