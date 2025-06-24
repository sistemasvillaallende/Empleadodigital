using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class AUX_MAESTRO_SUELDO : DALBase
    {
        public int legajo { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string des_tipo_documento { get; set; }
        public string nro_documento { get; set; }
        public int cod_seccion { get; set; }
        public int cod_categoria { get; set; }
        public string tarea { get; set; }
        public string des_liquidacion { get; set; }
        public DateTime fecha_liquidacion { get; set; }
        public string per_ult_dep { get; set; }
        public string cuil { get; set; }
        public int anio { get; set; }
        public int cod_tipo_liq { get; set; }
        public int nro_liquidacion { get; set; }
        public DateTime fecha_pago { get; set; }
        public decimal sueldo_basico { get; set; }
        public decimal importe_total { get; set; }
        public string clasificacion_personal { get; set; }
        public int nro_orden { get; set; }
        public List<Entities.AUX_DETALLE_SUELDO> lstDetalle { get; set; }

        public AUX_MAESTRO_SUELDO()
        {
            legajo = 0;
            nombre = string.Empty;
            fecha_ingreso = DateTime.Now;
            des_tipo_documento = string.Empty;
            nro_documento = string.Empty;
            cod_seccion = 0;
            cod_categoria = 0;
            tarea = string.Empty;
            des_liquidacion = string.Empty;
            fecha_liquidacion = DateTime.Now;
            per_ult_dep = string.Empty;
            cuil = string.Empty;
            anio = 0;
            cod_tipo_liq = 0;
            nro_liquidacion = 0;
            fecha_pago = DateTime.Now;
            sueldo_basico = 0;
            importe_total = 0;
            clasificacion_personal = string.Empty;
            nro_orden = 0;
        }

        private static List<Entities.AUX_MAESTRO_SUELDO> mapeo(SqlDataReader dr)
        {
            List<Entities.AUX_MAESTRO_SUELDO> lst = new List<Entities.AUX_MAESTRO_SUELDO>();
            Entities.AUX_MAESTRO_SUELDO obj;
            int legajo = dr.GetOrdinal("legajo");
            int nombre = dr.GetOrdinal("nombre");
            int fecha_ingreso = dr.GetOrdinal("fecha_ingreso");
            int des_tipo_documento = dr.GetOrdinal("des_tipo_documento");
            int nro_documento = dr.GetOrdinal("nro_documento");
            int cod_seccion = dr.GetOrdinal("cod_seccion");
            int cod_categoria = dr.GetOrdinal("cod_categoria");
            int tarea = dr.GetOrdinal("tarea");
            int des_liquidacion = dr.GetOrdinal("des_liquidacion");
            int fecha_liquidacion = dr.GetOrdinal("fecha_liquidacion");
            int per_ult_dep = dr.GetOrdinal("per_ult_dep");

            int cuil = dr.GetOrdinal("cuil");
            int anio = dr.GetOrdinal("anio");
            int cod_tipo_liq = dr.GetOrdinal("cod_tipo_liq");
            int nro_liquidacion = dr.GetOrdinal("nro_liquidacion");
            int fecha_pago = dr.GetOrdinal("fecha_pago");
            int sueldo_basico = dr.GetOrdinal("sueldo_basico");
            int importe_total = dr.GetOrdinal("importe_total");

            int clasificacion_personal = dr.GetOrdinal("clasificacion_personal");
            int nro_orden = dr.GetOrdinal("nro_orden");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Entities.AUX_MAESTRO_SUELDO();
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(fecha_ingreso)) { obj.fecha_ingreso = dr.GetDateTime(fecha_ingreso); }
                    if (!dr.IsDBNull(des_tipo_documento)) { obj.des_tipo_documento = dr.GetString(des_tipo_documento); }
                    if (!dr.IsDBNull(nro_documento)) { obj.nro_documento = dr.GetString(nro_documento); }
                    if (!dr.IsDBNull(cod_seccion)) { obj.cod_seccion = dr.GetInt32(cod_seccion); }
                    if (!dr.IsDBNull(cod_categoria)) { obj.cod_categoria = dr.GetInt32(cod_categoria); }
                    if (!dr.IsDBNull(tarea)) { obj.tarea = dr.GetString(tarea); }
                    if (!dr.IsDBNull(des_liquidacion)) { obj.des_liquidacion = dr.GetString(des_liquidacion); }
                    if (!dr.IsDBNull(fecha_liquidacion)) { obj.fecha_liquidacion = dr.GetDateTime(fecha_liquidacion); }
                    if (!dr.IsDBNull(per_ult_dep)) { obj.per_ult_dep = dr.GetString(10); }
                    if (!dr.IsDBNull(cuil)) { obj.cuil = dr.GetString(cuil); }
                    if (!dr.IsDBNull(anio)) { obj.anio = dr.GetInt32(anio); }                    
                   
                    if (!dr.IsDBNull(cod_tipo_liq)) { obj.cod_tipo_liq = dr.GetInt32(cod_tipo_liq); }
                    if (!dr.IsDBNull(nro_liquidacion)) { obj.nro_liquidacion = dr.GetInt32(nro_liquidacion); }
                    if (!dr.IsDBNull(fecha_pago)) { obj.fecha_pago = dr.GetDateTime(fecha_pago); }
                    if (!dr.IsDBNull(sueldo_basico)) { obj.sueldo_basico = dr.GetDecimal(sueldo_basico); }
                    if (!dr.IsDBNull(importe_total)) { obj.importe_total = dr.GetDecimal(importe_total); }
                    if (!dr.IsDBNull(clasificacion_personal)) { obj.clasificacion_personal = dr.GetString(clasificacion_personal); }
                    if (!dr.IsDBNull(nro_orden)) { obj.nro_orden = dr.GetInt32(nro_orden); }
                    obj.lstDetalle = AUX_DETALLE_SUELDO.read(obj.anio, obj.cod_tipo_liq, obj.nro_liquidacion, obj.legajo);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Entities.AUX_MAESTRO_SUELDO> read(int desde, int hasta, int anio, int cod_tipo_liq, int nro_liq)
        {
            try
            {
                string sql =
                    @"SELECT 
                        e.legajo, e.nombre, e.fecha_ingreso,
                        t.des_tipo_documento, e.nro_documento, 
                        e.cod_seccion, l1.cod_categoria,
                        l1.tarea, l.des_liquidacion, l.fecha_liquidacion, 
                        per_ult_dep=l.per_ult_dep,
                        l.fecha_ult_dep,
                        e.cuil, l.anio, l.cod_tipo_liq, 
                        l.nro_liquidacion, l.fecha_pago,
                        l1.sueldo_basico, importe_total=l1.sueldo_neto, 
                        cp.des_clasif_per as clasificacion_personal,
                        l1.nro_orden 
                        FROM LIQUIDACIONES l WITH (NOLOCK)
                        JOIN LIQ_X_EMPLEADO l1 ON
                            l.anio=l1.anio AND
                            l.cod_tipo_liq=l1.cod_tipo_liq AND
                            l.nro_liquidacion=l1.nro_liquidacion
                        JOIN EMPLEADOS e ON
                            e.legajo>=@desde AND
                            e.legajo<=@hasta AND
                            e.legajo=l1.legajo
                        JOIN TIPOS_DOCUMENTOS t ON
                            e.cod_tipo_documento=t.cod_tipo_documento 
                            left JOIN CATEGORIAS c ON
                            l1.cod_categoria=c.cod_categoria
                        left JOIN det_liq_x_empleado d on
                            d.cod_concepto_liq=10 AND
                            d.anio=l.anio AND
                            d.cod_tipo_liq=l.cod_tipo_liq AND
                            d.nro_liquidacion=l.nro_liquidacion AND
                            d.legajo=e.legajo
                        left JOIN CLASIFICACIONES_PERSONAL cp ON
                            cp.cod_clasif_per=l1.cod_clasif_per
                    WHERE
                        l.anio=@anio AND
                        l.cod_tipo_liq=@cod_tipo_liq AND
                        l.nro_liquidacion=@nro_liq
                    ORDER BY e.legajo";

                List<Entities.AUX_MAESTRO_SUELDO> lst = new List<Entities.AUX_MAESTRO_SUELDO>();
                using (SqlConnection con = GetConnection("SIIMVA"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@cod_tipo_liq", cod_tipo_liq);
                    cmd.Parameters.AddWithValue("@nro_liq", nro_liq);
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
    }
}

