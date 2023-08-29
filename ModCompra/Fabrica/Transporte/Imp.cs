using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Fabrica.Transporte
{
    public class Imp: IFabrica
    {
        public void Iniciar_FrmPrincipal(Gestion ctr)
        {
            srcTransporte.PantallaInicio.Frm frm = new srcTransporte.PantallaInicio.Frm();
            frm.setControlador(ctr);
            frm.ShowDialog();
        }
    }
}