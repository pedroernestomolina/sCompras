﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras
{
    public interface IProvider: IDeposito, ISucursal, IProveedor, IProducto, IUsuario, IEmpresa, 
        IPermiso, IConfiguracion, IDocumento, IConcepto, IReportes, IGrupo, IEstado, IReporteProv, 
        IAuditoria, ISistemaDocumento, 
        Transporte.ITranspDocumento,
        Transporte.ITranspConcepto,
        Transporte.ITranspAliado,
        Transporte.ITranspAliadoAnticipo,
        Transporte.ITranspCaja,
        Transporte.ITranspAliadoPagServ,
        Transporte.ITranspReportes,
        Transporte.ITranspCajaMov,
        Transporte.ITranspDocumentoRet,
        Transporte.ITranspBeneficiario,
        Transporte.ITranspBeneficiarioMov,
        Transporte.ITranspCxpDoc,
        Transporte.ITranspMedioPago,
        IDocumento_Corrector
    {
        DtoLib.ResultadoEntidad<DateTime> FechaServidor();
    }
}