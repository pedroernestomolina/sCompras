using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelDocumentos.reportes
{
    public class ImpRepListaDoc : IRepListaDoc
    {
        private string _filtros;
        private string _info;
        private IEnumerable<__.Modelos.PanelDocumentos.IItemDesplegar> _lst;
        //
        public ImpRepListaDoc()
        {
            _filtros = "";
            _info = "";
            _lst = new List<__.Modelos.PanelDocumentos.IItemDesplegar>();
        }
        public void Generar()
        {
            imprimir();
        }
        public void setFiltrosBusq(string filtros)
        {
            _filtros = filtros;
        }
        public void setDataCargar(IEnumerable<__.Modelos.PanelDocumentos.IItemDesplegar> lst)
        {
            _lst = lst;
        }
        public void setInfoEntidad(string info)
        {
            _info = info;
        }
        private void imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"_CtasPorPagar\reportes\CtasPendiente_Entidad.rdlc";
            var ds = new _CtasPorPagar.reportes.DS();
            var it = 1;
            foreach (var rg in _lst)
            {
                DataRow rt = ds.Tables["CtaPend_Entidad"].NewRow();
                rt["item"] = it;
                rt["docNumero"] = rg.docNumero;
                rt["docTipo"] = rg.docTipo;
                rt["docFechaEmision"] = rg.docFechaEmision;
                rt["docFechaVence"] = rg.docFechaVence;
                rt["diasVencida"] = rg.diasVencida;
                rt["montoDeuda"] = rg.MontoDeuda;
                rt["montoAcumulado"] = rg.MontoAcumulado;
                rt["montoPendiente"] = rg.MontoPendiente;
                ds.Tables["CtaPend_Entidad"].Rows.Add(rt);
                it++;
            }
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("INFO_ENTIDAD", _info));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("CtaPend_Entidad", ds.Tables["CtaPend_Entidad"]));
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}