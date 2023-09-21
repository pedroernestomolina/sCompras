﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Utils.Tools
{
    public interface IdataCtasPendientes
    {
        BindingSource GetSource { get; }
        decimal Get_MontoPendiente { get; }
        object ItemActual { get; }


        void Inicializa();
        void CargarCtas();
    }
}