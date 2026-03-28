using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.CXP.PagosPorConcepto
{
    public class FiltroActivar: Reportes.RepFiltro.Vista.IFiltroActivar
    {
        /*
        private bool _tipoMovCaja;
        private bool _estatus;
        private bool _aliado;
        private bool _proveedor;
        private bool _caja;
        private bool _concepto;
        private bool _beneficiario;
         */
        public bool TipoMovCaja { get { return false; } }
        public bool Estatus { get { return false; } }
        public bool Aliado { get { return false; } }
        public bool Proveedor { get { return false; } }
        public bool Caja { get { return false; } }
        public bool Concepto { get { return true; } }
        public bool Beneficiario { get { return false; } }
        public bool SegunFechaRegistro { get { return true; } }
        public FiltroActivar()
        {
            /*
            _tipoMovCaja = false;
            _estatus = false;
            _aliado = false;
            _proveedor = false;
            _caja = false;
            _concepto = true;
            _beneficiario = false;
             */
        }
    }
}