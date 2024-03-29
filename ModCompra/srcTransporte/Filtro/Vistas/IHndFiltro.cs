﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Filtro.Vistas
{
    public interface IHndFiltro
    {
        // 
        DateTime Get_Desde { get; }
        DateTime Get_Hasta { get; }
        bool Get_IsActivoDesde { get; }
        bool Get_IsActivoHasta { get; }
        void setDesde(DateTime fecha);
        void setHasta(DateTime fecha);
        void ActivarDesde(bool modo);
        void ActivarHasta(bool modo);

        //
        BindingSource Get_EstatusSource { get; }
        string Get_EstatusById { get; }
        void setEstatusById(string id);

        //
        BindingSource Get_TipoMovCajaSource { get; }
        string Get_TipoMovCajaById { get; }
        void setTipoMovCajaById(string id);

        //
        BindingSource Get_TipoRetencionSource { get; }
        string Get_TipoRetencionById { get; }
        void setTipoRetencionById(string id);
        
        //
        BindingSource Get_CajaSource { get; }
        string Get_CajaById { get; }
        string GetCaja_TextoBuscar { get; }
        void setCajaById(string id);
        void setCajaBuscar(string desc);

        //
        BindingSource Get_AliadoSource { get; }
        string Get_AliadoById { get; }
        string GetAliado_TextoBuscar { get; }
        void setAliadoById(string id);
        void setAliadoBuscar(string desc);

        //
        BindingSource Get_ProveedorSource { get; }
        string Get_ProveedorById { get; }
        string GetProveedor_TextoBuscar { get; }
        void setProveedorById(string id);
        void setProveedorBuscar(string desc);

        //
        BindingSource Get_BeneficiarioSource { get; }
        string Get_BeneficiarioById { get; }
        void setBeneficiarioBuscar(string p);
        void setBeneficiarioById(string desc);

        //
        void Inicializa();
        void CargarData();
        void Limpiar();
        bool VerificarFiltros();
        IdataFiltrar Get_Filtros { get; }
    }
}