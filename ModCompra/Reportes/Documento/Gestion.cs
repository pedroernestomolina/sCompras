using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Documento
{
    
    public class Gestion
    {
        private OOB.LibCompra.Documento.Visualizar.Ficha ficha;


        public Gestion(OOB.LibCompra.Documento.Visualizar.Ficha ficha)
        {
            this.ficha = ficha;
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Documento.rdlc";
            var ds = new DS();

            DataRow rt = ds.Tables["DocEncabezado"].NewRow();
            rt["provNombre"] = ficha.provNombre;
            rt["provCiRif"] = ficha.provCiRif;
            rt["provCodigo"] = ficha.provCodigo;
            rt["provTelefono"] = ficha.provTelefono;
            rt["provDireccion"] = ficha.provDirFiscal;
            rt["documento"] = ficha.documentoNro;
            rt["control"] = ficha.controlNro;
            rt["fechaEmision"] = ficha.fechaEmision;
            rt["mesAnoRelacion"] = ficha.mesRelacion+"/"+ficha.anoRelacion;
            rt["fechaVencimiento"] = ficha.fechaVencimiento;
            rt["ordenCompra"] = ficha.ordenCompraNro;
            rt["montoBase"] = ficha.montoBase;
            rt["montoImpuesto"] = ficha.montoImpuesto;
            rt["montoTotal"] = ficha.montoTotal;
            rt["subTotal"] = ficha.subTotal+(ficha.montoDescuento-ficha.montoCargo);
            rt["dsctoP"] = "Descuento "+ficha.descuentoPorct.ToString("n2")+"%";
            rt["cargoP"] = "Cargo" + ficha.cargoPorct.ToString("n2") + "%";
            rt["dsctoM"] = ficha.montoDescuento;
            rt["cargoM"] = ficha.montoCargo;
            rt["montoExento"] = ficha.montoExento;
            rt["montoBase1"] = ficha.montoBase1;
            rt["montoBase2"] = ficha.montoBase2;
            rt["montoBase3"] = ficha.montoBase3;
            rt["montoImp1"] = ficha.montoIva1;
            rt["montoImp2"] = ficha.montoIva2;
            rt["montoImp3"] = ficha.montoIva3;
            rt["tasaIva1"] = ficha.tasaIva1;
            rt["tasaIva2"] = ficha.tasaIva2;
            rt["tasaIva3"] = ficha.tasaIva3;
            rt["montoDivisa"] = ficha.montoDivisa;
            rt["fechaHoraRegistro"] = ficha.fechaRegistro.ToShortDateString()+", "+ficha.horaRegistro;
            rt["factorCambio"] = ficha.factorCambio;
            rt["notas"] = ficha.notas;
            rt["aplica"] = ficha.aplica;
            ds.Tables["DocEncabezado"].Rows.Add(rt);

            foreach (var it in ficha.detalles.ToList())
            {
                var importeDivisa = it.importe / ficha.factorCambio;
                var precioFacturaDivisa = it.precioFactura / ficha.factorCambio;
                var cntUnd = it.cntFactura * it.contenido;

                DataRow r = ds.Tables["DocDetalle"].NewRow();
                r["prdCodigo"] = "";
                r["prdNombre"] = it.prdCodigo+Environment.NewLine+it.prdNombre;
                r["cnt"] = it.cntFactura;
                r["precio"] = it.precioFactura;
                r["deposito"] = it.depositoCodigo.Trim()+Environment.NewLine+it.depositoNombre.Trim();
                r["empaque"] = it.empaqueCompra.Trim()+Environment.NewLine+it.contenido.ToString().Trim();
                r["alicuota"] = it.tasaIva;
                r["importe"] = it.importe;
                r["importeDivisa"] = importeDivisa;
                r["precioDivisa"] = precioFacturaDivisa;
                r["cntUnd"] = cntUnd;
                ds.Tables["DocDetalle"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("DocEncabezado", ds.Tables["DocEncabezado"]));
            Rds.Add(new ReportDataSource("DocDetalle", ds.Tables["DocDetalle"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}