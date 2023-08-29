using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.src.Auditoria.Visualizar
{
    
    public interface IVisualiza: HlpGestion.IGestion
    {

        string Get_MotivoDesc { get; }
        DateTime Get_FechaMov { get; }
        void setFicha(string idDoc, string codDoc, string modulo);

    }

}