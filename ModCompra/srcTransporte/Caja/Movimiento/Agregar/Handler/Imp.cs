using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Movimiento.Agregar.Handler
{
    public class Imp: Vistas.IMov
    {
        private bool _abandonarIsOK;
        private bool _procesarIsOK;


        public Imp()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
        }
        public void Inicializa()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
        }
        Vistas.Frm frm;
        public void Inicia()
        {
            if (cargarDataIsOk()) 
            {
                if (frm == null) 
                {
                    frm = new Vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public void Procesar()
        {
        }


        private bool cargarDataIsOk()
        {
            return true;
        }
    }
}