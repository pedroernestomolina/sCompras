﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.Administrador.Vistas
{
    public interface IBusqDoc
    {
        void Inicializa();
        IEnumerable<object> Buscar();
        void setFiltros(object filtros);
    }
}