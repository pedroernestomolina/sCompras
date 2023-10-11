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
        public DtoLib.ResultadoLista<DtoLibTransporte.Beneficiario.Lista.Ficha> 
            Transporte_Beneficiario_GetLista()
        {
            return ServiceProv.Transporte_Beneficiario_GetLista();
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Beneficiario.Crud.Entidad.Ficha>
            Transporte_Beneficiario_GetById(int idBeneficiario)
        {
            return ServiceProv.Transporte_Beneficiario_GetById(idBeneficiario);
        }
        public DtoLib.ResultadoId 
            Transporte_Beneficiario_Agregar(DtoLibTransporte.Beneficiario.Crud.Agregar.Ficha ficha)
        {
            return ServiceProv.Transporte_Beneficiario_Agregar(ficha);
        }
        public DtoLib.Resultado 
            Transporte_Beneficiario_Editar(DtoLibTransporte.Beneficiario.Crud.Editar.Ficha ficha)
        {
            return ServiceProv.Transporte_Beneficiario_Editar(ficha);
        }
    }
}