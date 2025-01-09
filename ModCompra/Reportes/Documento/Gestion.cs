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
        //
        public Gestion(OOB.LibCompra.Documento.Visualizar.Ficha ficha)
        {
            this.ficha = ficha;
        }
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Documento.rdlc";
            var ds = new DS();
            var enc = ficha.encabezado;
            var _factorCambio = enc.factorCambio;
            var _fechaHoraRegistro = enc.fechaRegistro.ToShortDateString() + ", " + enc.horaRegistro;
            var _subTotal = enc.subTotal + (enc.montoDescuento - enc.montoCargo);
            DataRow rt = ds.Tables["DocEncabezado"].NewRow();
            rt["provNombre"] = enc.provNombre;
            rt["provCiRif"] = enc.provCiRif;
            rt["provCodigo"] = enc.provCodigo;
            rt["provTelefono"] = enc.provTelefono;
            rt["provDireccion"] = enc.provDirFiscal;
            rt["documento"] = enc.documentoNro;
            rt["control"] = enc.controlNro;
            rt["fechaEmision"] = enc.fechaEmision;
            rt["mesAnoRelacion"] = enc.mesRelacion + "/" + enc.anoRelacion;
            rt["fechaVencimiento"] = enc.fechaVencimiento;
            rt["ordenCompra"] = enc.ordenCompraNro;
            rt["montoBase"] = enc.montoBase;
            rt["montoImpuesto"] = enc.montoImpuesto;
            rt["montoTotal"] = enc.montoTotal;
            rt["subTotal"] = _subTotal;
            rt["dsctoP"] = "Descuento " + enc.descuentoPorct.ToString("n2") + "%";
            rt["cargoP"] = "Cargo" + enc.cargoPorct.ToString("n2") + "%";
            rt["dsctoM"] = enc.montoDescuento;
            rt["cargoM"] = enc.montoCargo;
            rt["montoExento"] = enc.montoExento;
            rt["montoBase1"] = enc.montoBase1;
            rt["montoBase2"] = enc.montoBase2;
            rt["montoBase3"] = enc.montoBase3;
            rt["montoImp1"] = enc.montoIva1;
            rt["montoImp2"] = enc.montoIva2;
            rt["montoImp3"] = enc.montoIva3;
            rt["tasaIva1"] = enc.tasaIva1;
            rt["tasaIva2"] = enc.tasaIva2;
            rt["tasaIva3"] = enc.tasaIva3;
            rt["montoDivisa"] = enc.montoDivisa;
            rt["fechaHoraRegistro"] = _fechaHoraRegistro;
            rt["factorCambio"] = _factorCambio ;
            rt["notas"] = enc.notas;
            rt["aplica"] = enc.aplica;
            rt["isAnulado"] = !enc.isAnulado;
            ds.Tables["DocEncabezado"].Rows.Add(rt);
            foreach (var it in ficha.detalles.ToList())
            {
                var importeDivisa = it.importe / _factorCambio ;
                var precioFacturaDivisa = it.precioFactura / _factorCambio ;
                var cnt="";
                var cntUnd="";

                if (((it.cntFactura - ((int)it.cntFactura)))>0)
                {
                    cnt=it.cntFactura.ToString();
                    cntUnd=(it.cntFactura * it.contenido).ToString();
                }
                else
                {
                    cnt = ((int)it.cntFactura).ToString();
                    cntUnd = ((int)(it.cntFactura * it.contenido)).ToString();
                }

                DataRow r = ds.Tables["DocDetalle"].NewRow();
                r["prdCodigo"] = "";
                r["prdNombre"] = it.prdCodigo+Environment.NewLine+it.prdNombre;
                r["cnt"] = cnt ;
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
            pmt.Add(new ReportParameter("DOCUMENTO", enc.documentoModo));
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