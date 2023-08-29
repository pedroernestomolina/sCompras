using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CompraGasto.Vistas.Generar
{
    public interface Idata
    {
        string Get_NumeroDoc { get; }
        string Get_NumeroControlDoc { get; }
        int Get_DiasCreditoDoc { get;  }
        BindingSource Get_TipoDocumento_Source { get; }
        BindingSource Get_CondicionPago_Source { get; }
        DateTime Get_FechaEmisionDoc { get; }
        DateTime Get_FechaVenceDoc { get;  }
        string Get_TipoDocumento_ID { get; }
        string Get_CondicionPago_ID { get; }
        //
        BindingSource Get_Sucursal_Source { get; }
        BindingSource Get_Concepto_Source { get; }
        string Get_Sucursal_ID { get; }
        string Get_Concepto_ID { get; }
        bool Get_IncluirLibroCompras { get; }
        string Get_Notas { get; }
        //
        Utils.Buscar.Proveedor.Vistas.IProveedor Proveedor {get;}
        //
        bool AplicaActivo { get; }
        string Get_Aplica_NumeroDoc { get; }
        DateTime Get_Aplica_FechaDoc { get; }


        void Inicializa();
        void SetTipoDocumentoById(string id);
        void SetCondicionPagoById(string id);
        void TipoDocumentoCargarData(IEnumerable<LibUtilitis.Opcion.IData> lst);
        void CondicionPagoDocCargarData(IEnumerable<LibUtilitis.Opcion.IData> lst);
        void SetNumeroDoc(string numero);
        void SetNumeroControlDoc(string control);
        void SetFechaEmisionDoc(DateTime fecha);
        void SetDiasCreditoDoc(int dias);
        //
        void SetSucursalById(string id);
        void SetConceptoById(string id);
        void SetIncluirLibroCompras();
        void SetNotasDoc(string notas);
        void SucursalCargarData(List<OOB.LibCompra.Sucursal.Data.Ficha> lst);
        void ConceptoCargarData(List<OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha> lst);
        //
        void SetAplicaNumeroDoc(string numero);
        void SetAplicaFechaDoc(DateTime fecha);
        //
        bool Get_FechaEmisionDocIsOk { get; }
        bool Get_FechaAplicaDocIsOk { get; }
        void FechaServidorCargar(DateTime fecha);
    }
}