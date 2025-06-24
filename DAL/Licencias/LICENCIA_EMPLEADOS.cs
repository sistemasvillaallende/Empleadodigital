using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class LICENCIA_EMPLEADOS : DALBase
    {
        public int legajo { get; set; }
        public int cod_tipo_licencia { get; set; }
        public int anio_licencia { get; set; }
        public DateTime fecha_movimiento { get; set; }
        public int cantidad_dias { get; set; }
        public int dias_tomados { get; set; }
        public int saldo { get; set; }
        public string usuario_alta { get; set; }
        public string usuario_modifica { get; set; }

        public LICENCIA_EMPLEADOS()
        {
            legajo = 0;
            cod_tipo_licencia = 0;
            anio_licencia = 0;
            fecha_movimiento = DateTime.Now;
            cantidad_dias = 0;
            dias_tomados = 0;
            saldo = 0;
            usuario_alta = string.Empty;
            usuario_modifica = string.Empty;
        }

        private static List<LICENCIA_EMPLEADOS> mapeo(SqlDataReader dr)
        {
            List<LICENCIA_EMPLEADOS> lst = new List<LICENCIA_EMPLEADOS>();
            LICENCIA_EMPLEADOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new LICENCIA_EMPLEADOS();
                    if (!dr.IsDBNull(0)) { obj.legajo = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.cod_tipo_licencia = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.anio_licencia = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.fecha_movimiento = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.cantidad_dias = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.dias_tomados = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.saldo = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.usuario_alta = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.usuario_modifica = dr.GetString(8); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<LICENCIA_EMPLEADOS> read()
        {
            try
            {
                List<LICENCIA_EMPLEADOS> lst = new List<LICENCIA_EMPLEADOS>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM LICENCIA_EMPLEADOS";
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

        public static LICENCIA_EMPLEADOS getByPk(
        int legajo, int cod_tipo_licencia, int anio_licencia)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM LICENCIA_EMPLEADOS WHERE");
                sql.AppendLine("legajo = @legajo");
                sql.AppendLine("AND cod_tipo_licencia = @cod_tipo_licencia");
                sql.AppendLine("AND anio_licencia = @anio_licencia");
                LICENCIA_EMPLEADOS obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@anio_licencia", anio_licencia);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<LICENCIA_EMPLEADOS> lst = mapeo(dr);
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

        public static int insert(LICENCIA_EMPLEADOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO LICENCIA_EMPLEADOS(");
                sql.AppendLine("legajo");
                sql.AppendLine(", cod_tipo_licencia");
                sql.AppendLine(", anio_licencia");
                sql.AppendLine(", fecha_movimiento");
                sql.AppendLine(", cantidad_dias");
                sql.AppendLine(", dias_tomados");
                sql.AppendLine(", saldo");
                sql.AppendLine(", usuario_alta");
                sql.AppendLine(", usuario_modifica");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@legajo");
                sql.AppendLine(", @cod_tipo_licencia");
                sql.AppendLine(", @anio_licencia");
                sql.AppendLine(", @fecha_movimiento");
                sql.AppendLine(", @cantidad_dias");
                sql.AppendLine(", @dias_tomados");
                sql.AppendLine(", @saldo");
                sql.AppendLine(", @usuario_alta");
                sql.AppendLine(", @usuario_modifica");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", obj.cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@anio_licencia", obj.anio_licencia);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@cantidad_dias", obj.cantidad_dias);
                    cmd.Parameters.AddWithValue("@dias_tomados", obj.dias_tomados);
                    cmd.Parameters.AddWithValue("@saldo", obj.saldo);
                    cmd.Parameters.AddWithValue("@usuario_alta", obj.usuario_alta);
                    cmd.Parameters.AddWithValue("@usuario_modifica", obj.usuario_modifica);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(LICENCIA_EMPLEADOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LICENCIA_EMPLEADOS SET");
                sql.AppendLine("fecha_movimiento=@fecha_movimiento");
                sql.AppendLine(", cantidad_dias=@cantidad_dias");
                sql.AppendLine(", dias_tomados=@dias_tomados");
                sql.AppendLine(", saldo=@saldo");
                sql.AppendLine(", usuario_alta=@usuario_alta");
                sql.AppendLine(", usuario_modifica=@usuario_modifica");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND cod_tipo_licencia=@cod_tipo_licencia");
                sql.AppendLine("AND anio_licencia=@anio_licencia");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", obj.cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@anio_licencia", obj.anio_licencia);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@cantidad_dias", obj.cantidad_dias);
                    cmd.Parameters.AddWithValue("@dias_tomados", obj.dias_tomados);
                    cmd.Parameters.AddWithValue("@saldo", obj.saldo);
                    cmd.Parameters.AddWithValue("@usuario_alta", obj.usuario_alta);
                    cmd.Parameters.AddWithValue("@usuario_modifica", obj.usuario_modifica);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(LICENCIA_EMPLEADOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  LICENCIA_EMPLEADOS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND cod_tipo_licencia=@cod_tipo_licencia");
                sql.AppendLine("AND anio_licencia=@anio_licencia");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", obj.cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@anio_licencia", obj.anio_licencia);
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

