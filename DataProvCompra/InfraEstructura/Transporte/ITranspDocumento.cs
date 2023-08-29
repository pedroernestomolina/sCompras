using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspDocumento
    {
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Resultado>
            Transporte_Documento_Agregar_CompraGrasto(OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto.Ficha ficha);


        OOB.ResultadoLista<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha>
            Transporte_Documento_Concepto_GetLista();
    }
}