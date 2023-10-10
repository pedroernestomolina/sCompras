using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using ModCompra.srcTransporte.Reportes.ListaAdm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Maestros.Concepto
{
    public class Imp : IRep
    {
        public Imp()
        {
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Documento_Concepto_GetLista();
                Imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Alerta(e.Message);
            }
        }
        private void Imprimir(List<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha> lst)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Maestros\RepMaestro_Concepto.rdlc";
            var ds = new DS_MAESTRO();

            foreach (var rg in lst)
            {
                DataRow rt = ds.Tables["Concepto"].NewRow();
                rt["codigo"] = rg.codigo;
                rt["descripcion"] = rg.descripcion;
                ds.Tables["Concepto"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Concepto", ds.Tables["Concepto"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}