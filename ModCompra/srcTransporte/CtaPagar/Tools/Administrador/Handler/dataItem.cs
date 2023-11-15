using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.Administrador.Handler
{
    public class dataItem : Vistas.IdataItem
    {
        private string _idMov;
        private bool _isAnulado;
        private OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Ficha _ficha;


        public DateTime EFechaMov { get; set; }
        public string EProvNombre { get; set; }
        public string EProvCiRif { get; set; }
        public string EReciboNro { get; set; }
        public decimal EMonto { get; set; }
        public string EMotivo { get; set; }
        public string EEstatus { get; set; }
        public string idMov { get { return _idMov; } }
        public bool isAnulado { get { return _isAnulado; } }
        public OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Ficha Ficha { get { return _ficha; } }


        public dataItem(OOB.LibCompra.Transporte.CxpDoc.Pago.Lista.Ficha ficha)
        {
            _ficha = ficha;
            EFechaMov = ficha.fecha;
            EProvNombre = ficha.provNombre;
            EProvCiRif = ficha.provCiRif;
            EReciboNro = ficha.reciboNro;
            EMonto = ficha.importe;
            EMotivo = ficha.nota;
            EEstatus = ficha.estatusDoc == "1" ? "ANULADO" : "";
            _idMov = _ficha.idMov;
            _isAnulado = _ficha.estatusDoc == "1";
        }

        public void setEstatusAnulado()
        {
            _ficha.estatusDoc = "1";
            EEstatus = _ficha.estatusDoc == "1" ? "ANULADO" : "";
            _isAnulado = _ficha.estatusDoc == "1";
        }
    }
}