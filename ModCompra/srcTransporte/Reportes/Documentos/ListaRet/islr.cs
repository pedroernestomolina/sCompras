using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.ListaRet
{
    public class islr: baseImp
    {
        public islr()
            : base()
        {
        }
        protected override void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Documentos\RepDoc_RetIslr.rdlc";
            var ds = new DS_REPDOC();

            foreach (var rg in list)
            {
                DataRow rt = ds.Tables["Ret_Islr"].NewRow();
                rt["documento"] = rg.numDoc;
                rt["prov"] = rg.prvCiRif+Environment.NewLine+rg.prvNombre;
                rt["montoTotal"] = rg.totalDoc;
                rt["montoExento"] = rg.montoExento;
                rt["montoBase"] = rg.montoBase1+rg.montoBase2+rg.montoBase3;
                rt["montoImpuesto"] = rg.montoImp1+rg.montoImp2+rg.montoImp3;
                rt["tasaRet"] = rg.tasaRet;
                rt["sustraendo"] = rg.retSustraendo;
                rt["montoRetenido"] = rg.totalRet;
                if (rg.estatusAnulado.Trim().ToUpper() == "1")
                {
                    rt["montoTotal"] = 0m;
                    rt["montoExento"] = 0m;
                    rt["montoBase"] = 0m;
                    rt["montoImpuesto"] = 0m;
                    rt["tasaRet"] = 0m;
                    rt["sustraendo"] = 0m;
                    rt["montoRetenido"] = 0m;
                }
                rt["fechaRet"] = rg.fechaDoc;
                ds.Tables["Ret_Islr"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Ret_Islr", ds.Tables["Ret_Islr"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

        protected override void _setFiltros(object filtros)
        {
            var ft = (Reportes.RepFiltro.Vista.IFiltros)filtros;
            var _estatusDoc = "";
            if (ft.EstatusDocumento != RepFiltro.Vista.enumerados.EstatusDoc.SinDefinir)
            {
                _estatusDoc = "0";
                if (ft.EstatusDocumento == RepFiltro.Vista.enumerados.EstatusDoc.Inactivo)
                {
                    _estatusDoc = "1";
                }
            }
            _filtro = new OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Filtro()
            {
                tipoRet = OOB.LibCompra.Transporte.Reportes.Compras.enumerados.tipoRetencion.ISLR,
                Desde = ft.Desde,
                EstatusDoc = _estatusDoc,
                Hasta = ft.Hasta,
                IdProveedor = ft.IdProveedor,
            };
        }
    }
}