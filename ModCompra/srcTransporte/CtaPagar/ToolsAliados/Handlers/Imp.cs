using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Handlers
{
    public class Imp: Vistas.IAliados
    {
        private bool _abandonarIsOK;
        private string _tituloTools;
        private Vistas.Idata _data;
        private Anticipos.Administrador.Vistas.IAdm _admAnticipo;
        private PagoServ.Administrador.Vistas.IAdm _admPago;


        public string TituloTools { get { return _tituloTools; } }
        public Utils.Tools.IdataTools data { get { return _data; } }


        public Imp()
        {
            _tituloTools = "TOOLS PAGO ( ALIADOS )";
            _abandonarIsOK = false;
            _data = new data();
            _admAnticipo = new Anticipos.Administrador.Handler.Imp();
            _admPago = new PagoServ.Administrador.Handler.Imp();
        }

        public void Inicializa()
        {
            _abandonarIsOK = false;
            _data.Inicializa();
        }
        Vistas.Frm frm;
        public void Inicia()
        {
            if (frm == null) 
            {
                frm = new Vistas.Frm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }
        public void AdmDocAnticipos()
        {
            _admAnticipo.Inicializa();
            _admAnticipo.Inicia();
            _data.CtasPendientes.CargarCtas();
        }
        public void AdmDocPagos()
        {
            _admPago.Inicializa();
            _admPago.Inicia();
            _data.CtasPendientes.CargarCtas();
        }


        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }
    }
}