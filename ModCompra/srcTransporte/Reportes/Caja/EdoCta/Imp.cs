using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Caja.EdoCta
{
    public class Imp : IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro _filtro;


        public Imp()
        {
            _filtro = new OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro();
        }
        public void setFiltros(object filtros)
        {
            var ft = (Reportes.RepFiltro.Vista.IFiltros)filtros;
            _filtro = new OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro()
            {
                Desde = ft.Desde,
                Hasta = ft.Hasta,
                IdCaja = ft.IdCaja,
                EstatusDoc = OOB.LibCompra.Transporte.Reportes.Caja.enumerados.EstatusDoc.SinDefinir,
                TipoMov = OOB.LibCompra.Transporte.Reportes.Caja.enumerados.TipoMovCaja.SinDefinir,
            };
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Caja_Movimientos_GetLista(_filtro);
                var filtro2 = new OOB.LibCompra.Transporte.Reportes.Caja.Saldo.Filtro()
                {
                    fecha = _filtro.Desde.Value.AddDays(-1),
                    idCaja = _filtro.IdCaja,
                };
                var r02 = Sistema.MyData.Transporte_Reportes_Caja_Saldo_Al(filtro2);
                var _saldoIni = r02.Entidad.esDivisa.Trim().ToUpper() == "1" ? r02.Entidad.montoMonDiv : r02.Entidad.montoMonAct;
                imprimir(r01.Lista, _saldoIni);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Ficha> list, decimal saldoIni)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Caja\RepCajaEdoCta.rdlc";
            var ds = new  DS_CAJA();

            var _saldoIni=saldoIni;
            var _montoIngreso=0m;
            var _montoEgreso=0m;
            var _saldoFinal=0m;
            foreach (var rg in list.Where(w=>w.estatusAnulado=="0").ToList())
            {
                _montoIngreso=0m;
                _montoEgreso=0m;
                var _monto = (rg.cjEsDivisa.Trim().ToUpper() == "1" ? rg.montoMonDiv : rg.montoMonAct) * rg.signoMov;
                if (rg.estatusAnulado.Trim().ToUpper() == "1")
                {
                    _monto = 0m;
                }
                if (rg.tipoMov.Trim().ToUpper()=="I")
                {
                    _montoIngreso=_monto;
                }
                else
                {
                    _montoEgreso=_monto;
                }
                _saldoFinal=_saldoIni+_montoIngreso+_montoEgreso;
                DataRow rt = ds.Tables["CajaMov"].NewRow();
                rt["fecha"] = rg.fechaMov;
                rt["monto"] = _monto;
                rt["motivo"] = rg.motivoMov;
                rt["estatus"] = rg.estatusAnulado.Trim().ToUpper() == "1" ? "ANULADO" : "";
                rt["tipoMov"] = rg.tipoMov.Trim().ToUpper() == "I" ? "INGRESO" : "EGRESO";
                rt["cajaDesc"] = rg.cjDesc;
                rt["esDivisa"] = rg.cjEsDivisa.Trim().ToUpper() == "1" ? "$" : "";
                rt["saldoini"] = _saldoIni;
                rt["ingreso"] = _montoIngreso;
                rt["egreso"] = _montoEgreso;
                rt["saldofinal"] = _saldoFinal;
                ds.Tables["CajaMov"].Rows.Add(rt);
                _saldoIni = _saldoFinal;
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