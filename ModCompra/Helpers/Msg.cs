﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Helpers
{
    public class Msg
    {
        public static void Error(string msg)
        {
            MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void EliminarOk()
        {
            MessageBox.Show("Ficha Eliminada Exitosamente...", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void AgregarOk()
        {
            MessageBox.Show("Ficha Agregada Exitosamente...", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void EditarOk()
        {
            MessageBox.Show("Ficha Actualizada Exitosamente...", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Alerta(string msg)
        {
            MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void OK(string msg="!! Muy Bien... Proceso Realizado Con Exito !!")
        {
            MessageBox.Show(msg, "*** OK ***", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool Abandonar(string msg = "Abandonar Ficha Sin Procesar Cambios ?")
        {
            return (MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
        public static bool Procesar(string msg = "Procesar / Guardar Cambios ?")
        {
            return (MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
    }
}