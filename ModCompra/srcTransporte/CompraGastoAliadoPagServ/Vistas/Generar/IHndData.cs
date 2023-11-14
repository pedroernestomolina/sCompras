using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CompraGastoAliadoPagServ.Vistas.Generar
{
    public interface IHndData
    {
        string Get_NumeroDoc { get; }
        string Get_NumeroControlDoc { get; }
        DateTime Get_FechaEmisionDoc { get; }
        string Get_Notas { get; }
        Utils.Buscar.Proveedor.Vistas.IProveedor Proveedor {get;}
        Utils.FiltrosCB.ICtrlConBusqueda Concepto { get;}
        Utils.FiltrosCB.ICtrlConBusqueda Aliado { get; }
        Utils.FiltrosCB.ICtrlSinBusqueda Sucursal { get; }
        bool Get_FechaEmisionDocIsOk { get; }

        void Inicializa();
        void CargarData();

        void SetNumeroDoc(string numero);
        void SetNumeroControlDoc(string control);
        void SetFechaEmisionDoc(DateTime fecha);
        void SetNotasDoc(string notas);
        void setFechaServidor(DateTime dateTime);
        bool Verificar();
        void BuscarProveedor();
        void BuscarPagoServAliadoSinProcesar();
    }
}