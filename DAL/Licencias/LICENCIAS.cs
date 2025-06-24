using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class LICENCIAS : DALBase
    {
        public int cod_tipo_licencia { get; set; }
        public string descripcion { get; set; }
        public bool fija { get; set; }
        public int cantidad_dias { get; set; }
        public bool activa { get; set; }
        public int sexo { get; set; }
        public bool masiva { get; set; }
        public bool acumula { get; set; }
        public bool habiles { get; set; }
        public bool separa { get; set; }
        public int fraccion { get; set; }
        public int tipo { get; set; }

        public enum sex { Indistinto, Mujer, Hombre }

        public LICENCIAS()
        {
            cod_tipo_licencia = 0;
            descripcion = string.Empty;
            fija = false;
            cantidad_dias = 0;
            activa = true;
            sexo = 0;
            masiva = false;
            acumula = false;
            habiles = true;
            separa = true;
            fraccion = 0;
            tipo = 0;
        }

        private static List<LICENCIAS> mapeo(SqlDataReader dr)
        {
            List<LICENCIAS> lst = new List<LICENCIAS>();
            LICENCIAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new LICENCIAS();
                    if (!dr.IsDBNull(0)) { obj.cod_tipo_licencia = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.fija = dr.GetBoolean(2); }
                    if (!dr.IsDBNull(3)) { obj.cantidad_dias = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.activa = dr.GetBoolean(4); }
                    if (!dr.IsDBNull(5)) { obj.sexo = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.masiva = dr.GetBoolean(6); }
                    if (!dr.IsDBNull(7)) { obj.acumula = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.habiles = dr.GetBoolean(8); }
                    if (!dr.IsDBNull(9)) { obj.separa = dr.GetBoolean(9); }
                    if (!dr.IsDBNull(10)) { obj.fraccion = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.tipo = dr.GetInt32(11); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<LICENCIAS> read()
        {
            try
            {
                List<LICENCIAS> lst = new List<LICENCIAS>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM LICENCIAS";
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

        public static LICENCIAS getByPk(
        int cod_tipo_licencia)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM LICENCIAS WHERE");
                sql.AppendLine("cod_tipo_licencia = @cod_tipo_licencia");
                LICENCIAS obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", cod_tipo_licencia);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<LICENCIAS> lst = mapeo(dr);
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

        public static int insert(LICENCIAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO LICENCIAS(");
                sql.AppendLine("descripcion");
                sql.AppendLine(", fija");
                sql.AppendLine(", cantidad_dias");
                sql.AppendLine(", activa");
                sql.AppendLine(", sexo");
                sql.AppendLine(", masiva");
                sql.AppendLine(", acumula");
                sql.AppendLine(", habiles");
                sql.AppendLine(", separa");
                sql.AppendLine(", fraccion");
                sql.AppendLine(", tipo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@descripcion");
                sql.AppendLine(", @fija");
                sql.AppendLine(", @cantidad_dias");
                sql.AppendLine(", @activa");
                sql.AppendLine(", @sexo");
                sql.AppendLine(", @masiva");
                sql.AppendLine(", @acumula");
                sql.AppendLine(", @habiles");
                sql.AppendLine(", @separa");
                sql.AppendLine(", @fraccion");
                sql.AppendLine(", @tipo");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@fija", obj.fija);
                    cmd.Parameters.AddWithValue("@cantidad_dias", obj.cantidad_dias);
                    cmd.Parameters.AddWithValue("@activa", obj.activa);
                    cmd.Parameters.AddWithValue("@sexo", obj.sexo);
                    cmd.Parameters.AddWithValue("@masiva", obj.masiva);
                    cmd.Parameters.AddWithValue("@acumula", obj.acumula);
                    cmd.Parameters.AddWithValue("@habiles", obj.habiles);
                    cmd.Parameters.AddWithValue("@separa", obj.separa);
                    cmd.Parameters.AddWithValue("@fraccion", obj.fraccion);
                    cmd.Parameters.AddWithValue("@tipo", obj.tipo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(LICENCIAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LICENCIAS SET");
                sql.AppendLine("descripcion=@descripcion");
                sql.AppendLine(", fija=@fija");
                sql.AppendLine(", cantidad_dias=@cantidad_dias");
                sql.AppendLine(", sexo=@sexo");
                sql.AppendLine(", masiva=@masiva");
                sql.AppendLine(", acumula=@acumula");
                sql.AppendLine(", habiles=@habiles");
                sql.AppendLine(", separa=@separa");
                sql.AppendLine(", fraccion=@fraccion");
                sql.AppendLine(", tipo=@tipo");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_tipo_licencia=@cod_tipo_licencia");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@fija", obj.fija);
                    cmd.Parameters.AddWithValue("@cantidad_dias", obj.cantidad_dias);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", obj.cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@sexo", obj.sexo);
                    cmd.Parameters.AddWithValue("@masiva", obj.masiva);
                    cmd.Parameters.AddWithValue("@acumula", obj.acumula);
                    cmd.Parameters.AddWithValue("@habiles", obj.habiles);
                    cmd.Parameters.AddWithValue("@separa", obj.separa);
                    cmd.Parameters.AddWithValue("@fraccion", obj.fraccion);
                    cmd.Parameters.AddWithValue("@tipo", obj.tipo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
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
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  LICENCIAS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_tipo_licencia=@cod_tipo_licencia");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
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
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LICENCIAS SET");
                sql.AppendLine("activa=@activa");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_tipo_licencia=@cod_tipo_licencia");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@activa", activa);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", id);
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

