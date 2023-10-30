using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.ListaGeneralDoc
{
    public class Imp : srcTransporte.Reportes.IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Filtro _filtro;


        public Imp()
        {
        }
        public void setFiltros(object filtros)
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
            _filtro = new OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Filtro()
            {
                Desde = ft.Desde,
                Hasta = ft.Hasta,
                EstatusDoc = _estatusDoc,
                IdConcepto = ft.IdConcepto,
                IdProveedor = ft.IdProveedor,
            };
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Compras_GeneralDoc_GetLista(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Documentos\RepDoc_General.rdlc";
            var ds = new DS_REPDOC();

            foreach (var rg in list)
            {
                DataRow rt = ds.Tables["General"].NewRow();
                rt["fechaDoc"] = rg.fechaDoc;
                rt["siglasDoc"] = rg.siglasDoc;
                rt["documento"] = rg.numeroDoc;
                rt["prov"] = rg.prvCiRif + Environment.NewLine + rg.prvNombre;
                rt["neto"] = rg.netoDoc * rg.signoDoc;
                rt["totalDoc"] = rg.totalDoc * rg.signoDoc;
                rt["montoExento"] = rg.montoExento * rg.signoDoc;
                rt["montoBase"] = rg.montoBase * rg.signoDoc;
                rt["montoIva"] = rg.montoImpuesto * rg.signoDoc;
                rt["montoIgtf"] = rg.montoIgtf * rg.signoDoc;
                rt["estatus"] = rg.estatusDoc == "1" ? "ANULADO" : "";
                if (rg.estatusDoc.Trim().ToUpper() == "1")
                {
                    rt["neto"] = 0m;
                    rt["totalDoc"] = 0m;
                    rt["montoIva"] = 0m;
                    rt["montoExento"] = 0m;
                    rt["montoIgtf"] = 0m;
                    rt["montoBase"] = 0m;
                }
                ds.Tables["General"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("General", ds.Tables["General"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}