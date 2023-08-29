using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Fabrica.Pita
{
    public class Imp: IFabrica
    {
        public void Iniciar_FrmPrincipal(Gestion ctr)
        {
            src.PantallaInicio.Frm frm = new src.PantallaInicio.Frm();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }
    }
}