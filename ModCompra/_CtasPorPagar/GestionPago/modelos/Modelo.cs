using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.modelos
{
    public class Modelo: __.Modelos.GestionPago.IModelo
    {
        private __.Modelos.GestionPago.IFichaGestion _fichaGestion;
        private string _infoEntidad;
        private int _cntDocDeudaAbonado;
        private decimal _montoDocDeudaAbonar;
        private int _cntDocNCAbonado;
        private decimal _montoDocNCAbonar;
        private decimal _factorCambio;
        private IEnumerable<__.Modelos.GestionPago.IMedioPago> _mediosPago;
        private IEnumerable<__.Modelos.PanelMetPagoAgregar.IItemAgregar> _metodosPago;

        //
        public string GetInfoEntidad { get { return _infoEntidad; } }
        public __.Modelos.GestionPago.IFichaGestion FichaGestion { get { return _fichaGestion; } }
        public IEnumerable<__.Modelos.GestionPago.IDoc> DocDeuda { get { return _fichaGestion.DocDeudas; } }
        public IEnumerable<__.Modelos.GestionPago.IDoc> DocNC { get { return _fichaGestion.NotasCredito; } }
        public decimal GetFactorCambio { get { return _factorCambio; } }
        public IEnumerable<__.Modelos.GestionPago.IMedioPago> GetMediosPago { get { return _mediosPago; } }
        public IEnumerable<__.Modelos.PanelMetPagoAgregar.IItemAgregar> MetodosPago { get { return _metodosPago; } }

        //ANTICIPOS
        public decimal Get_Anticipos_MontoAUsar { get { return 0m; } }
        public decimal Get_Anticipos_MontoDisponible { get { return _fichaGestion.Entidad.anticipos; } }
        //METODOS PAGO        
        public int GetCntMetPagoRecibido { get { return _metodosPago.Count(); } }
        public decimal GetMontoPorMetPagoRecibido { get { return _metodosPago.Sum(s => s.MontoAplica); } }
        //POR DEUDA
        public int Get_DocSeleccionadosAPagar_PorDeuda_Cnt { get { return _cntDocDeudaAbonado; } }
        public decimal Get_DocSeleccionadosAPagar_PorDeuda_Monto { get { return _montoDocDeudaAbonar; } }
        public decimal Get_DocPorDeuda_MontoTotal { get { return _fichaGestion.DocDeudas.Sum(s=>s.restaDiv); } }
        //POR NC
        public int Get_DocSeleccionadosAPagar_PorNC_Cnt { get { return _cntDocNCAbonado; } }
        public decimal Get_DocSeleccionadosAPagar_PorNC_Monto { get { return _montoDocNCAbonar; } }
        public decimal Get_DocNC_MontoDisponible { get { return _fichaGestion.NotasCredito.Sum(s=>s.restaDiv); } }

        //
        public decimal SaldoFinal
        {
            get 
            {
                var rt = 0m;
                rt += Get_Anticipos_MontoAUsar;
                rt += GetMontoPorMetPagoRecibido;
                rt += Get_DocSeleccionadosAPagar_PorNC_Monto;
                rt -= Get_DocSeleccionadosAPagar_PorDeuda_Monto;
                return Math.Round(rt, 4, MidpointRounding.AwayFromZero);
            }
        }

        //
        public Modelo()
        {
            _infoEntidad = "";
            _factorCambio = 0m;
            _cntDocDeudaAbonado = 0;
            _montoDocDeudaAbonar = 0m;
            _cntDocNCAbonado = 0;
            _montoDocNCAbonar = 0m;
            _mediosPago = null;
            _metodosPago = new List<__.Modelos.PanelMetPagoAgregar.IItemAgregar>();
        }
        public void Inicializa()
        {
            _infoEntidad = "";
            _factorCambio = 0m;
            _cntDocDeudaAbonado = 0;
            _montoDocDeudaAbonar = 0m;
            _cntDocNCAbonado = 0;
            _montoDocNCAbonar = 0m;
            _mediosPago = null;
            var lst = _metodosPago.ToList();
            lst.Clear();
            _metodosPago = lst.AsEnumerable();
        }
        public void setCargarEntidad(__.Modelos.GestionPago.IFichaGestion ficha)
        {
            _fichaGestion = ficha;
            _infoEntidad = _fichaGestion.Entidad.ciRif + Environment.NewLine + _fichaGestion.Entidad.nombreRazonSocial;
        }
        public void setFactorCambio(decimal factor)
        {
            _factorCambio = factor;
        }
        public void setMediosPago(IEnumerable<__.Modelos.GestionPago.IMedioPago> mediosPag)
        {
            _mediosPago = mediosPag;
        }

        //
        public void setCntDocDeudaAbonado(int cnt)
        {
            _cntDocDeudaAbonado = cnt;
        }
        public void setMontoDocDeudaAbonar(decimal monto)
        {
            _montoDocDeudaAbonar = monto;
        }

        //
        public void setCntDocNCAbonado(int cnt)
        {
            _cntDocNCAbonado = cnt;
        }
        public void setMontoDocNCAbonar(decimal monto)
        {
            _montoDocNCAbonar = monto;
        }

        //
        public void AgregarMetodoPago(__.Modelos.PanelMetPagoAgregar.IItemAgregar rt)
        {
            var lst = _metodosPago.ToList();
            lst.Add(rt);
            _metodosPago = lst.AsEnumerable();
        }
        public void CargarMetodosPago(IEnumerable<__.Modelos.PanelMetPagoAgregar.IItemAgregar> lista)
        {
            var lst = _metodosPago.ToList();
            lst.Clear();
            lst.AddRange(lista);
            _metodosPago = lst.AsEnumerable();
        }
    }
}