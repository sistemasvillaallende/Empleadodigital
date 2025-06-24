using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class FICHADA : DALBase
    {

        public FICHADA()
        {
        }

        private static List<FICHADA> mapeo(SqlDataReader dr)
        {
            List<FICHADA> lst = new List<FICHADA>();
            FICHADA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new FICHADA();
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<FICHADA> read()
        {
            try
            {
                List<FICHADA> lst = new List<FICHADA>();
                using (SqlConnection con = GetConnection("Clock"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FICHADA";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FICHADA getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM FICHADA WHERE");
                FICHADA obj = null;
                using (SqlConnection con = GetConnection("Clock"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<FICHADA> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

