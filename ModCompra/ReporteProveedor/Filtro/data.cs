using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.ReporteProveedor.Filtro
{
    
    public class data
    {

        private general _grupo;
        private general _estado;
        private general _estatus;


        public general Grupo { get { return _grupo; } }
        public general Estado { get { return _estado; } }
        public general Estatus { get { return _estatus; } }


        public data()
        {
            limpiar();
        }


        private void limpiar()
        {
            _grupo = null;
            _estado = null;
            _estatus = null;
        }

        public bool IsOk()
        {
            var rt = true;

            return rt;
        }

        public void Inicializa()
        {
            limpiar();
        }

        public void setGrupo(general ficha)
        {
            _grupo = ficha;
        }

        public void setEstado(general ficha)
        {
            _estado = ficha;
        }

        public void setEstatus(general ficha)
        {
            _estatus = ficha;
        }

    }

}