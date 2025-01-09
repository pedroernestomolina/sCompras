using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Administrador.Handler
{
    public class dataItem: Vistas.IdataItem
    {
        private OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha _ficha;
        //
        public DateTime Fecha { get; set; }
        public string TipoRet { get; set; }
        public string Documento { get; set; }
        public string ProvNombre { get; set; }
        public string ProvCiRif { get; set; }
        public decimal RetTasa { get; set; }
        public decimal RetMonto { get; set; }
        public string Estatus { get; set; }
        public bool isAnulado { get { return _ficha.estatusAnulado.Trim().ToUpper() == "1"; } }
        public OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha Ficha { get { return _ficha; } }
        //
        public dataItem(OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha ficha)
        {
            _ficha = ficha;
            Fecha= ficha.fechaEmision;
            ProvNombre= ficha.provNombre;
            ProvCiRif = ficha.provCiRif;
            Documento = ficha.documentoNro;
            RetTasa= ficha.retTasa;
            RetMonto= ficha.retMonto;
            Estatus = ficha.estatusAnulado == "1" ? "ANULADO" : "";
            TipoRet = ficha.tipoRetDesc;
        }
    }
}