using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class GestionItem: IGestionItem
    {

        public event EventHandler ActualizarItemHnd;


        private IGestionItem _gestion;


        public IEnumerable<object> Lista { get { return _gestion.Lista; } }
        public BindingSource ItemSource { get { return _gestion.ItemSource; } }
        public int TItems { get { return _gestion.TItems; } }
        public decimal TotalMonto { get { return _gestion.TotalMonto; } }
        public decimal MontoIva { get { return _gestion.MontoIva; } }
        public decimal MontoDivisa { get { return _gestion.MontoDivisa; } }
        public decimal TotalMonto_Final { get { return _gestion.TotalMonto_Final; } }
        public decimal MontoDivisa_Final { get { return _gestion.MontoDivisa_Final; } }
        public decimal MontoCargo_Final { get { return _gestion.MontoCargo_Final; } }
        public decimal MontoDescuento_Final { get { return _gestion.MontoDescuento_Final; } }
        public decimal MontoBase_Final { get { return _gestion.MontoBase_Final; } }
        public decimal MontoBase1_Final { get { return _gestion.MontoBase1_Final; } }
        public decimal MontoBase2_Final { get { return _gestion.MontoBase2_Final; } }
        public decimal MontoBase3_Final { get { return _gestion.MontoBase3_Final; } }
        public decimal MontoExento_Final { get { return _gestion.MontoExento_Final; } }
        public decimal MontoImpuesto_Final { get { return _gestion.MontoImpuesto_Final; } }
        public decimal MontoImpuesto1_Final { get { return _gestion.MontoImpuesto1_Final; } }
        public decimal MontoImpuesto2_Final { get { return _gestion.MontoImpuesto2_Final; } }
        public decimal MontoImpuesto3_Final { get { return _gestion.MontoImpuesto3_Final; } }


        public string Item_Producto { get { return _gestion.Item_Producto; } }
        public decimal Item_Importe { get { return _gestion.Item_Importe; } }
        public decimal Item_Impuesto { get { return _gestion.Item_Impuesto; } }
        public decimal Item_Total { get { return _gestion.Item_Total; } }
        public decimal Item_Cantidad { get { return _gestion.Item_Cantidad; } }
        public decimal Item_CantidadUnd { get { return _gestion.Item_CantidadUnd; } }
        public decimal Item_CostoMoneda { get { return _gestion.Item_CostoMoneda; } }
        public decimal Item_CostoMonedaUnd { get { return _gestion.Item_CostoMonedaUnd; } }
        public decimal Item_CostoDivisa { get { return _gestion.Item_CostoDivisa; } }
        public decimal Item_CostoDivisaUnd { get { return _gestion.Item_CostoDivisaUnd; } }
        public string Item_EmpaqueCont { get { return _gestion.Item_EmpaqueCont; } }
        public string Item_CodRefPrv { get { return _gestion.Item_CodRefPrv; } }
        public decimal Item_Dscto { get { return _gestion.Item_Dscto; } }


        public void setGestion(IGestionItem gestion)
        {
            _gestion = gestion;
        }

        public void LimpiarItems()
        {
            _gestion.LimpiarItems();
        }

        public void EliminarItem()
        {
            _gestion.EliminarItem();
        }

        public void EditarItem()
        {
            _gestion.EditarItem();
        }

        public void AgregarItem(string autoPrd, string autoPrv, decimal factorDivisa)
        {
            _gestion.AgregarItem(autoPrd, autoPrv, factorDivisa);
        }

        public void Limpiar()
        {
            _gestion.Limpiar();
        }

        public void setDescuentoFinal(decimal p)
        {
            _gestion.setDescuentoFinal(p);
        }

        public void setCargoFinal(decimal p)
        {
            _gestion.setCargoFinal(p);
        }

        public void CargarItems(List<OOB.LibCompra.Documento.GetData.FichaDetalle> list, decimal factorCambio)
        {
            _gestion.CargarItems(list, factorCambio);
        }

        public void AgregarListaItem(List<OOB.LibCompra.Documento.ListaItemImportar.Ficha> list, string idPrv, decimal factorDivisa)
        {
            _gestion.AgregarListaItem(list, idPrv, factorDivisa);
        }

        public void AgregarListaItem(List<OOB.LibCompra.Documento.Pendiente.Abrir.FichaDetalle> list, string idPrv, decimal factorDivisa, OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad metCalcUt)
        {
            _gestion.AgregarListaItem(list, idPrv, factorDivisa, metCalcUt);
        }
    }

}