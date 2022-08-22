using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.HlpGestion
{
    
    public interface IProcesar
    {

        bool ProcesarIsOK { get; }
        void Procesar();

    }

}
