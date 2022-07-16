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

        public OOB.ResultadoLista<OOB.LibCompra.ReporteProv.Maestro.Ficha> ReportesProv_Maestro(OOB.LibCompra.ReporteProv.Maestro.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.ReporteProv.Maestro.Ficha>();

            var filtroDto = new DtoLibCompra.Reportes.Proveedor.Maestro.Filtro()
            {
                estatus = filtro.estatus,
                idEstado = filtro.idEstado,
                idGrupo = filtro.idGrupo,
            };
            var r01 = MyData.ReportesProv_Maestro(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.ReporteProv.Maestro.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCompra.ReporteProv.Maestro.Ficha()
                        {
                            ciRif = s.ciRif,
                            codigo = s.codigo,
                            dirFiscal = s.dirFiscal,
                            estatus = s.estatus,
                            nombre = s.nombre,
                            telefono = s.telefono,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}