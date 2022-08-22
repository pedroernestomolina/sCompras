using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Configuracion.Modulo
{
    
    public class Conf: IConf
    {


        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private bool _cambiarPrecioVentaDocCompra;


        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public bool ProcesarIsOK { get { return _procesarIsOk; } }


        public Conf()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }
        private CnfModuloFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new CnfModuloFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_GetPermitirCambiarPrecioAlRegistrarDocCompra();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _cambiarPrecioVentaDocCompra = r01.Entidad;

            return rt;
        }

        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }
        public void Procesar()
        {
            _procesarIsOk = false;
            if (Helpers.Msg.Procesar()) 
            {
                var r01 = Sistema.MyData.Configuracion_SetPermitirCambiarPrecioAlRegistrarDocCompra(_cambiarPrecioVentaDocCompra);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Helpers.Msg.OK();
                _procesarIsOk = true;
            }
        }

        public bool GetCambiarPrecioVenta { get { return _cambiarPrecioVentaDocCompra; } }
        public void setCambiarPrecioVenta(bool cnf)
        {
            _cambiarPrecioVentaDocCompra = cnf;
        }

    }

}