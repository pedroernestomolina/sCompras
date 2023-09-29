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
            Transporte_Caja_Movimientos_Agregar(DtoLibTransporte.Caja.Movimiento.Crud.Agregar.Ficha ficha)
        {
            return ServiceProv.Transporte_Caja_Movimientos_Agregar(ficha);
        }
        public DtoLib.ResultadoLista<DtoLibTransporte.Caja.Movimiento.Lista.Ficha>
            Transporte_Caja_Movimientos_GetLista(DtoLibTransporte.Caja.Movimiento.Lista.Filtro filtro)
        {
            return ServiceProv.Transporte_Caja_Movimientos_GetLista(filtro);
        }
        public DtoLib.Resultado
            Transporte_Caja_Movimientos_Anular(DtoLibTransporte.Caja.Movimiento.Crud.Anular.Ficha ficha)
        {
            return ServiceProv.Transporte_Caja_Movimientos_Anular(ficha);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Movimiento.Crud.Anular.Ficha> 
            Transporte_Caja_Movimientos_Anular_ObtenerData(int idMov)
        {
            return ServiceProv.Transporte_Caja_Movimientos_Anular_ObtenerData(idMov);
        }
    }
}