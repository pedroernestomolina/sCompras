using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.ListaAdm.DocumentoRet
{
    public class Imp : IRepListAdm
    {
        private string _filtros;
        private List<Retencion.Administrador.Vistas.IdataItem> _lst;


        public Imp()
        {
            _filtros = "";
            _lst = new List<Retencion.Administrador.Vistas.IdataItem>();
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
                _lst.Add((Retencion.Administrador.Vistas.IdataItem)rg);
            }
        }


        private void imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\ListaAdm\RepAdm_Retencion.rdlc";
            var ds = new DS_ADM();

            foreach (var rg in _lst)
            {
                var it = (Retencion.Administrador.Handler.dataItem)rg;
                var _monto = it.Ficha.retMonto * it.Ficha.signoRet;
                if (it.Ficha.estatusAnulado == "1") 
                {
                    _monto = 0m;
                }
                DataRow rt = ds.Tables["Retencion"].NewRow();
                rt["fecha"] = rg.Fecha;
                rt["tipoRet"] = rg.TipoRet;
                rt["documento"] = rg.Documento;
                rt["prov"] = rg.ProvCiRif+Environment.NewLine+rg.ProvNombre;
                rt["estatus"] = rg.Estatus;
                rt["tasaRet"] = rg.RetTasa;
                rt["montoRet"] = _monto;
                ds.Tables["Retencion"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Retencion", ds.Tables["Retencion"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}