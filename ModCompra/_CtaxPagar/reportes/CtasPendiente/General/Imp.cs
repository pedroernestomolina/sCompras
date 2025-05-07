using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.reportes.CtasPendiente.General
{
    public class Imp : IRepLista
    {
        private string _filtros;
        private List<_CtaxPagar.Interfaces.IdataItemDocPend> _lst;
        //
        public Imp()
        {
            _filtros = "";
            _lst = new List<_CtaxPagar.Interfaces.IdataItemDocPend>();
        }
        public void Generar()
        {
            imprimir();
        }
        public void setFiltrosBusq(string filtros)
        {
            _filtros = filtros;
        }
        public void setDataCargar(IEnumerable<object> lst)
        {
            _lst.Clear();
            foreach (var rg in lst)
            {
                var nr = new dataItemDocPend(rg);
                _lst.Add(nr);
            }
        }
        private void imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"_CtaxPagar/Reportes/CtasPendiente_General.rdlc";
            var ds = new DS();
            var it = 1;
            foreach (var rg in _lst)
            {
                DataRow rt = ds.Tables["CtaPend_General"].NewRow();
                rt["item"] = it;
                rt["entidad"] = rg.CiRifEntidad + Environment.NewLine + rg.NombreEntidad;
                rt["montoDeuda"] = rg.MontoDeuda;
                rt["montoCredito"] = rg.MontoCredito;
                rt["montoAcumulado"] = rg.MontoAcumulado;
                rt["montoPendiente"] = rg.MontoPendiente;
                rt["cntDocDeuda"] = rg.CntDocDeuda;
                ds.Tables["CtaPend_General"].Rows.Add(rt);
                it++;
            }
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("CtaPend_General", ds.Tables["CtaPend_General"]));
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}