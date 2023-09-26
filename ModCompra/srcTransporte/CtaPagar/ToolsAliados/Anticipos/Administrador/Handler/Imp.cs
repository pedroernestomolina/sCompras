using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Administrador.Handler
{
    public class Imp: Vistas.IAdmAnticipo
    {
        private bool _abandonarIsOK;
        private Vistas.IListaAnticipo _lista;
        private Vistas.IBusqDocAnticipo _busqDoc;


        public Utils.Componente.Administrador.Vistas.ILista data { get { return _lista; } }
        public Vistas.IBusqDocAnticipo BusqDoc { get { return _busqDoc; } }
        public string Get_TituloAdm { get { return "Administrador Documentos: ANTCIPOS"; } }
        public int Get_CntItem { get { return _lista.Get_CntItem; } }
        

        public Imp()
        {
            _abandonarIsOK = false;
            _lista = new HndLista();
            _busqDoc = new HndBusqDoc();
        }
        public void Inicializa()
        {
            _abandonarIsOK = false;
            _lista.Inicializa();
            _busqDoc.Inicializa();
        }
        Vistas.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void Buscar()
        {
            _busqDoc.Buscar();
        }

        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }


        private bool cargarData()
        {
            return true;
        }
    }
}