using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LIQ_X_EMPLEADO
    {
        public static List<DAL.LIQ_X_EMPLEADO> getLiquidaciones(int anio, int legajo, bool aginaldo)
        {
            try
            {
                return DAL.LIQ_X_EMPLEADO.getLiquidaciones(anio, legajo, aginaldo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
