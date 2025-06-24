using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class LIQUIDACIONES : DALBase
    {
        public int anio { get; set; }
        public int cod_tipo_liq { get; set; }
        public int nro_liquidacion { get; set; }
        public DateTime fecha_alta_registro { get; set; }
        public bool aguinaldo { get; set; }
        public string des_liquidacion { get; set; }
        public string periodo { get; set; }
        public DateTime fecha_liquidacion { get; set; }
        public DateTime fecha_pago { get; set; }
        public string per_ult_dep { get; set; }
        public int cod_banco_ult_dep { get; set; }
        public DateTime fecha_ult_dep { get; set; }
        public int cod_semestre { get; set; }
        public string usuario { get; set; }
        public string operacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public bool publica { get; set; }

        public LIQUIDACIONES()
        {
            anio = 0;
            cod_tipo_liq = 0;
            nro_liquidacion = 0;
            fecha_alta_registro = DateTime.Now;
            aguinaldo = false;
            des_liquidacion = string.Empty;
            periodo = string.Empty;
            fecha_liquidacion = DateTime.Now;
            fecha_pago = DateTime.Now;
            per_ult_dep = string.Empty;
            cod_banco_ult_dep = 0;
            fecha_ult_dep = DateTime.Now;
            cod_semestre = 0;
            usuario = string.Empty;
            operacion = string.Empty;
            fecha_modificacion = DateTime.Now;
            publica = false;
        }

        private static List<LIQUIDACIONES> mapeo(SqlDataReader dr)
        {
            List<LIQUIDACIONES> lst = new List<LIQUIDACIONES>();
            LIQUIDACIONES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new LIQUIDACIONES();
                    if (!dr.IsDBNull(0)) { obj.anio = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.cod_tipo_liq = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.nro_liquidacion = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.fecha_alta_registro = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.aguinaldo = dr.GetBoolean(4); }
                    if (!dr.IsDBNull(5)) { obj.des_liquidacion = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.periodo = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.fecha_liquidacion = dr.GetDateTime(7); }
                    if (!dr.IsDBNull(8)) { obj.fecha_pago = dr.GetDateTime(8); }
                    if (!dr.IsDBNull(9)) { obj.per_ult_dep = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.cod_banco_ult_dep = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.fecha_ult_dep = dr.GetDateTime(11); }
                    if (!dr.IsDBNull(12)) { obj.cod_semestre = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.usuario = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.operacion = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.fecha_modificacion = dr.GetDateTime(15); }
                    if (!dr.IsDBNull(16)) { obj.publica = dr.GetBoolean(16); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<LIQUIDACIONES> read()
        {
            try
            {
                List<LIQUIDACIONES> lst = new List<LIQUIDACIONES>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM LIQUIDACIONES";
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

        public static LIQUIDACIONES getByPk(int anio, int cod_tipo_liq, int nro_liquidacion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM LIQUIDACIONES WHERE");
                sql.AppendLine("anio = @anio");
                sql.AppendLine("AND cod_tipo_liq = @cod_tipo_liq");
                sql.AppendLine("AND nro_liquidacion = @nro_liquidacion");
                LIQUIDACIONES obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", cod_tipo_liq);
                    cmd.Parameters.AddWithValue("@nro_liquidacion", nro_liquidacion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<LIQUIDACIONES> lst = mapeo(dr);
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

        public static int getUltimoHaber(int legajo, int anio)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT sueldo_neto");
                sql.AppendLine("FROM LIQ_X_EMPLEADO");
                sql.AppendLine("WHERE legajo = @LEGAJO AND anio = @ANIO AND nro_liquidacion = ");
                sql.AppendLine("(SELECT MAX(A.nro_liquidacion) FROM LIQ_X_EMPLEADO A");
                sql.AppendLine("INNER JOIN LIQUIDACIONES B ON A.anio = B.anio AND A.nro_liquidacion = B.nro_liquidacion AND B.publica = 1");
                sql.AppendLine("WHERE A.anio = @ANIO AND legajo = @LEGAJO)");

                LIQUIDACIONES obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ANIO", anio);
                    cmd.Parameters.AddWithValue("@LEGAJO", legajo);

                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(LIQUIDACIONES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO LIQUIDACIONES(");
                sql.AppendLine("anio");
                sql.AppendLine(", cod_tipo_liq");
                sql.AppendLine(", nro_liquidacion");
                sql.AppendLine(", fecha_alta_registro");
                sql.AppendLine(", aguinaldo");
                sql.AppendLine(", des_liquidacion");
                sql.AppendLine(", periodo");
                sql.AppendLine(", fecha_liquidacion");
                sql.AppendLine(", fecha_pago");
                sql.AppendLine(", per_ult_dep");
                sql.AppendLine(", cod_banco_ult_dep");
                sql.AppendLine(", fecha_ult_dep");
                sql.AppendLine(", cod_semestre");
                sql.AppendLine(", usuario");
                sql.AppendLine(", operacion");
                sql.AppendLine(", fecha_modificacion");
                sql.AppendLine(", publica");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@anio");
                sql.AppendLine(", @cod_tipo_liq");
                sql.AppendLine(", @nro_liquidacion");
                sql.AppendLine(", @fecha_alta_registro");
                sql.AppendLine(", @aguinaldo");
                sql.AppendLine(", @des_liquidacion");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @fecha_liquidacion");
                sql.AppendLine(", @fecha_pago");
                sql.AppendLine(", @per_ult_dep");
                sql.AppendLine(", @cod_banco_ult_dep");
                sql.AppendLine(", @fecha_ult_dep");
                sql.AppendLine(", @cod_semestre");
                sql.AppendLine(", @usuario");
                sql.AppendLine(", @operacion");
                sql.AppendLine(", @fecha_modificacion");
                sql.AppendLine(", @publica");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", obj.cod_tipo_liq);
                    cmd.Parameters.AddWithValue("@nro_liquidacion", obj.nro_liquidacion);
                    cmd.Parameters.AddWithValue("@fecha_alta_registro", obj.fecha_alta_registro);
                    cmd.Parameters.AddWithValue("@aguinaldo", obj.aguinaldo);
                    cmd.Parameters.AddWithValue("@des_liquidacion", obj.des_liquidacion);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@fecha_liquidacion", obj.fecha_liquidacion);
                    cmd.Parameters.AddWithValue("@fecha_pago", obj.fecha_pago);
                    cmd.Parameters.AddWithValue("@per_ult_dep", obj.per_ult_dep);
                    cmd.Parameters.AddWithValue("@cod_banco_ult_dep", obj.cod_banco_ult_dep);
                    cmd.Parameters.AddWithValue("@fecha_ult_dep", obj.fecha_ult_dep);
                    cmd.Parameters.AddWithValue("@cod_semestre", obj.cod_semestre);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@operacion", obj.operacion);
                    cmd.Parameters.AddWithValue("@fecha_modificacion", obj.fecha_modificacion);
                    cmd.Parameters.AddWithValue("@publica", obj.publica);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(LIQUIDACIONES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LIQUIDACIONES SET");
                sql.AppendLine("fecha_alta_registro=@fecha_alta_registro");
                sql.AppendLine(", aguinaldo=@aguinaldo");
                sql.AppendLine(", des_liquidacion=@des_liquidacion");
                sql.AppendLine(", periodo=@periodo");
                sql.AppendLine(", fecha_liquidacion=@fecha_liquidacion");
                sql.AppendLine(", fecha_pago=@fecha_pago");
                sql.AppendLine(", per_ult_dep=@per_ult_dep");
                sql.AppendLine(", cod_banco_ult_dep=@cod_banco_ult_dep");
                sql.AppendLine(", fecha_ult_dep=@fecha_ult_dep");
                sql.AppendLine(", cod_semestre=@cod_semestre");
                sql.AppendLine(", usuario=@usuario");
                sql.AppendLine(", operacion=@operacion");
                sql.AppendLine(", fecha_modificacion=@fecha_modificacion");
                sql.AppendLine(", publica=@publica");
                sql.AppendLine("WHERE");
                sql.AppendLine("anio=@anio");
                sql.AppendLine("AND cod_tipo_liq=@cod_tipo_liq");
                sql.AppendLine("AND nro_liquidacion=@nro_liquidacion");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", obj.cod_tipo_liq);
                    cmd.Parameters.AddWithValue("@nro_liquidacion", obj.nro_liquidacion);
                    cmd.Parameters.AddWithValue("@fecha_alta_registro", obj.fecha_alta_registro);
                    cmd.Parameters.AddWithValue("@aguinaldo", obj.aguinaldo);
                    cmd.Parameters.AddWithValue("@des_liquidacion", obj.des_liquidacion);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@fecha_liquidacion", obj.fecha_liquidacion);
                    cmd.Parameters.AddWithValue("@fecha_pago", obj.fecha_pago);
                    cmd.Parameters.AddWithValue("@per_ult_dep", obj.per_ult_dep);
                    cmd.Parameters.AddWithValue("@cod_banco_ult_dep", obj.cod_banco_ult_dep);
                    cmd.Parameters.AddWithValue("@fecha_ult_dep", obj.fecha_ult_dep);
                    cmd.Parameters.AddWithValue("@cod_semestre", obj.cod_semestre);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@operacion", obj.operacion);
                    cmd.Parameters.AddWithValue("@fecha_modificacion", obj.fecha_modificacion);
                    cmd.Parameters.AddWithValue("@publica", obj.publica);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(LIQUIDACIONES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  LIQUIDACIONES ");
                sql.AppendLine("WHERE");
                sql.AppendLine("anio=@anio");
                sql.AppendLine("AND cod_tipo_liq=@cod_tipo_liq");
                sql.AppendLine("AND nro_liquidacion=@nro_liquidacion");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", obj.cod_tipo_liq);
                    cmd.Parameters.AddWithValue("@nro_liquidacion", obj.nro_liquidacion);
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

