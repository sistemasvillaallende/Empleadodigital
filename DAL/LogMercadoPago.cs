using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class LogMercadoPago : DALBase
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string response { get; set; }

        public LogMercadoPago()
        {
            id = 0;
            fecha = DateTime.Now;
            response = string.Empty;
        }

        private static List<LogMercadoPago> mapeo(SqlDataReader dr)
        {
            List<LogMercadoPago> lst = new List<LogMercadoPago>();
            LogMercadoPago obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new LogMercadoPago();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.fecha = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.response = dr.GetString(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<LogMercadoPago> read()
        {
            try
            {
                List<LogMercadoPago> lst = new List<LogMercadoPago>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM LogMercadoPago";
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

        public static LogMercadoPago getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM LogMercadoPago WHERE");
                sql.AppendLine("id = @id");
                LogMercadoPago obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<LogMercadoPago> lst = mapeo(dr);
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

        public static int insert(LogMercadoPago obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO LogMercadoPago(");
                sql.AppendLine("fecha");
                sql.AppendLine(", response");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@fecha");
                sql.AppendLine(", @response");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@response", obj.response);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(LogMercadoPago obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LogMercadoPago SET");
                sql.AppendLine("fecha=@fecha");
                sql.AppendLine(", response=@response");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@response", obj.response);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(LogMercadoPago obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  LogMercadoPago ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

