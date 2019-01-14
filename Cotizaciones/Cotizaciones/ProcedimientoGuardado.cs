using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Cotizaciones
{
    public static class ProcedimientoGuardado
    {
        private static List<InterfazClasesBD> listaClases;
        public static bool guardar()
        {
            bool completo = true;

            using (var transaccion = new TransactionScope())
            {
                try
                {
                    foreach (InterfazClasesBD clase in listaClases)
                    {
                        completo = (completo) ? clase.guardar() : completo;
                    }
                    if (completo) transaccion.Complete();
                    else transaccion.Dispose();
                }
                catch (Exception ex)
                {
                    transaccion.Dispose();
                }
            }
            
            limpiarLista();

            return completo;
        }
        public static void agregarClase(InterfazClasesBD clase)
        {
            listaClases.Add(clase);
        }
        private static void limpiarLista()
        {
            listaClases = new List<InterfazClasesBD>();
        }
    }
}
