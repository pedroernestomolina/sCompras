using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Caja.Lista
{
    public class Ficha
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal saldoInicial { get; set; }
        public decimal montoPorIngresos { get; set; }
        public decimal montoPorEgresos { get; set; }
        public decimal montoPorAnulaciones { get; set; }
        public string estatusAnulado { get; set; }
        public string esDivisa { get; set; }


        public Ficha() 
        {
        }
        public Ficha(Crud.Entidad.Ficha ficha)
        {
            id = ficha.id;
            codigo = ficha.codigo;
            descripcion = ficha.descripcion;
            saldoInicial = ficha.saldoInicial;
            montoPorIngresos = (ficha.montoIngreso -ficha.montoIngresoAnulado);
            montoPorEgresos = (ficha.montoEgreso-ficha.montoEgresoAnulado);
            montoPorAnulaciones = 0m;
            estatusAnulado = ficha.estatusAnulado;
            esDivisa = ficha.esDivisa;
        }
    }
}