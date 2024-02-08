using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public interface IGestionItem
    {

        event EventHandler ActualizarItemHnd;


        IEnumerable<object> Lista { get; }
        System.Windows.Forms.BindingSource ItemSource { get; }
        int TItems { get; }
        decimal TotalMonto { get; }
        decimal MontoIva { get; }
        decimal MontoDivisa { get; }
        decimal TotalMonto_Final { get; }
        decimal MontoDivisa_Final { get; }
        decimal MontoCargo_Final { get; }
        decimal MontoDescuento_Final { get; }
        decimal MontoBase_Final { get; }
        decimal MontoBase1_Final { get; }
        decimal MontoBase2_Final { get; }
        decimal MontoBase3_Final { get; }
        decimal MontoExento_Final { get; }
        decimal MontoImpuesto_Final { get; }
        decimal MontoImpuesto1_Final { get; }
        decimal MontoImpuesto2_Final { get; }
        decimal MontoImpuesto3_Final { get; }


        string Item_Producto { get; }
        decimal Item_Importe { get; }
        decimal Item_Impuesto { get; }
        decimal Item_Total { get; }
        decimal Item_Cantidad { get; }
        decimal Item_CantidadUnd { get; }
        decimal Item_CostoMoneda { get; }
        decimal Item_CostoMonedaUnd { get; }
        decimal Item_CostoDivisa { get; }
        decimal Item_CostoDivisaUnd { get; }
        string Item_EmpaqueCont { get; }
        string Item_CodRefPrv { get; }
        decimal Item_Dscto { get; }


        void LimpiarItems();
        void EliminarItem();
        void EditarItem();
        void AgregarItem(string autoPrd, string autoPrv, decimal factorDivisa);
        void Limpiar();
        void setDescuentoFinal(decimal p);
        void setCargoFinal(decimal p);
        void CargarItems(List<OOB.LibCompra.Documento.GetData.FichaDetalle> list, decimal factorCambio);
        void AgregarListaItem(List<OOB.LibCompra.Documento.ListaItemImportar.Ficha> list, string idPrv, decimal factorDivisa);
        void AgregarListaItem(List<OOB.LibCompra.Documento.Pendiente.Abrir.FichaDetalle> list, 
                                string idPrv , 
                                decimal factorDivisa, 
                                OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad metCalcUt);
    }
}