using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.CompAgregarEditarMet.Handler
{
    abstract public class baseAgregarEditar: Vista.IAgregarEditar
    {
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private Vista.IHndData _hndData;
        private decimal _montoPend;
        protected DateTime _fechaServidor;


        public decimal Get_MontoResta { get { return _montoPend; } }
        public DateTime Get_FechaServidor { get { return _fechaServidor; } }
        public Vista.IHndData HndData { get { return _hndData; } }
        abstract public string Get_TituloFicha { get; }


        public baseAgregarEditar()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _hndData = new ImpHndData();
            _montoPend = 0m;
            _fechaServidor = DateTime.Now.Date;
        }
        public void Inicializa()
        {
            _hndData.Inicializa();
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setMontoPend(decimal monto)
        {
            _montoPend = monto;
            _hndData.setMontoResta(monto);
        }


        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _procesarIsOk = false;
            if (_hndData.DataIsOK())
            {
                _procesarIsOk = true;
            }
        }


        abstract protected bool cargarData();
        //{
        //    var r01 = Sistema.MyData.Sistema_MedioCobro_GetLista();
        //    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
        //    {
        //        Helpers.Msg.Error(r01.Mensaje);
        //        return false;
        //    }
        //    var r02 = Sistema.MyData.Configuracion_FactorDivisa();
        //    if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
        //    {
        //        Helpers.Msg.Error(r02.Mensaje);
        //        return false;
        //    }
        //    var _lst = new List<Gestion.ficha>();
        //    foreach (var rg in r01.ListaD.OrderBy(o => o.nombre).ToList())
        //    {
        //        var _rg = new Gestion.ficha(rg.id, rg.codigo, rg.nombre);
        //        _lst.Add(_rg);
        //    }
        //    _gCB_MetCobro.setData(_lst);
        //    setFactor(r02.Entidad);
        //    if (_itemEditar != null) 
        //    {
        //        setMetCobro(_itemEditar.GetMetodo.id);
        //        setMonto(_itemEditar.GetMonto);
        //        setAplicaFactor(_itemEditar.GetAplicaFactor);
        //        setFactor(_itemEditar.GetFactorCambio);
        //        setBanco(_itemEditar.GetBanco);
        //        setCtaNro(_itemEditar.GetNroCta);
        //        setChequeRefTranf(_itemEditar.GetCheqRefTranf);
        //        setFechaOperacion(_itemEditar.GetFechaOp);
        //        setDetalleOperacion(_itemEditar.GetDetalleOp);
        //        setReferencia(_itemEditar.GetReferencia);
        //        setLote(_itemEditar.GetLote);
        //        setAplicaMovCaja(_itemEditar.GetAplicaMovCaja);
        //    }
        //    return true;
        //}
    }
}