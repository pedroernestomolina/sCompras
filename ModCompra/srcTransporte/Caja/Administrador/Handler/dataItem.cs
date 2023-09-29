using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Administrador.Handler
{
    public class dataItem: Vistas.IdataItem
    {
        private OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Ficha _ficha;
        private int _idMov;
        private bool _isAnulado;


        public DateTime FechaMov { get; set; }
        public string Motivo { get; set; }
        public decimal Monto { get; set; }
        public string TipoMov { get; set; }
        public int SignoMov { get; set; }
        public string Estatus { get; set; }
        public string CajaDesc { get; set; }
        public string EsDivisa { get; set; }
        //
        public int idMov { get { return _idMov; } }
        public bool isAnulado { get { return _isAnulado; } }


        public dataItem(OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Ficha ficha)
        {
            _ficha = ficha;
            FechaMov = ficha.fechaMov;
            Monto = ficha.movFueDivisa.ToUpper().Trim() == "1" ? ficha.montoMonDiv : ficha.montoMonAct;
            Motivo = ficha.motivoMov;
            Estatus = ficha.estatusAnulado == "1" ? "ANULADO" : "";
            TipoMov= ficha.tipoMov=="I"?"INGRESO":"EGRESO";
            SignoMov = ficha.signoMov;
            CajaDesc = ficha.cjDesc;
            EsDivisa= ficha.cjEsDivisa.Trim().ToUpper()=="1"?"$":"";
            _idMov = ficha.idMov;
            _isAnulado = ficha.estatusAnulado == "1" ;
        }
        public void setEstatusAnulado()
        {
            _ficha.estatusAnulado = "1";
            Estatus = _ficha.estatusAnulado == "1" ? "ANULADO" : "";
            _isAnulado = _ficha.estatusAnulado == "1";
        }
    }
}