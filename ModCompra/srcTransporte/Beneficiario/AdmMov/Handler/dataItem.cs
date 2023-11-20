using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Beneficiario.AdmMov.Handler
{
    public class dataItem: Vistas.IdataItem
    {
        private int _idMov;
        private bool _isAnulado;
        private OOB.LibCompra.Transporte.Beneficiario.Mov.Lista.Ficha _ficha;


        public string ReciboNro { get; set; }
        public DateTime FechaMov { get; set; }
        public string BeneficiarioNombre { get; set; }
        public string BeneficiarioCiRif { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public string Estatus { get; set; }
        public int idMov { get { return _idMov; } }
        public bool isAnulado { get { return _isAnulado; } }
        public string Concepto { get; set; }


        public dataItem(OOB.LibCompra.Transporte.Beneficiario.Mov.Lista.Ficha ficha)
        {
            _ficha = ficha;
            ReciboNro = ficha.reciboNro;
            FechaMov = ficha.fechaReg;
            BeneficiarioNombre = ficha.nombreBene;
            BeneficiarioCiRif = ficha.cirifBene;
            Monto = ficha.montoDiv;
            Motivo = "";
            Estatus = ficha.estatusAnulado == "1" ? "ANULADO" : "";
            Concepto = ficha.descConcepto;
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