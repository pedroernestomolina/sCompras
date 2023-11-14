using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CompraGastoAliadoPagServ.Handlres.Generar
{
    public class HndData : Vistas.Generar.IHndData
    {
        private string _numeroDoc;
        private string _numeroControlDoc;
        private DateTime _fechaEmisionDoc;
        private DateTime _fechaServidor;
        private string _notas;
        private Utils.FiltrosCB.ICtrlConBusqueda _concepto;
        private Utils.FiltrosCB.ICtrlSinBusqueda _sucursal;
        private Utils.Buscar.Proveedor.Vistas.IProveedor _proveedor;
        private Utils.FiltrosCB.ICtrlConBusqueda _aliado;
        private List<OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha> _servPg;


        public string Get_NumeroDoc { get { return _numeroDoc; } }
        public string Get_NumeroControlDoc { get { return _numeroControlDoc; } }
        public DateTime Get_FechaEmisionDoc { get { return _fechaEmisionDoc; } }
        public string Get_Notas { get { return _notas; } }
        public bool Get_FechaEmisionDocIsOk { get { return _fechaEmisionDoc > _fechaServidor; } }
        public Utils.FiltrosCB.ICtrlConBusqueda Concepto { get { return _concepto; } }
        public Utils.FiltrosCB.ICtrlSinBusqueda Sucursal { get { return _sucursal; } }
        public Utils.Buscar.Proveedor.Vistas.IProveedor Proveedor { get { return _proveedor; } }
        public Utils.FiltrosCB.ICtrlConBusqueda Aliado { get { return _aliado; } }


        public HndData()
        {
            _numeroDoc = "";
            _numeroControlDoc = "";
            _fechaEmisionDoc = DateTime.Now.Date;
            _fechaServidor = DateTime.Now.Date;
            _notas = "";
            _concepto = new Utils.FiltrosCB.ConBusqueda.Concepto.Imp();
            _sucursal = new Utils.FiltrosCB.SinBusqueda.Sucursal.Imp();
            _proveedor = new Utils.Buscar.Proveedor.Handler.Imp();
            _aliado = new Utils.FiltrosCB.ConBusqueda.Aliado.Imp();
            _servPg = null;
        }
        public void Inicializa()
        {
            _numeroDoc = "";
            _numeroControlDoc = "";
            _fechaEmisionDoc = DateTime.Now.Date;
            _notas = "";
            _concepto.Inicializa();
            _sucursal.Inicializa();
            _proveedor.Inicializa();
            _aliado.Inicializa();
            _servPg = null;
        }
        public void CargarData()
        {
            _concepto.ObtenerData();
            _sucursal.ObtenerData();
            _aliado.ObtenerData();
        }


        public void SetNumeroDoc(string numero)
        {
            _numeroDoc = numero;
        }
        public void SetNumeroControlDoc(string control)
        {
            _numeroControlDoc = control;
        }
        public void SetFechaEmisionDoc(DateTime fecha)
        {
            _fechaEmisionDoc = fecha;
        }
        public void SetNotasDoc(string notas)
        {
            _notas = notas;
        }
        public void setFechaServidor(DateTime fecha)
        {
            _fechaServidor = fecha;
        }


        public bool Verificar()
        {
            var rt = true;
            if (Get_NumeroDoc.Trim() == "")
            {
                Helpers.Msg.Alerta("NUMERO DE DOCUMENTO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (Get_NumeroControlDoc.Trim() == "")
            {
                //Helpers.Msg.Alerta("NUMERO DE CONTROL DEL DOCUMENTO NO PUEDE ESTAR VACIO");
                //return false;
            }
            if (_proveedor.Get_Ficha == null)
            {
                Helpers.Msg.Alerta("PROVEEDOR NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_aliado.GetItem == null)
            {
                Helpers.Msg.Alerta("ALIADO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_sucursal.GetItem == null)
            {
                Helpers.Msg.Alerta("SUCURSAL NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_concepto.GetItem == null)
            {
                Helpers.Msg.Alerta("CONCEPTO DOCUMENTO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_notas.Trim() == "")
            {
                Helpers.Msg.Alerta("NOTAS DEL DOCUMENTO NO PUEDE ESTAR VACIO");
                return false;
            }
            return rt;
        }


        public void BuscarProveedor()
        {
            _proveedor.Buscar();
            if (_proveedor.ProveedorIsOk)
            {
                var _prv = (Utils.Buscar.Proveedor.Handler.data)_proveedor.Get_Ficha;
                try
                {
                    var r01 = Sistema.MyData.Proveedor_GetFicha(_prv.id);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r01.Mensaje);
                    }
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public void BuscarPagoServAliadoSinProcesar()
        {
            if (_aliado.GetItem != null)
            {
                try
                {
                    Buscar();
                    CargarLista();
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }

        private void CargarLista()
        {
             Utils.Buscar.AliadoPagoServ.Vista.IHnd _pgServ = new Utils.Buscar.AliadoPagoServ.Handler.Imp();
             _pgServ.Inicializa();
             _pgServ.setDataCargar(_servPg);
             _pgServ.Inicia();
        }
        private void Buscar()
        {
            var filtro = new OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Filtro()
            {
                IdAliado = int.Parse(_aliado.GetId),
                Estatus = "0",
            };
            var r01 = Sistema.MyData.Transporte_Aliado_PagoServ_GetLista(filtro);
            _servPg= r01.Lista.Where(w => w.estatusProcesado == "0").ToList();
        }
    }
}