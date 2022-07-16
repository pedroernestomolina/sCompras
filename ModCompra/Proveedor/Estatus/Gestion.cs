using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.Estatus
{

    public class Gestion
    {

        public enum EnumEstatus { Activo = 1, Inactivo = 0 };


        private string _autoId;
        private OOB.LibCompra.Proveedor.Data.Ficha _data;
        private EnumEstatus _estatus;
        private bool _procesarIsOk;


        public string Proveedor { get { return _data.ciRif + Environment.NewLine + _data.nombreRazonSocial + Environment.NewLine + _data.direccionFiscal; } }
        public EnumEstatus Estatus { get { return _estatus; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool CambioEstatusIsOk { get { return _procesarIsOk; } }


        public Gestion()
        {
            Inicializa();
        }


        EstatusFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                frm = new EstatusFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Proveedor_GetFicha(_autoId);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _data = r01.Entidad;
            _estatus = EnumEstatus.Activo;
            if (!_data.IsActivo)
                _estatus = EnumEstatus.Inactivo;

            return rt;
        }

        private void Limpiar()
        {
        }

        public void setFicha(string autoId)
        {
            this._autoId = autoId;
        }

        public void setEstatusActivo()
        {
            _estatus = EnumEstatus.Activo;
        }

        public void setEstatusInactivo()
        {
            _estatus = EnumEstatus.Inactivo;
        }

        public void Procesar()
        {
            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var ficha = new OOB.LibCompra.Proveedor.ActivarInactivar.Ficha()
                {
                     id = _autoId,
                };
                if (_estatus == EnumEstatus.Activo) 
                {
                    var r01 = Sistema.MyData.Proveedor_ActivarFicha(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                }
                else
                {
                    var r01 = Sistema.MyData.Proveedor_InactivarFicha(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                }
                Helpers.Msg.EditarOk();
                _procesarIsOk = true;
            }
        }

        public void Inicializa()
        {
            _data = null;
            _autoId = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
        }

        private bool _abandonarIsOk;
        public void Salir()
        {
            _abandonarIsOk = false;
            var msg = MessageBox.Show("Abandonar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

    }

}