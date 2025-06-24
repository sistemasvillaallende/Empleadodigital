using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LIQUIDACIONES
    {
        public static List<DAL.LIQUIDACIONES> read()
        {
            try
            {
                return DAL.LIQUIDACIONES.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DAL.LIQUIDACIONES getByPk(int anio, int cod_tipo_liq, int nro_liquidacion)
        {
            try
            {

                return DAL.LIQUIDACIONES.getByPk(anio, cod_tipo_liq, nro_liquidacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int getUltimoHaber(int legajo, int anio)
        {
            try
            {
                return DAL.LIQUIDACIONES.getUltimoHaber(legajo, anio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(DAL.LIQUIDACIONES obj)
        {
            try
            {
                return DAL.LIQUIDACIONES.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(DAL.LIQUIDACIONES obj)
        {
            try
            {
                DAL.LIQUIDACIONES.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(DAL.LIQUIDACIONES obj)
        {
            try
            {
                DAL.LIQUIDACIONES.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
