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
        public string AliadoNombre { get; set; }
        public string AliadoCiRif { get; set; }
        public string ReciboNro { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public string Estatus { get; set; }
        public int idMov { get { return _idMov; } }
        public bool isAnulado { get { return _isAnulado; } }


        public dataItem(OOB.LibCompra.Transporte.Caja.Movimiento.Lista.Ficha ficha)
        {
            _ficha = ficha;
            //FechaMov = ficha.fecha;
            //AliadoNombre = ficha.nombreAliado;
            //AliadoCiRif = ficha.ciRifAliado;
            //ReciboNro = ficha.numRecibo;
            //Monto = ficha.montoAntSolicitadoDiv;
            //Motivo = ficha.motivo;
            Estatus = ficha.estatusAnulado == "1" ? "ANULADO" : "";
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