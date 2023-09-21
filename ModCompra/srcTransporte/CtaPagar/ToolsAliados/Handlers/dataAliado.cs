using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Handlers
{
    public class dataAliado: Vistas.IdataAliado
    {
        private OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha _ficha;


        public int Id { get; set; }
        public string ciRif { get; set; }
        public string nombreRazonSocial { get; set; }
        public decimal pendiente { get; set; }
        public decimal anticipos { get; set; }
        public decimal montoResta { get; set; }
        public int cntDocPend { get; set; }


        public dataAliado(OOB.LibCompra.Transporte.Aliado.Pendiente.Ficha ficha)
        {
            this._ficha = ficha;
            var _pendiente= (ficha.importeDiv-ficha.acumuladoDiv);
            var _anticipos = (ficha.montoAnticipoDiv - ficha.montoAnticipoAnuladoDiv);
            var _resta= _pendiente-anticipos;
            //
            Id = ficha.aliadoId;
            ciRif = ficha.aliadoCiRif;
            nombreRazonSocial = ficha.aliadoNombre;
            pendiente=_pendiente;
            anticipos=_anticipos;
            montoResta=_resta-_anticipos;
            cntDocPend = _ficha.cntDoc;
        }
    }
}