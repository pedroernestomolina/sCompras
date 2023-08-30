using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CompraGasto.Handlres.Generar
{
    public class dataFiscal: Vistas.Generar.IdataFiscal
    {
        private decimal _monto;
        private decimal _tasa;
        private decimal _imp;


        public decimal Get_Tasa { get { return _tasa; } }
        public decimal Get_Base { get { return _monto; } }
        public decimal Get_Imp { get { return _imp; } }


        public dataFiscal()
        {
            _monto = 0m;
            _imp = 0m;
            _tasa = 0m;
        }
        public void Inicializa()
        {
            _monto = 0m;
            _imp = 0m;
        }

        public void SetTasa(decimal tasa)
        {
            _tasa = tasa;
            calculaImp();
        }
        public void SetBase(decimal monto)
        {
            _monto = monto;
            calculaImp();
        }

        private void calculaImp()
        {
            _imp = (_monto * _tasa / 100);
        }
    }
}