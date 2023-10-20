using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Maestros.Beneficiario
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
                var r01 = Sistema.MyData.Transporte_Beneficiario_GetLista();
                Imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Alerta(e.Message);
            }
        }


        private void Imprimir(List<OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Maestros\RepMaestro_Beneficiario.rdlc";
            var ds = new DS_MAESTRO();

            foreach (var rg in list)
            {
                DataRow rt = ds.Tables["Beneficiario"].NewRow();
                rt["nombre"] = rg.cirif+Environment.NewLine+rg.nombreRazonSocial;
                rt["direccion"] = rg.direccion;
                rt["telefono"] = rg.telefono;
                rt["estatus"] = rg.estatus.Trim().ToUpper() == "1" ? "INACTIVO" : "";
                ds.Tables["Beneficiario"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Beneficiario", ds.Tables["Beneficiario"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}