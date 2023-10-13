using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    public interface IData: ISucursal, IDeposito, IUsuario, IProveedor, IProducto, IEmpresa, 
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
        Transporte.ITranspBeneficiarioMov
    {
        OOB.ResultadoEntidad<DateTime> 
            FechaServidor();
    }
}