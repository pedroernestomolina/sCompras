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
        public DtoLib.ResultadoId 
            Transporte_Beneficiario_Mov_Agregar(DtoLibTransporte.Beneficiario.Mov.Agregar.Ficha ficha)
        {
            return ServiceProv.Transporte_Beneficiario_Mov_Agregar(ficha);
        }
        //
        public DtoLib.ResultadoLista<DtoLibTransporte.Beneficiario.Mov.Lista.Ficha> 
            Transporte_Beneficiario_Mov_GetLista(DtoLibTransporte.Beneficiario.Mov.Lista.Filtro filtro)
        {
            return ServiceProv.Transporte_Beneficiario_Mov_GetLista(filtro);
        }
        //
        public DtoLib.Resultado Transporte_Beneficiario_Mov_Anular(DtoLibTransporte.Beneficiario.Mov.Anular.Ficha ficha)
        {
            return ServiceProv.Transporte_Beneficiario_Mov_Anular(ficha);
        }
        //

        public DtoLib.ResultadoEntidad<DtoLibTransporte.Beneficiario.Mov.Anular.Ficha> 
            Transporte_Beneficiario_Mov_Anular_ObtenerData(int idMov)
        {
            return ServiceProv.Transporte_Beneficiario_Mov_Anular_ObtenerData(idMov);
        }
    }
}