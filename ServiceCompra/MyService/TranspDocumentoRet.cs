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
        public DtoLib.ResultadoLista<DtoLibTransporte.DocumentoRet.ListaAdm.Ficha> 
            Transporte_DocumentoRet_GetLista(DtoLibTransporte.DocumentoRet.ListaAdm.Filtro filtro)
        {
            return ServiceProv.Transporte_DocumentoRet_GetLista(filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha> 
            Transporte_DocumentoRet_Crud_Corrector_ObtenerData(string idDoc)
        {
            return ServiceProv.Transporte_DocumentoRet_Crud_Corrector_ObtenerData(idDoc);
        }
        //
        public DtoLib.Resultado 
            Transporte_DocumentoRet_Crud_Anular_Procesar(DtoLibTransporte.DocumentoRet.Crud.Anular.Procesar.Ficha ficha)
        {
            return ServiceProv.Transporte_DocumentoRet_Crud_Anular_Procesar(ficha);
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.DocumentoRet.Crud.Anular.ObtenerData.Ficha> 
            Transporte_DocumentoRet_Crud_Anular_ObtenerData(string idRet)
        {
            return ServiceProv.Transporte_DocumentoRet_Crud_Anular_ObtenerData(idRet);
        }
    }
}