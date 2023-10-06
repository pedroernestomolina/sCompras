using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.ListaAdm.CajaMov
{
    public class Imp : IRepListAdm
    {
        private string _filtros;
        private List<srcTransporte.Caja.Administrador.Vistas.IdataItem> _lst;


        public Imp()
        {
            _filtros = "";
            _lst = new List<srcTransporte.Caja.Administrador.Vistas.IdataItem>(); 
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
                _lst.Add((srcTransporte.Caja.Administrador.Vistas.IdataItem)rg);
            }
        }


        private void imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\ListaAdm\RepAdm_CajaMov.rdlc";
            var ds = new DS_ADM();

            foreach (var rg in _lst)
            {
                DataRow rt = ds.Tables["CajaMov"].NewRow();
                rt["fecha"] = rg.FechaMov;
                rt["monto"] = rg.Monto*rg.SignoMov;
                rt["motivo"] = rg.Motivo;
                rt["estatus"] = rg.Estatus;
                rt["tipoMov"] = rg.TipoMov;
                rt["cajaDesc"] = rg.CajaDesc;
                rt["esDivisa"] = rg.EsDivisa;
                ds.Tables["CajaMov"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("CajaMov", ds.Tables["CajaMov"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}