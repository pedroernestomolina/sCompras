using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using ModCompra.srcTransporte.Reportes.ListaAdm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.CXP.Documentos.Pagos
{
    public class Imp : IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Cxp.PagosEmitidos.Filtro _filtro;


        public Imp()
        {
        }
        public void setFiltros(object filtros)
        {
            var ft = (Reportes.RepFiltro.Vista.IFiltros)filtros;
            var _estatusDoc = OOB.LibCompra.Transporte.Reportes.Cxp.enumerados.EstatusDoc.SinDefinir;
            if (ft.EstatusDocumento != RepFiltro.Vista.enumerados.EstatusDoc.SinDefinir)
            {
                _estatusDoc = OOB.LibCompra.Transporte.Reportes.Cxp.enumerados.EstatusDoc.Activo;
                if (ft.EstatusDocumento == RepFiltro.Vista.enumerados.EstatusDoc.Inactivo)
                {
                    _estatusDoc = OOB.LibCompra.Transporte.Reportes.Cxp.enumerados.EstatusDoc.Anulado;
                }
            }
            _filtro = new OOB.LibCompra.Transporte.Reportes.Cxp.PagosEmitidos.Filtro()
            {
                Desde = ft.Desde,
                Hasta = ft.Hasta,
                EstatusDoc = _estatusDoc,
                IdProveedor = ft.IdProveedor,
            };
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Cxp_Documentos_PagosEmitidos(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Cxp.PagosEmitidos.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\CxP\RepCxp_DocPagosEmitidos.rdlc";
            var ds = new DS_ADM();

            foreach (var rg in list)
            {
                var _importe = rg.importe;
                if (rg.estatus.Trim().ToUpper() == "1")
                {
                    _importe = 0m;
                }
                DataRow rt = ds.Tables["CxpDocPagosEmitidos"].NewRow();
                rt["proveedor"] = rg.provCiRif.Trim()+Environment.NewLine+rg.provNombre.Trim();
                rt["reciboNro"] = rg.reciboNro ;
                rt["fecha"] = rg.fecha;
                rt["importe"] = _importe;
                rt["tasaFactor"] = rg.tasaFactor;
                rt["estatus"] = rg.estatus.Trim().ToUpper() == "1" ? "ANULADO" : "";
                rt["nota"] = rg.nota;
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