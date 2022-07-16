using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{

    public class GestionTotalizar
    {

        private IGestionTotalizar _gestion;


        public bool IsOk { get { return _gestion.IsOk; } }
        public decimal Dscto { get { return _gestion.Dscto; } }
        public decimal Cargo { get { return _gestion.Cargo; } }
        public decimal Monto { get { return _gestion.Monto; } }
        public string Notas { get { return _gestion.Notas; } }
        public decimal Total { get { return _gestion.Total; } }


        public void setGestion(IGestionTotalizar gestion)
        {
            _gestion = gestion;
        }

        //Formulario.TotalizarFrm totalizarFrm;
        //public void Inicia()
        //{
        //    _gestion.Inicializar();
        //    totalizarFrm = new Formulario.TotalizarFrm();
        //    totalizarFrm.setControlador(this);
        //    totalizarFrm.ShowDialog();
        //}


        public void Guardar()
        {
            _gestion.Guardar();
        }


        public void SetMonto(decimal p)
        {
            _gestion.SetMonto(p);
        }

        public void SetNotas(string p)
        {
            _gestion.SetNotas(p);
        }

        public void setDscto(decimal p)
        {
            _gestion.setDscto(p);
        }

        public void setCargo(decimal p)
        {
            _gestion.setCargo(p);
        }

    }

}