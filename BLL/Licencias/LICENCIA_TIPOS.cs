using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Licencias
{
    public class LICENCIA_TIPOS
    {
        public static List<DAL.LICENCIAS> read()
        {
            try
            {
                return DAL.LICENCIAS.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DAL.LICENCIAS getByPk(
        int cod_tipo_licencia)
        {
            try
            {
                return DAL.LICENCIAS.getByPk(cod_tipo_licencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(DAL.LICENCIAS obj)
        {
            try
            {
                return DAL.LICENCIAS.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(DAL.LICENCIAS obj)
        {
            try
            {
                DAL.LICENCIAS.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int id)
        {
            try
            {
                DAL.LICENCIAS.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void activaDesactvia(int id, bool activa)
        {
            try
            {
                DAL.LICENCIAS.activaDesactvia(id, activa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
