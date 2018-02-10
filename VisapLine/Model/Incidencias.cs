﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisapLine.DataAccess.Data;
using VisapLine.DataAccess.Connection;
using System.Data;

namespace VisapLine.Model
{
    public class Incidencias
    {
        IData data = new Data();
        public string idincidencias { get; set; }
        public string fechainicio { get; set; }
        public string fechafin { get; set; }
        public string estado{ get; set; }
        public string costo { get; set; }
        public string detalle { get; set; }

        public string terceros_idterceros { get; set; }

        public string servicios_idservicios { get; set; }
      
       public string observacion { get; set; }

        public string descuento { get; set; }
        public string tipoincidencia_idtipoincidencia { get; set; }
        public DataTable ConsultarIncidencias(Incidencias ins)
        {
            return data.ConsultarDatos("");
        }

        public bool RegistrarInsidencias(Incidencias inci)
        {
            return data.OperarDatos("select * from public.pr_insertarincedencia('"+inci.estado+"','"+inci.detalle+"','"+inci.terceros_idterceros+"','"+inci.servicios_idservicios+"','"+inci.tipoincidencia_idtipoincidencia+"')");
        }

        public bool updatesolucionincidencia()
        {
            return data.OperarDatos("select * from public.pr_insertarincedencia()");

        }
    }
}