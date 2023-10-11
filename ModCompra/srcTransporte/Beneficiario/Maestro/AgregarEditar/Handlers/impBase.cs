using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Beneficiario.Maestro.AgregarEditar.Handlers
{
    public abstract class impBase: AgregarEditar.Vistas.IAgregarEditar 
    {
        private Vistas.Idata _data;
        protected bool _procesarIsOK;
        private bool _abandonarIsOK;


        public Vistas.Idata data { get { return _data; } }


        public impBase()
        {
            _data = new data();
            _procesarIsOK = false;
            _abandonarIsOK = false;
        }


        public virtual void Inicializa()
        {
            _data.Inicializa();
            _procesarIsOK = false;
            _abandonarIsOK = false;
        }
        Vistas.Frm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new Vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        abstract public void Procesar();

        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }

        virtual protected bool CargarData()
        {
            return true;
        }
    }
}