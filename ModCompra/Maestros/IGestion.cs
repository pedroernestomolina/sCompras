using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Maestros 
{
    
    public interface IGestion
    {

        string Maestro { get; }
        int TotalItems { get; }
        System.Windows.Forms.BindingSource Source { get; }


        bool CargarData();
        void AgregarItem();
        void EditarItem();
        bool IsMarca { get; }
        bool IsEmpaqueMedida { get; }

    }

}