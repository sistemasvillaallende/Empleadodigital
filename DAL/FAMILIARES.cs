using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class FAMILIARES : DALBase
    {
        public int legajo { get; set; }
        public int nro_familiar { get; set; }
        public DateTime fecha_alta_registro { get; set; }
        public string nombre { get; set; }
        public int cod_tipo_documento { get; set; }
        public string nro_documento { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string parentezco { get; set; }
        public int sexo { get; set; }
        public bool salario_familiar { get; set; }
        public bool incapacitado { get; set; }

        public FAMILIARES()
        {
            legajo = 0;
            nro_familiar = 0;
            fecha_alta_registro = DateTime.Now;
            nombre = string.Empty;
            cod_tipo_documento = 0;
            nro_documento = string.Empty;
            fecha_nacimiento = DateTime.Now;
            parentezco = string.Empty;
            sexo = 0;
            salario_familiar = false;
            incapacitado = false;
        }

        private static List<FAMILIARES> mapeo(SqlDataReader dr)
        {
            List<FAMILIARES> lst = new List<FAMILIARES>();
            FAMILIARES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new FAMILIARES();
                    if (!dr.IsDBNull(0)) { obj.legajo = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nro_familiar = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.fecha_alta_registro = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.nombre = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.cod_tipo_documento = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.nro_documento = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.fecha_nacimiento = dr.GetDateTime(6); }
                    if (!dr.IsDBNull(7)) { obj.parentezco = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.sexo = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.salario_familiar = dr.GetBoolean(9); }
                    if (!dr.IsDBNull(10)) { obj.incapacitado = dr.GetBoolean(10); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<FAMILIARES> read()
        {
            try
            {
                List<FAMILIARES> lst = new List<FAMILIARES>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FAMILIARES";
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
        public static List<FAMILIARES> read(int legajo)
        {
            try
            {
                List<FAMILIARES> lst = new List<FAMILIARES>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FAMILIARES WHERE LEGAJO=@LEGAJO";
                    cmd.Parameters.AddWithValue("@LEGAJO", legajo);
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
        public static FAMILIARES getByPk(
        int legajo, int nro_familiar)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM FAMILIARES WHERE");
                sql.AppendLine("legajo = @legajo");
                sql.AppendLine("AND nro_familiar = @nro_familiar");
                FAMILIARES obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@nro_familiar", nro_familiar);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<FAMILIARES> lst = mapeo(dr);
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

        public static int insert(FAMILIARES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO FAMILIARES(");
                sql.AppendLine("legajo");
                sql.AppendLine(", nro_familiar");
                sql.AppendLine(", fecha_alta_registro");
                sql.AppendLine(", nombre");
                sql.AppendLine(", cod_tipo_documento");
                sql.AppendLine(", nro_documento");
                sql.AppendLine(", fecha_nacimiento");
                sql.AppendLine(", parentezco");
                sql.AppendLine(", sexo");
                sql.AppendLine(", salario_familiar");
                sql.AppendLine(", incapacitado");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@legajo");
                sql.AppendLine(", @nro_familiar");
                sql.AppendLine(", @fecha_alta_registro");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @cod_tipo_documento");
                sql.AppendLine(", @nro_documento");
                sql.AppendLine(", @fecha_nacimiento");
                sql.AppendLine(", @parentezco");
                sql.AppendLine(", @sexo");
                sql.AppendLine(", @salario_familiar");
                sql.AppendLine(", @incapacitado");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@nro_familiar", obj.nro_familiar);
                    cmd.Parameters.AddWithValue("@fecha_alta_registro", obj.fecha_alta_registro);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@cod_tipo_documento", obj.cod_tipo_documento);
                    cmd.Parameters.AddWithValue("@nro_documento", obj.nro_documento);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", obj.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@parentezco", obj.parentezco);
                    cmd.Parameters.AddWithValue("@sexo", obj.sexo);
                    cmd.Parameters.AddWithValue("@salario_familiar", obj.salario_familiar);
                    cmd.Parameters.AddWithValue("@incapacitado", obj.incapacitado);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(FAMILIARES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  FAMILIARES SET");
                sql.AppendLine("fecha_alta_registro=@fecha_alta_registro");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine(", cod_tipo_documento=@cod_tipo_documento");
                sql.AppendLine(", nro_documento=@nro_documento");
                sql.AppendLine(", fecha_nacimiento=@fecha_nacimiento");
                sql.AppendLine(", parentezco=@parentezco");
                sql.AppendLine(", sexo=@sexo");
                sql.AppendLine(", salario_familiar=@salario_familiar");
                sql.AppendLine(", incapacitado=@incapacitado");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND nro_familiar=@nro_familiar");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@nro_familiar", obj.nro_familiar);
                    cmd.Parameters.AddWithValue("@fecha_alta_registro", obj.fecha_alta_registro);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@cod_tipo_documento", obj.cod_tipo_documento);
                    cmd.Parameters.AddWithValue("@nro_documento", obj.nro_documento);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", obj.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@parentezco", obj.parentezco);
                    cmd.Parameters.AddWithValue("@sexo", obj.sexo);
                    cmd.Parameters.AddWithValue("@salario_familiar", obj.salario_familiar);
                    cmd.Parameters.AddWithValue("@incapacitado", obj.incapacitado);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(FAMILIARES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  FAMILIARES ");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND nro_familiar=@nro_familiar");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@nro_familiar", obj.nro_familiar);
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

