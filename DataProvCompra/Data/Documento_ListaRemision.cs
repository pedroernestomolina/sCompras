using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    public partial class DataProv: IData
    {
        public OOB.ResultadoLista<OOB.LibCompra.Documento.ListaRemision.Ficha>
            Compra_DocumentoGetListaRemision(OOB.LibCompra.Documento.ListaRemision.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Documento.ListaRemision.Ficha>();
            var _lst = new List<OOB.LibCompra.Documento.ListaRemision.Ficha>();
            //
            var filtroDto = new DtoLibCompra.Documento.ListaRemision.Filtro()
            {
                autoProveedor = filtro.autoProveedor,
            };
            var r01 = MyData.Compra_DocumentoGetListaRemision(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst= r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Documento.ListaRemision.Ficha()
                        {
                            auto = s.auto,
                            control = s.control,
                            docNombre = s.docNombre,
                            docNro = s.docNro,
                            docTipo = s.docTipo,
                            fechaEmision = s.fechaEmision,
                            montoDivisa = s.montoDivisa,
                            total = s.total,
                        };
                        return nr;
                    }).ToList();
                }
            }
            //
            rt.Lista = _lst;
            return rt;
        }
    }
}