using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class INTERVALO : DALBase
    {
        public int TUR_CODIGO { get; set; }
        public int DIA_NUMERO { get; set; }
        public string INT_TIPO { get; set; }
        public int INT_NUMERO { get; set; }
        public string INT_DESDE { get; set; }
        public string INT_DESSIG { get; set; }
        public string INT_HASTA { get; set; }
        public string INT_HASSIG { get; set; }
        public int CON_CODIGO { get; set; }
        public string INT_OBLIG { get; set; }
        public string INT_TOLER { get; set; }
        public int INT_TOLDES { get; set; }
        public int INT_TOLHAS { get; set; }

        public INTERVALO()
        {
            TUR_CODIGO = 0;
            DIA_NUMERO = 0;
            INT_TIPO = string.Empty;
            INT_NUMERO = 0;
            INT_DESDE = string.Empty;
            INT_DESSIG = string.Empty;
            INT_HASTA = string.Empty;
            INT_HASSIG = string.Empty;
            CON_CODIGO = 0;
            INT_OBLIG = string.Empty;
            INT_TOLER = string.Empty;
            INT_TOLDES = 0;
            INT_TOLHAS = 0;
        }

        private static List<INTERVALO> mapeo(SqlDataReader dr)
        {
            List<INTERVALO> lst = new List<INTERVALO>();
            INTERVALO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new INTERVALO();
                    if (!dr.IsDBNull(0)) { obj.TUR_CODIGO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.DIA_NUMERO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.INT_TIPO = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.INT_NUMERO = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.INT_DESDE = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.INT_DESSIG = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.INT_HASTA = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.INT_HASSIG = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.CON_CODIGO = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.INT_OBLIG = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.INT_TOLER = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.INT_TOLDES = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.INT_TOLHAS = dr.GetInt32(12); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<INTERVALO> read()
        {
            try
            {
                List<INTERVALO> lst = new List<INTERVALO>();
                using (SqlConnection con = GetConnection("Clock"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM INTERVALO";
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

        public static INTERVALO getByPk(
        int TUR_CODIGO, int DIA_NUMERO, char INT_TIPO, int INT_NUMERO)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM INTERVALO WHERE");
                sql.AppendLine("TUR_CODIGO = @TUR_CODIGO");
                sql.AppendLine("AND DIA_NUMERO = @DIA_NUMERO");
                sql.AppendLine("AND INT_TIPO = @INT_TIPO");
                sql.AppendLine("AND INT_NUMERO = @INT_NUMERO");
                INTERVALO obj = null;
                using (SqlConnection con = GetConnection("Clock"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@TUR_CODIGO", TUR_CODIGO);
                    cmd.Parameters.AddWithValue("@DIA_NUMERO", DIA_NUMERO);
                    cmd.Parameters.AddWithValue("@INT_TIPO", INT_TIPO);
                    cmd.Parameters.AddWithValue("@INT_NUMERO", INT_NUMERO);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<INTERVALO> lst = mapeo(dr);
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

