using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Anular.Handler
{
    public class Imp: Vista.IAnular
    {
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private string _motivo;


        public string Get_Motivo { get { return _motivo; } }


        public Imp()
        {
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _motivo= "";
        }
        public void Inicializa()
        {
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _motivo = "";
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setMotivo(string desc)
        {
            _motivo = desc;
        }


        private bool CargarData()
        {
            return true;
        }

        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _procesarIsOk = _motivo.Trim() != "";
        }

        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }
    }
}