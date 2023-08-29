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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Agregar.CompraGasto.Resultado> 
            Transporte_Documento_Agregar_CompraGrasto(DtoLibTransporte.Documento.Agregar.CompraGasto.Ficha ficha)
        {
            return ServiceProv.Transporte_Documento_Agregar_CompraGrasto(ficha);
        }


        public DtoLib.ResultadoLista<DtoLibTransporte.Documento.Concepto.Entidad.Ficha> Transporte_Documento_Concepto_GetLista()
        {
            return ServiceProv.Transporte_Documento_Concepto_GetLista();
        }
    }
}
