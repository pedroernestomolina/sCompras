using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.ListaAdm.ToolsPagoDoc
{
    public class Imp : IRepListAdm
    {
        private string _filtros;
        private List<CtaPagar.Tools.ToolsDoc.Vista.IdataItemCtaPend> _lst;


        public Imp()
        {
            _filtros = "";
            _lst = new List<CtaPagar.Tools.ToolsDoc.Vista.IdataItemCtaPend>();
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
                _lst.Add((CtaPagar.Tools.ToolsDoc.Vista.IdataItemCtaPend)rg);
            }
        }


        private void imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\ListaAdm\RepAdm_ToolsPagoDoc.rdlc";
            var ds = new DS_ADM();

            var it = 1;
            foreach (var rg in _lst)
            {
                DataRow rt = ds.Tables["ToolsPagoDocPend"].NewRow();
                rt["item"] = it;
                rt["fecha"] = rg.dataFechaDoc; 
                rt["proveedor"] = rg.dataCiRif + Environment.NewLine + rg.dataNombreRazonSocial;
                rt["docNro"] = rg.dataDocNro;
                rt["docTipo"] = rg.dataDocTipo;
                rt["importe"] = rg.dataImporte;
                rt["acumulado"] = rg.dataAcumulado;
                rt["resta"] = rg.dataResta;
                ds.Tables["ToolsPagoDocPend"].Rows.Add(rt);
                it++;
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("ToolsPagoDocPend", ds.Tables["ToolsPagoDocPend"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}