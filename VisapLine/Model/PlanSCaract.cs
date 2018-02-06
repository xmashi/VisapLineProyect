﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisapLine.DataAccess.Data;
using VisapLine.DataAccess.Connection;
using System.Data;

namespace VisapLine.Model
{
    public class PlanSCaract
    {
        IData data = new Data();
        public string idplanscaract { get; set; }
        public string planservicio_idplanservicio { get; set; }
        public string caracteristicas_idcaracteristicas { get; set; }
        public string cantidad { get; set; }
        public string servicios_idservicios { get; set; }
        public string ordensalida_idordensalida { get; set; }

        public DataTable ConsultarPlanSCatact(int bar)
        {
            return data.ConsultarDatos("select * from pr_consultarcaracteristicasdetallerorder("+ bar + ")");
        }

        public bool RegistrarPlanSCatact(int servicios_idservicios, int caracteristicas_idcaracteristicas, int cantidad)
        {
            return data.OperarDatos("SELECT * from public.pr_insertarplanserhascarac("+ servicios_idservicios + ","+ caracteristicas_idcaracteristicas + ","+ cantidad + ")");
        }
        public bool registrarpuertos(int servicios_idservicios, int cantidad)
        {
            return data.OperarDatos("select * from pr_insertarpuntosalservicio("+ servicios_idservicios + ","+ cantidad + ")");
        }
        public DataTable ConsultarEquiposParaintalar() {
            return data.ConsultarDatos("select idinventario,serial,mac,modelo,fabricante,tipoproducto,wifi from inventario inner join tipoproducto on tipoproducto_idtipoproducto = tipoproducto.idtipoproducto inner join modelo on modelo_idmodelo=modelo.idmodelo inner join fabricante on fabricante_idfabricante = fabricante.idfabricante where estado = 'DISPONIBLE'; ");
        }

    }
}