using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Maestros.Caja
{
    public class Imp: IRep
    {
        public Imp()
        {
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Caja_GetLista();
                Imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Alerta(e.Message);
            }
        }


        private void Imprimir(List<OOB.LibCompra.Transporte.Caja.Lista.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Maestros\RepMaestro_Caja.rdlc";
            var ds = new DS_MAESTRO();

            foreach (var rg in list)
            {
                var _saldoAct = rg.saldoInicial + rg.montoPorIngresos - rg.montoPorEgresos;
                DataRow rt = ds.Tables["Caja"].NewRow();
                rt["cajaDesc"] = rg.codigo+Environment.NewLine+rg.descripcion;
                rt["saldoIni"] = rg.saldoInicial;
                rt["ingresos"] = rg.montoPorIngresos;
                rt["egresos"] = rg.montoPorEgresos;
                rt["esDivisa"] = rg.esDivisa.Trim().ToUpper() == "1" ? "$" : "";
                rt["saldoActual"] = _saldoAct;
                ds.Tables["Caja"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Caja", ds.Tables["Caja"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}