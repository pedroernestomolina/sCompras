using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.ListaAdm.CxpPagosEmitidos
{
    public class Imp : IRepListAdm
    {
        private string _filtros;
        private List<CtaPagar.Tools.Administrador.Handler.dataItem> _lst;


        public Imp()
        {
            _filtros = "";
            _lst = new List<CtaPagar.Tools.Administrador.Handler.dataItem>();
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
                _lst.Add((CtaPagar.Tools.Administrador.Handler.dataItem)rg);
            }
        }


        private void imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\ListaAdm\RepAdm_DocPagosEmitidos.rdlc";
            var ds = new DS_ADM();

            foreach (var rg in _lst)
            {
                var _importe = rg.EMonto ;
                if (rg.EEstatus.Trim().ToUpper() != "")
                {
                    _importe = 0m;
                }
                DataRow rt = ds.Tables["CxpDocPagosEmitidos"].NewRow();
                rt["proveedor"] = rg.EProvCiRif .Trim() + Environment.NewLine + rg.EProvNombre.Trim();
                rt["reciboNro"] = rg.EReciboNro;
                rt["fecha"] = rg.EFechaMov;
                rt["importe"] = _importe;
                rt["tasaFactor"] = rg.Ficha.tasaFactor;
                rt["estatus"] = rg.EEstatus ;
                rt["nota"] = rg.EMotivo;
                ds.Tables["CxpDocPagosEmitidos"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("CxpDocPagosEmitidos", ds.Tables["CxpDocPagosEmitidos"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}