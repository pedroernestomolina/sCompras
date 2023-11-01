using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.ToolsDoc.Handler
{
    public class ImpToolDoc: Vista.IToolDoc 
    {
        private IHndTool _hnd;


        public string TituloTools { get { return "TOOLS PAGO ( DOCUMENTOS )"; } }
        public IHndTool Hnd { get { return _hnd; } }


        public ImpToolDoc()
        {
            _hnd = new ImpHndToolDoc();
        }

        public void Inicializa()
        {
            _hnd.Inicializa();
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

        public bool AbandonarIsOK { get { return true; } }
        public void AbandonarFicha()
        {
        }


        private bool cargarData()
        {
            return true;
        }
    }
}