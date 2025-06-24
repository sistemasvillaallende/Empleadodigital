using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class DET_LIQ_X_EMPLEADO : DALBase
    {
        public int anio { get; set; }
        public int cod_tipo_liq { get; set; }
        public int nro_liquidacion { get; set; }
        public int legajo { get; set; }
        public int cod_concepto_liq { get; set; }
        public int nro_orden { get; set; }
        public DateTime fecha_alta_registro { get; set; }
        public decimal importe { get; set; }
        public decimal unidades { get; set; }
        public string des_concepto_liq { get; set; }

        public DET_LIQ_X_EMPLEADO()
        {
            anio = 0;
            cod_tipo_liq = 0;
            nro_liquidacion = 0;
            legajo = 0;
            cod_concepto_liq = 0;
            nro_orden = 0;
            fecha_alta_registro = DateTime.Now;
            importe = 0;
            unidades = 0;
            des_concepto_liq = string.Empty;
        }

        private static List<DET_LIQ_X_EMPLEADO> mapeo(SqlDataReader dr, bool desc)
        {
            List<DET_LIQ_X_EMPLEADO> lst = new List<DET_LIQ_X_EMPLEADO>();
            DET_LIQ_X_EMPLEADO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new DET_LIQ_X_EMPLEADO();
                    if (!dr.IsDBNull(0)) { obj.anio = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.cod_tipo_liq = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.nro_liquidacion = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.legajo = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.cod_concepto_liq = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.nro_orden = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.fecha_alta_registro = dr.GetDateTime(6); }
                    if (!dr.IsDBNull(7)) { obj.importe = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.unidades = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.des_concepto_liq = dr.GetString(9); }
                    if (desc)

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<DET_LIQ_X_EMPLEADO> read()
        {
            try
            {
                List<DET_LIQ_X_EMPLEADO> lst = new List<DET_LIQ_X_EMPLEADO>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM DET_LIQ_X_EMPLEADO";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr, false);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DET_LIQ_X_EMPLEADO> read(int legajo, int anio, int nroLiquidacion)
        {
            try
            {
                List<DET_LIQ_X_EMPLEADO> lst = new List<DET_LIQ_X_EMPLEADO>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.des_concepto_liq FROM  DET_LIQ_X_EMPLEADO A");
                sql.AppendLine("INNER JOIN CONCEPTOS_LIQUIDACION B ON A.cod_concepto_liq = B.cod_concepto_liq");
                sql.AppendLine("WHERE anio = @anio AND nro_liquidacion = @nro_liquidacion");
                sql.AppendLine("AND legajo = @legajo");

                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@nro_liquidacion", nroLiquidacion);
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr, true);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DET_LIQ_X_EMPLEADO getByPk(
        int anio, int cod_tipo_liq, int nro_liquidacion, int legajo, int cod_concepto_liq)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM DET_LIQ_X_EMPLEADO WHERE");
                sql.AppendLine("anio = @anio");
                sql.AppendLine("AND cod_tipo_liq = @cod_tipo_liq");
                sql.AppendLine("AND nro_liquidacion = @nro_liquidacion");
                sql.AppendLine("AND legajo = @legajo");
                sql.AppendLine("AND cod_concepto_liq = @cod_concepto_liq");
                DET_LIQ_X_EMPLEADO obj = null;
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", cod_tipo_liq);
                    cmd.Parameters.AddWithValue("@nro_liquidacion", nro_liquidacion);
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Parameters.AddWithValue("@cod_concepto_liq", cod_concepto_liq);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<DET_LIQ_X_EMPLEADO> lst = mapeo(dr, false);
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

