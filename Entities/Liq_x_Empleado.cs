using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Liq_x_Empleado
    {
        public int anio { get; set; }
        public int cod_tipo_liq { get; set; }
        public int nro_liquidacion { get; set; }
        public int legajo { get; set; }
        public int nro_orden { get; set; }
        public string fecha_alta_registro { get; set; }
        public decimal sueldo_neto { get; set; }


        public Liq_x_Empleado()
        {
            anio = 0;
            cod_tipo_liq = 0;
            nro_liquidacion = 0;
            legajo = 0;
            fecha_alta_registro = DateTime.Today.ToString("dd/MM/yyyy");
            sueldo_neto = 0;
            nro_orden = 0;
        }

    }
}
