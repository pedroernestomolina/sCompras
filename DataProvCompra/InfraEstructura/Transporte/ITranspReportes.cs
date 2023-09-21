﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspReportes
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Ficha>
            Transporte_Reportes_Compras_GeneralDoc_GetLista(OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Ficha>
            Transporte_Reportes_Compras_Retenciones_GetLista(OOB.LibCompra.Transporte.Reportes.Compras.Retencion.Filtro filtro);
        OOB.ResultadoEntidad< OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha>
            Transporte_Reportes_Compras_Planilla_RetIva(string idDocCompra);
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha>
            Transporte_Reportes_Compras_Planilla_RetIslr(string idDocCompra);
    }
}