using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.ListaAdm.ToolsAliado
{
    public class Imp : IRepListAdm
    {
        private string _filtros;
        private List<CtaPagar.ToolsAliados.Vistas.IdataAliado> _lst;


        public Imp()
        {
            _filtros = "";
            _lst = new List<CtaPagar.ToolsAliados.Vistas.IdataAliado>();
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
                _lst.Add((CtaPagar.ToolsAliados.Vistas.IdataAliado)rg);
            }
        }


        private void imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\ListaAdm\RepAdm_ToolsAliado.rdlc";
            var ds = new DS_ADM();
            var it = 1;

            foreach (var rg in _lst)
            {
                DataRow rt = ds.Tables["ToolsAliadoPagoPend"].NewRow();
                rt["item"] = it;
                rt["aliado"] = rg.ciRif + Environment.NewLine + rg.nombreRazonSocial;
                rt["pendiente"] = rg.pendiente;
                rt["anticipos"] = rg.anticipos;
                rt["resta"] = rg.montoResta;
                rt["cntDoc"] = rg.cntDocPend;
                //rt["recibo"] = rg.ReciboNro;
                //rt["aliado"] = rg.AliadoCiRif + Environment.NewLine + rg.AliadoNombre;
                //rt["procesado"] = rg.Procesado;
                //rt["monto"] = rg.Monto;
                //if (rg.Estatus.Trim() != "")
                //{
                //    rt["monto"] = 0m;
                //}
                //rt["estatus"] = rg.Estatus;
                ds.Tables["ToolsAliadoPagoPend"].Rows.Add(rt);
                it++;
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("ToolsAliadoPagoPend", ds.Tables["ToolsAliadoPagoPend"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}