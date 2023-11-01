using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces
{
    public interface IService: IDeposito, ISucursal, IProveedor, IProducto, IUsuario, IEmpresa,
        IPermiso, IConfiguracion, IDocumento, IConcepto, IReportes, IGrupo, IEstado, IReporteProv, 
        IAuditoria, ISistemaDocumento,
        Transporte.ITranspDocumento,
        Transporte.ITranspAliado,
        Transporte.ITranspAliadoAnticipo,
        Transporte.ITranspCaja,
        Transporte.ITranspAliadoPagServ,
        Transporte.ITranspReportes,
        Transporte.ITranspCajaMov,
        Transporte.ITranspDocumentoRet,
        Transporte.ITranspBeneficiario,
        Transporte.ITranspBeneficiarioMov,
        Transporte.ITranspCxpDoc
    {
        DtoLib.ResultadoEntidad<DateTime> 
            FechaServidor();
    }
}