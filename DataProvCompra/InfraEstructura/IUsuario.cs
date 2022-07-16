using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IUsuario
    {

        OOB.ResultadoEntidad<OOB.LibCompra.Usuario.Data.Ficha> Usuario_Principal();
        OOB.ResultadoEntidad<OOB.LibCompra.Usuario.Data.Ficha> Usuario_Cargar(OOB.LibCompra.Usuario.Buscar.Ficha ficha);
        OOB.Resultado Usuario_ActualizarSesion(OOB.LibCompra.Usuario.ActualizarSesion.Ficha ficha);

    }

}