using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Helpers.Documento
{
    public struct recuperar
    {
        public string descEmpaque;
        public int contEmpaque;
        public decimal[] precios;
        public recuperar(string descEmpq, int contEmpq, decimal[] pvta)
        {
            descEmpaque = descEmpq;
            contEmpaque = contEmpq;
            precios = pvta;
        }
    };
    public struct PrecioPend
    {
        public List<decimal> precios;
        public string descEmpaque;
        public int contEmpaque;
        public PrecioPend(string descEmpq, int contEmpq, List<decimal> prec)
        {
            descEmpaque = descEmpq;
            contEmpaque = contEmpq;
            precios = prec;
        }
    }

    public class Compra
    {
        public static List<OOB.LibCompra.Documento.Pendiente.Agregar.PrecioVtaPend>
            ConstruirListaPreciosPend(Producto.Precio.zufu.ActualizarPrecio.Vista.IMatPrecio[] matPrecio)
        {
            var precios = new List<PrecioPend>();
            foreach (var rg in matPrecio)
            {
                var lst= new List<decimal>();
                foreach (var p in rg.Precio)
                {
                    lst.Add(p.Data.PNeto);
                }
                var precPend = new PrecioPend(rg.Empaque, rg.Contenido, lst);
                precios.Add(precPend);
            }
            //
            var idP = 1;
            var lstpVtaPend = new List<OOB.LibCompra.Documento.Pendiente.Agregar.PrecioVtaPend>();
            foreach (var rg in precios)
            {
                var pVtaPend = new OOB.LibCompra.Documento.Pendiente.Agregar.PrecioVtaPend()
                {
                    idEmpqVta = idP,
                    descEmpVta = rg.descEmpaque,
                    contEmpVta = rg.contEmpaque,
                    precios = rg.precios.ToArray(),
                };
                lstpVtaPend.Add(pVtaPend);
                idP += 1;
            }
            //
            return lstpVtaPend;
        }
        public static Producto.Precio.zufu.ActualizarPrecio.Vista.IMatPrecio[] 
            ImportarListaPreciosPend(OOB.LibCompra.Documento.Pendiente.Abrir.FichaDetalle it,
            OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad metCalcUt)
        {
            if (it.preciosVtaPend.Count==0) { return null; }
            //
            Producto.Precio.zufu.ActualizarPrecio.Vista.IdataProducto _fichaPrd = new Producto.Precio.zufu.ActualizarPrecio.Handler.dataProducto()
            {
                idPrd = it.prdAuto,
                tasaIva = it.tasaIva,
                codigoPrd = it.prdCodigo,
                descPrd = it.prdNombre,
                contEmpCompra = it.contenidoEmp,
                costoCompra = it.prdCostoActualDivisa ,
                empaqueDesc = it.empaqueCompra,
                tasaIvaDesc = "",
                admDivisa = it.esAdmDivisa,
            };
            //
            var _aRecuperar = new List<recuperar>();
            var _tipo1 = new recuperar(it.preciosVtaPend[0].descEmpVta, 
                                        it.preciosVtaPend[0].contEmpVta,
                                        new decimal[] { it.preciosVtaPend[0].pVta1, 
                                                        it.preciosVtaPend[0].pVta2,
                                                        it.preciosVtaPend[0].pVta3,
                                                        it.preciosVtaPend[0].pVta4});
            var _tipo2 = new recuperar(it.preciosVtaPend[1].descEmpVta,
                                        it.preciosVtaPend[1].contEmpVta,
                                        new decimal[] { it.preciosVtaPend[1].pVta1, 
                                                        it.preciosVtaPend[1].pVta2,
                                                        it.preciosVtaPend[1].pVta3,
                                                        it.preciosVtaPend[1].pVta4});
            var _tipo3 = new recuperar(it.preciosVtaPend[2].descEmpVta,
                                        it.preciosVtaPend[2].contEmpVta,
                                        new decimal[] { it.preciosVtaPend[2].pVta1, 
                                                        it.preciosVtaPend[2].pVta2,
                                                        it.preciosVtaPend[2].pVta3,
                                                        it.preciosVtaPend[2].pVta4});
            _aRecuperar.Add(_tipo1);
            _aRecuperar.Add(_tipo2);
            _aRecuperar.Add(_tipo3);
            //
            Producto.Precio.zufu.ActualizarPrecio.Vista.IMatPrecio[] _dataPrecios;
            _dataPrecios = new Producto.Precio.zufu.ActualizarPrecio.Handler.ImpMatPrecio[3];
            var x = 0;
            var _met = Producto.Precio.zufu.CtrlPrecio.enumerados.enumMetCalculoUtilidad.Financiero;
            if (metCalcUt == OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Lineal) 
            {
                _met = Producto.Precio.zufu.CtrlPrecio.enumerados.enumMetCalculoUtilidad.Lineal;
            }
            foreach (var rec in _aRecuperar)
            {
                var _descEmpVta = rec.descEmpaque;
                var _costoxUnd = _fichaPrd.CostoxUnidad;
                var _contEmpVta = rec.contEmpaque;
                //
                _dataPrecios[x] = new Producto.Precio.zufu.ActualizarPrecio.Handler.ImpMatPrecio();
                Producto.Precio.zufu.CtrlPrecio.IPrecio p1 =
                    new Producto.Precio.zufu.CtrlPrecio.ImpPrecio(
                        _costoxUnd,
                        _contEmpVta,
                        _fichaPrd.tasaIva,
                        _met,
                        rec.precios[0]);
                Producto.Precio.zufu.CtrlPrecio.IPrecio p2 =
                    new Producto.Precio.zufu.CtrlPrecio.ImpPrecio(
                        _costoxUnd,
                        _contEmpVta,
                        _fichaPrd.tasaIva,
                        _met,
                        rec.precios[1]);
                Producto.Precio.zufu.CtrlPrecio.IPrecio p3 =
                    new Producto.Precio.zufu.CtrlPrecio.ImpPrecio(
                        _costoxUnd,
                        _contEmpVta,
                        _fichaPrd.tasaIva,
                        _met,
                        rec.precios[2]);
                Producto.Precio.zufu.CtrlPrecio.IPrecio p4 =
                    new Producto.Precio.zufu.CtrlPrecio.ImpPrecio(
                        _costoxUnd,
                        _contEmpVta,
                        _fichaPrd.tasaIva,
                        _met,
                        rec.precios[3]);
                _dataPrecios[x].RecuperarPrecios(_descEmpVta, _contEmpVta, p1, p2, p3, p4);
                x += 1;
            }
            //
            return _dataPrecios;
        }
    }
}