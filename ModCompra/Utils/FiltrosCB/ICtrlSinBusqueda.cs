﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB
{
    public interface ICtrlSinBusqueda: LibUtilitis.CtrlCB.ICtrl
    {
        void ObtenerData();
    }
}