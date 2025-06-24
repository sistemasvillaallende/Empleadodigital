using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class DIA : DALBase
    {
        public int TUR_CODIGO { get; set; }
        public int DIA_NUMERO { get; set; }
        public string DIA_NOMBRE { get; set; }
        public string DIA_HORACORTE { get; set; }
        public Single DIA_CANTOBL { get; set; }
        public Single DIA_FCANTOBL { get; set; }
        public string DIA_ENTRA { get; set; }
        public string DIA_FDESC { get; set; }

        public DIA()
        {
            TUR_CODIGO = 0;
            DIA_NUMERO = 0;
            DIA_NOMBRE = string.Empty;
            DIA_HORACORTE = string.Empty;
            DIA_CANTOBL = 0;
            DIA_FCANTOBL = 0;
            DIA_ENTRA = string.Empty;
            DIA_FDESC = string.Empty;
        }

        private static List<DIA> mapeo(SqlDataReader dr)
        {
            List<DIA> lst = new List<DIA>();
            DIA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new DIA();
                    if (!dr.IsDBNull(0)) { obj.TUR_CODIGO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.DIA_NUMERO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.DIA_NOMBRE = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.DIA_HORACORTE = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.DIA_CANTOBL = dr.GetFloat(4); }
                    if (!dr.IsDBNull(5)) { obj.DIA_FCANTOBL = dr.GetFloat(5); }
                    if (!dr.IsDBNull(6)) { obj.DIA_ENTRA = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.DIA_FDESC = dr.GetString(7); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<DIA> read()
        {
            try
            {
                List<DIA> lst = new List<DIA>();
                using (SqlConnection con = GetConnection("Clock"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM DIA";
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

        public static DIA getByPk(
        int TUR_CODIGO, int DIA_NUMERO)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM DIA WHERE");
                sql.AppendLine("TUR_CODIGO = @TUR_CODIGO");
                sql.AppendLine("AND DIA_NUMERO = @DIA_NUMERO");
                DIA obj = null;
                using (SqlConnection con = GetConnection("Clock"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@TUR_CODIGO", TUR_CODIGO);
                    cmd.Parameters.AddWithValue("@DIA_NUMERO", DIA_NUMERO);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<DIA> lst = mapeo(dr);
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

