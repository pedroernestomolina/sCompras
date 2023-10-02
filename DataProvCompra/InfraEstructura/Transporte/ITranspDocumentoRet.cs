using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspDocumentoRet
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha>
            Transporte_DocumentoRet_GetLista(OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Filtro filtro);
    }
}