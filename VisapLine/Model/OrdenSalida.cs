﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisapLine.DataAccess.Data;
using VisapLine.DataAccess.Connection;
using System.Data;

namespace VisapLine.Model
{
    public class OrdenSalida
    {
        IData data = new Data();
        public string idordensalidacabe { get; set; }
        public string codigo { get; set; }
        public string detalle { get; set; }
        public string observacion { get; set; }
        public string personal_idpersonal_registra { get; set; }
        public string personal_idpersonal_atiende { get; set; }
        public string servicios_idservicios { get; set; }
        public DataTable Insertar(string detalle, string observacion, string tipoorden,int tercereg) {
            return data.ConsultarDatos("select * from pr_insertarordenldiff('"+ detalle + "','"+ observacion + "',"+ tercereg + ",'"+ tipoorden + "')");
        }
        public DataTable Consultarorden(string id) {
            return data.ConsultarDatos("select * from pr_consultarcrdenvista('"+ id + "')"); ;
        }
        public DataTable Consultarordentrab(string id)
        {
            return data.ConsultarDatos("select * from pr_consultarcrdenvistatrab('" + id + "')"); ;
        }
        public DataTable cosnutlarlefonosorden(string id) {
            return data.ConsultarDatos("select telefono from telefono where terceros_idterceros="+ id + "");
        }
        public DataTable Consultardetalleordesali(string id) {
            return data.ConsultarDatos("SELECT * from public.pr_consultardetalleordensa('"+ id + "');");
        }
        public DataTable consultarinventario(int tipoinv)
        {
            return data.ConsultarDatos("select * from pr_consultarinventariotipo("+ tipoinv + ")");
        }
 
    }
}