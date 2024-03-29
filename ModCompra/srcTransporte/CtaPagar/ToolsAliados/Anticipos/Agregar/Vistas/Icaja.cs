﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Agregar.Vistas
{
    public interface Icaja
    {
        decimal Get_MontoPendMonAct { get; }
        decimal Get_MontoPendMonDiv { get; }
        decimal MontoCajaPago { get; }
        BindingSource Get_CajaSource { get; }
        IEnumerable<IdataCaja> Get_Lista { get; }
        IEnumerable<IdataCaja> Get_CajasUsadas { get; }

        void Inicializa();
        void CargarData();
        void setDataCargar(IEnumerable<IdataCaja> _lst);
        void setFactorCambio(decimal factor);
        void setMontoPendDiv(decimal montoDiv);
        void EditarMontoAbonar();
        void ActualizarSaldosPend();
        bool IsOk();
        //
        decimal GetTasaAplicarFactorCambioParaAnticipo { get; }
        void setAplicaFactorCambioParaAnticipo(bool aplica);
        void setTasaAplicarFactorCambioParaAnticipo(decimal factor);
    }
}