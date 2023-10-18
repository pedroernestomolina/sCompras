using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.HlpGestion
{
    public interface IAbandonar
    {
        bool AbandonarIsOK { get; }
        void AbandonarFicha();
    }
}