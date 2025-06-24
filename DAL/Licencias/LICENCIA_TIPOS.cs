using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class LICENCIA_TIPOS : DALBase
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }

        public LICENCIA_TIPOS()
        {
            ID = 0;
            DESCRIPCION = string.Empty;
        }

        private static List<LICENCIA_TIPOS> mapeo(SqlDataReader dr)
        {
            List<LICENCIA_TIPOS> lst = new List<LICENCIA_TIPOS>();
            LICENCIA_TIPOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new LICENCIA_TIPOS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.DESCRIPCION = dr.GetString(1); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<LICENCIA_TIPOS> read()
        {
            try
            {
                List<LICENCIA_TIPOS> lst = new List<LICENCIA_TIPOS>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM LICENCIA_TIPOS";
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

        public static LICENCIA_TIPOS getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM LICENCIA_TIPOS WHERE");
                sql.AppendLine("ID = @ID");
                LICENCIA_TIPOS obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<LICENCIA_TIPOS> lst = mapeo(dr);
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

        public static int insert(LICENCIA_TIPOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO LICENCIA_TIPOS(");
                sql.AppendLine("DESCRIPCION");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@DESCRIPCION");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(LICENCIA_TIPOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LICENCIA_TIPOS SET");
                sql.AppendLine("DESCRIPCION=@DESCRIPCION");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(LICENCIA_TIPOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  LICENCIA_TIPOS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
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

