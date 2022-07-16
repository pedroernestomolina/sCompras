using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionTotalizarFac: Controlador.IGestionTotalizar
    {

        public bool IsOk { get; set; }
        public decimal Dscto { get { return dscto; } }
        public decimal Cargo { get { return cargo; } }
        public decimal Monto { get { return _monto; } }
        public string Notas { get { return _notas; } }
        public bool HabilitarDscto { get { return true; } }
        public bool HabilitarCargo { get { return true; } }
        public decimal Total 
        { 
            get 
            { 
                if (_total==0.0m)
                    CalculaTotal();
                return _total;
            }
        }

        private decimal dscto;
        private decimal cargo;
        private string _notas;
        private decimal _monto;
        private decimal _total;


        public GestionTotalizarFac()
        {
            IsOk = false;
        }


        public void Inicializar()
        {
            IsOk = false;
            dscto = 0.0m;
            cargo = 0.0m;
        }

        public void Guardar()
        {
            var ms = MessageBox.Show("Estas Seguro de Guardar El Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ms == DialogResult.Yes)
            {
                IsOk = true;
            }
        }

        public void SetMonto(decimal p)
        {
            _monto = p;
        }

        public void SetNotas(string p)
        {
            _notas = p;
        }

        public void setDscto(decimal p)
        {
            dscto = p;
            CalculaTotal();
        }

        public void setCargo(decimal p)
        {
            cargo = p;
            CalculaTotal();
        }

        private void CalculaTotal()
        {
            var _dsctoM = (_monto * dscto / 100);
            var _cargoM = (_monto - _dsctoM) * (cargo / 100);
            _total = (_monto - _dsctoM + _cargoM);
        }
       
        Formulario.TotalizarFrm totalizarFrm;
        public void Inicia()
        {
            Inicializar();
            totalizarFrm = new Formulario.TotalizarFrm();
            totalizarFrm.setControlador(this);
            totalizarFrm.ShowDialog();
        }

        public void Limpiar()
        {
        }

    }

}