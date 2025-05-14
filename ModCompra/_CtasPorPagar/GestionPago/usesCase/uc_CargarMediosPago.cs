using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.usesCase
{
    public class uc_CargarMediosPago: __.UsesCase.GestionPago.ICargarMediosPago
    {
        public IEnumerable<__.Modelos.GestionPago.IMedioPago> Execute()
        {
            var _lst = new List<modelos.MedioPago>();
            var r01 = Sistema.MyData.Transporte_MedioPago_GetLista();
            var _lt = r01.Lista.OrderBy(o => o.nombre).ToList();
            foreach (var rg in _lt)
            {
                var nr = new modelos.MedioPago()
                {
                    codigo = rg.codigo,
                    descripcion = rg.nombre,
                    id = rg.id,
                };
                _lst.Add(nr);
            }
            return _lst;
        }
    }
}