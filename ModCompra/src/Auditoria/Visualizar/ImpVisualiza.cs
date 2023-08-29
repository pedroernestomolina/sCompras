using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.src.Auditoria.Visualizar
{
    
    public class ImpVisualiza: IVisualiza
    {

        private string _idDoc;
        private string _codDoc;
        private string _modulo;
        private OOB.LibCompra.Auditoria.Entidad.Ficha _fichaAud;
        private string _motivoMov;
        private DateTime _fechaMov;
                

        public string Get_MotivoDesc { get { return _motivoMov; } }
        public DateTime Get_FechaMov { get { return _fechaMov; } }


        public ImpVisualiza()
        {
            _idDoc= "";
            _codDoc = "";
            _modulo = "";
            _fichaAud = null;
            _motivoMov = "";
            _fechaMov = DateTime.Now.Date;
        }


        public void Inicializa()
        {
            _idDoc = "";
            _codDoc = "";
            _modulo = "";
            _fichaAud = null;
            _motivoMov = "";
            _fechaMov = DateTime.Now.Date;
        }
        VisualizarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new VisualizarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setFicha(string idDoc, string codDoc, string modulo)
        {
            _idDoc = idDoc;
            _codDoc = codDoc;
            _modulo = modulo;
        }


        private bool CargarData()
        {
            try
            {
                var ficha01 = new OOB.LibCompra.SistemaDocumento.Entidad.Busqueda()
                {
                    codigoDoc = _codDoc,
                    TipoDoc = _modulo,
                };
                var r01 = Sistema.MyData.SistemaDocumento_Get(ficha01);
                var ficha02 = new OOB.LibCompra.Auditoria.Entidad.Busqueda()
                {
                    autoDoc = _idDoc,
                    autoTipoDoc = r01.Entidad.autoId,
                };
                var r02 = Sistema.MyData.AuditoriaDocumento_Get(ficha02);
                _fichaAud = r02.Entidad;
                _motivoMov = r02.Entidad.motivo;
                _fechaMov = r02.Entidad.fecha;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

    }

}