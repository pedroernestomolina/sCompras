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
        public OOB.ResultadoLista<OOB.LibCompra.Documento.Lista.Ficha>
            Compra_DocumentoGetLista(OOB.LibCompra.Documento.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Documento.Lista.Ficha>();
            var _lst= new List<OOB.LibCompra.Documento.Lista.Ficha>();
            //
            var filtroDto = new DtoLibCompra.Documento.Lista.Filtro()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
                CodigoSuc = filtro.CodigoSuc,
                TipoDocumento = (DtoLibCompra.Enumerados.enumTipoDocumento)filtro.TipoDocumento,
                idProveedor = filtro.idProveedor,
            };
            var r01 = MyData.Compra_DocumentoGetLista(filtroDto);
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
                        var nr = new OOB.LibCompra.Documento.Lista.Ficha()
                        {
                            auto = s.auto,
                            codigoSuc = s.codigoSuc,
                            esAnulado = s.esAnulado,
                            fechaEmision = s.fechaEmision,
                            fechaRegistro = s.fechaRegistro,
                            monto = s.monto,
                            montoDivisa = s.montoDivisa,
                            provCiRif = s.provCiRif,
                            provNombre = s.provNombre,
                            situacion = s.situacion,
                            tipoDoc = (OOB.LibCompra.Documento.Enumerados.enumTipoDocumento)s.tipoDoc,
                            tipoDocNombre = s.tipoDocNombre,
                            documentoNro = s.documento,
                            codigoTipo = s.tipo,
                            Signo = s.signo,
                            ControlNro = s.control,
                            Aplica = s.aplica,
                            nomSucursal = s.nomSucursal,
                            IsDocCompraMercancia = s.estatusDocCompraMercGasto.Trim().ToUpper()=="1",
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
