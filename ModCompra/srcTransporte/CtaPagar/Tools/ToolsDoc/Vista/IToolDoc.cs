using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.ToolsDoc.Vista
{
    public interface IToolDoc: ITools 
    {
        object CtaPendiente_Actual { get; }
        //
        void PagoPorRetencion();
        void VisualizarDoc();
    }
}