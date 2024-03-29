﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Filtro.CxpPagosEmitido
{
    public class Imp: Vistas.IFiltro
    {
        private bool _abandonarIsOK;
        private bool _procesarIsOK;
        private Vistas.IHndFiltro _hndFiltro;


        public Vistas.IHndFiltro HndFiltro { get { return _hndFiltro; } }

       
        public Imp()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _hndFiltro = new Handler.HndFiltro();
        }
        public void Inicializa()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _hndFiltro.Inicializa();
        }
        Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null) 
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = true;
        }

        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public void Procesar()
        {
            _procesarIsOK = true;
        }


        private bool cargarData()
        {
            _hndFiltro.CargarData();
            return true;
        }
        public void Limpiar()
        {
            _hndFiltro.Limpiar();
        }
    }
}