﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class LstEmpleados
  {
  
    public int legajo { get; set; }
    public string nombre { get; set; }
    public string fecha_ingreso { get; set; }
    public string fecha_nacimiento { get; set; }
    public int cod_categoria { get; set; }
    public string des_categoria { get; set; }
    public string tarea { get; set; }
    public string des_tipo_liq { get; set; }
    public string nom_banco { get; set; }
    public string nro_caja_ahorro { get; set; }
    public string nro_cbu { get; set; }
    public string nro_documento { get; set; }
    public string nro_cta_sb { get; set; }
    public string nro_cta_gastos { get; set; }
    public string secrectaria { get; set; }
    public string direccion { get; set; }
    public string oficina { get; set; }
    public int antiguedad_ant { get; set; }
    public decimal sueldo_basico { get; set; }

    
    public LstEmpleados()
    {
      legajo = 0 ;
      nombre = "";
      fecha_ingreso = "";
      fecha_nacimiento = "";
      cod_categoria = 0;
      des_categoria = "";
      tarea = "";
      des_tipo_liq = "";
      nom_banco = "";
      nro_caja_ahorro = "";
      nro_cbu= "";
      nro_documento = "";
      nro_cta_sb = "";
      nro_cta_gastos = "";
      secrectaria = "";
      direccion = "";
      oficina = "";
      antiguedad_ant = 0;
      sueldo_basico = 0;
    }



  }
}
