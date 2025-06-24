using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class LICENCIA_DETALLE_EMPLEADOS : DALBase
    {
        public int legajo { get; set; }
        public int cod_tipo_licencia { get; set; }
        public int anio_licencia { get; set; }
        public int nro_movimiento { get; set; }
        public DateTime fecha_movimiento { get; set; }
        public string usuario_alta { get; set; }
        public int dias_tomados { get; set; }
        public DateTime fecha_ultimo_dia_trabajado { get; set; }
        public DateTime fecha_inicio_licencia { get; set; }
        public DateTime fecha_fin_lincencia { get; set; }
        public DateTime fecha_regreso { get; set; }

        public LICENCIA_DETALLE_EMPLEADOS()
        {
            legajo = 0;
            cod_tipo_licencia = 0;
            anio_licencia = 0;
            nro_movimiento = 0;
            fecha_movimiento = DateTime.Now;
            usuario_alta = string.Empty;
            dias_tomados = 0;
            fecha_ultimo_dia_trabajado = DateTime.Now;
            fecha_inicio_licencia = DateTime.Now;
            fecha_fin_lincencia = DateTime.Now;
            fecha_regreso = DateTime.Now;
        }

        private static List<LICENCIA_DETALLE_EMPLEADOS> mapeo(SqlDataReader dr)
        {
            List<LICENCIA_DETALLE_EMPLEADOS> lst = new List<LICENCIA_DETALLE_EMPLEADOS>();
            LICENCIA_DETALLE_EMPLEADOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new LICENCIA_DETALLE_EMPLEADOS();
                    if (!dr.IsDBNull(0)) { obj.legajo = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.cod_tipo_licencia = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.anio_licencia = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.nro_movimiento = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.fecha_movimiento = dr.GetDateTime(4); }
                    if (!dr.IsDBNull(5)) { obj.usuario_alta = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.dias_tomados = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.fecha_ultimo_dia_trabajado = dr.GetDateTime(7); }
                    if (!dr.IsDBNull(8)) { obj.fecha_inicio_licencia = dr.GetDateTime(8); }
                    if (!dr.IsDBNull(9)) { obj.fecha_fin_lincencia = dr.GetDateTime(9); }
                    if (!dr.IsDBNull(10)) { obj.fecha_regreso = dr.GetDateTime(10); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<LICENCIA_DETALLE_EMPLEADOS> read()
        {
            try
            {
                List<LICENCIA_DETALLE_EMPLEADOS> lst = new List<LICENCIA_DETALLE_EMPLEADOS>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM LICENCIA_DETALLE_EMPLEADOS";
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

        public static LICENCIA_DETALLE_EMPLEADOS getByPk(
        int legajo, int cod_tipo_licencia, int anio_licencia, int nro_movimiento)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM LICENCIA_DETALLE_EMPLEADOS WHERE");
                sql.AppendLine("legajo = @legajo");
                sql.AppendLine("AND cod_tipo_licencia = @cod_tipo_licencia");
                sql.AppendLine("AND anio_licencia = @anio_licencia");
                sql.AppendLine("AND nro_movimiento = @nro_movimiento");
                LICENCIA_DETALLE_EMPLEADOS obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@anio_licencia", anio_licencia);
                    cmd.Parameters.AddWithValue("@nro_movimiento", nro_movimiento);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<LICENCIA_DETALLE_EMPLEADOS> lst = mapeo(dr);
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

        public static int insert(LICENCIA_DETALLE_EMPLEADOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO LICENCIA_DETALLE_EMPLEADOS(");
                sql.AppendLine("legajo");
                sql.AppendLine(", cod_tipo_licencia");
                sql.AppendLine(", anio_licencia");
                sql.AppendLine(", nro_movimiento");
                sql.AppendLine(", fecha_movimiento");
                sql.AppendLine(", usuario_alta");
                sql.AppendLine(", dias_tomados");
                sql.AppendLine(", fecha_ultimo_dia_trabajado");
                sql.AppendLine(", fecha_inicio_licencia");
                sql.AppendLine(", fecha_fin_lincencia");
                sql.AppendLine(", fecha_regreso");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@legajo");
                sql.AppendLine(", @cod_tipo_licencia");
                sql.AppendLine(", @anio_licencia");
                sql.AppendLine(", @nro_movimiento");
                sql.AppendLine(", @fecha_movimiento");
                sql.AppendLine(", @usuario_alta");
                sql.AppendLine(", @dias_tomados");
                sql.AppendLine(", @fecha_ultimo_dia_trabajado");
                sql.AppendLine(", @fecha_inicio_licencia");
                sql.AppendLine(", @fecha_fin_lincencia");
                sql.AppendLine(", @fecha_regreso");
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
                    cmd.Parameters.AddWithValue("@nro_movimiento", obj.nro_movimiento);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@usuario_alta", obj.usuario_alta);
                    cmd.Parameters.AddWithValue("@dias_tomados", obj.dias_tomados);
                    cmd.Parameters.AddWithValue("@fecha_ultimo_dia_trabajado", obj.fecha_ultimo_dia_trabajado);
                    cmd.Parameters.AddWithValue("@fecha_inicio_licencia", obj.fecha_inicio_licencia);
                    cmd.Parameters.AddWithValue("@fecha_fin_lincencia", obj.fecha_fin_lincencia);
                    cmd.Parameters.AddWithValue("@fecha_regreso", obj.fecha_regreso);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(LICENCIA_DETALLE_EMPLEADOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LICENCIA_DETALLE_EMPLEADOS SET");
                sql.AppendLine("fecha_movimiento=@fecha_movimiento");
                sql.AppendLine(", usuario_alta=@usuario_alta");
                sql.AppendLine(", dias_tomados=@dias_tomados");
                sql.AppendLine(", fecha_ultimo_dia_trabajado=@fecha_ultimo_dia_trabajado");
                sql.AppendLine(", fecha_inicio_licencia=@fecha_inicio_licencia");
                sql.AppendLine(", fecha_fin_lincencia=@fecha_fin_lincencia");
                sql.AppendLine(", fecha_regreso=@fecha_regreso");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND cod_tipo_licencia=@cod_tipo_licencia");
                sql.AppendLine("AND anio_licencia=@anio_licencia");
                sql.AppendLine("AND nro_movimiento=@nro_movimiento");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", obj.cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@anio_licencia", obj.anio_licencia);
                    cmd.Parameters.AddWithValue("@nro_movimiento", obj.nro_movimiento);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", obj.fecha_movimiento);
                    cmd.Parameters.AddWithValue("@usuario_alta", obj.usuario_alta);
                    cmd.Parameters.AddWithValue("@dias_tomados", obj.dias_tomados);
                    cmd.Parameters.AddWithValue("@fecha_ultimo_dia_trabajado", obj.fecha_ultimo_dia_trabajado);
                    cmd.Parameters.AddWithValue("@fecha_inicio_licencia", obj.fecha_inicio_licencia);
                    cmd.Parameters.AddWithValue("@fecha_fin_lincencia", obj.fecha_fin_lincencia);
                    cmd.Parameters.AddWithValue("@fecha_regreso", obj.fecha_regreso);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(LICENCIA_DETALLE_EMPLEADOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  LICENCIA_DETALLE_EMPLEADOS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("legajo=@legajo");
                sql.AppendLine("AND cod_tipo_licencia=@cod_tipo_licencia");
                sql.AppendLine("AND anio_licencia=@anio_licencia");
                sql.AppendLine("AND nro_movimiento=@nro_movimiento");
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@cod_tipo_licencia", obj.cod_tipo_licencia);
                    cmd.Parameters.AddWithValue("@anio_licencia", obj.anio_licencia);
                    cmd.Parameters.AddWithValue("@nro_movimiento", obj.nro_movimiento);
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

