﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelGestionPagoDocumentos
{
    public interface IListaDesplegar: 
        ModCompra.__.Interfaces.ILista<Modelos.GestionPagoDocumentos.IItemDesplegar>
    {
        void ActualizarFuente();
    }
}