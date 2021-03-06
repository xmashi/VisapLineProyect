﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisapLine.DataAccess.Data;
using VisapLine.DataAccess.Connection;
using System.Data;

namespace VisapLine.Model
{
    public class Terceros
    {
        IData data = new Data();
        public string idterceros { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string estrato { get; set; }
        public string estado { get; set; }
        public string tipotercero_idtipotercero { get; set; }
        public string tipodoc_idtipodoc { get; set; }
        public string fechanatcimiento { get; set; }
        public string tiporesidencia_idtiporesidencia { get; set; }
        public string tipofactura_idtipofactura { get; set; }
        public string barrios_idbarrios { get; set; }
        public string usuario_idusuario { get; set; }
        public string rh { get; set; }
        public string telefono { get; set; }


        public DataTable ConsultarTercerosId(Terceros terc)
        {
            return data.ConsultarDatos("SELECT * from public.pr_consultarterceroidapk("+terc.idterceros+");");
        }

        public DataTable ConsultarRecuperacion(Terceros ter)
        {
            return data.ConsultarDatos("select * from pr_consultarrecuperacion('"+ter.identificacion+"', '"+ter.correo+"');");
        }

        public DataTable ConsultarTerceroCargos(Terceros terc)
        {
            return data.ConsultarDatos("select * from pr_consultarcargotercero('"+terc.identificacion+"')");
        }

        public bool RegistrarTerceros(Terceros per)
        {
            return data.OperarDatos("SELECT * from public.pr_insertartercerocliente('" + per.estrato + "','" + per.estado + "','" + per.tiporesidencia_idtiporesidencia + "','" + per.tipofactura_idtipofactura + "','" + per.identificacion + "','"+per.nombre + "','"+per.apellido+"','" + per.correo+ "','" + per.direccion + "','" + per.barrios_idbarrios + "','" + per.fechanatcimiento + "','" + per.tipodoc_idtipodoc+"');");
        }
        public bool RegistrarTercerosempresatercero(Terceros per)
        {
            return data.OperarDatos("SELECT * from public.pr_insertarterceroempresacliente('" + per.estrato + "','" + per.estado + "','" + per.tiporesidencia_idtiporesidencia + "','" + per.tipofactura_idtipofactura + "','" + per.identificacion + "','" + per.nombre + "','" + per.correo + "','" + per.direccion + "','" + per.barrios_idbarrios + "','" + per.fechanatcimiento + "','" + per.tipodoc_idtipodoc + "');");
        }
        public DataTable ConsultarPersonaIdentifall(Terceros ter)
        {
            return data.ConsultarDatos("SELECT * from pr_consultarterceroidall('"+ter.identificacion+"');");
        }

        public DataTable Consultartercero()
        {
            return data.ConsultarDatos("SELECT * from terceros; ");
        }

        public DataTable ConsultarPersonaIdenti(string teriden)
        {
            return data.ConsultarDatos("SELECT * from pr_consultarterceroidall('" + teriden + "');");
        }
        public bool ActualizarTercero(Terceros ter)
        {
            return data.OperarDatos("select * from pr_actualizartercero('"+ter.idterceros+"',"+ter.estrato+",'"+ter.estado+"',"+ter.tiporesidencia_idtiporesidencia+ "," + ter.tipofactura_idtipofactura + ",'" + ter.identificacion+"','"+ter.nombre+"',"+ter.apellido+ "," + ter.correo + "," + ter.direccion+ ",'" + ter.barrios_idbarrios + "',"+ter.fechanatcimiento+ ",'" + ter.tipodoc_idtipodoc + "',"+ter.rh+"); ");
            
        }

        public bool RegitrarTerceros2(Terceros per)
        {
            return data.OperarDatos("SELECT * from public.pr_insertartercero('"+per.identificacion+"','"+per.estrato+"','"+per.estado+"','"+per.tipotercero_idtipotercero+"','"+per.tiporesidencia_idtiporesidencia+"','"+per.tipofactura_idtipofactura+"');");
        }
        public bool RegistrarTerceroGeneral(Terceros ter)
        {
            return data.OperarDatos("select * from pr_insertartercero("+ter.estrato+", '"+ter.estado+"',"+ter.tiporesidencia_idtiporesidencia+","+ter.tipofactura_idtipofactura+",'"+ter.identificacion+"','"+ter.nombre+"',"+ter.apellido+",'"+ter.correo+"','"+ter.direccion+"',"+ter.barrios_idbarrios+","+ter.fechanatcimiento+","+ter.tipodoc_idtipodoc+","+ter.rh+")");
        }

        public DataTable ConsultarTerceroDos(Terceros ter)
        {
            return data.ConsultarDatos("select * from pr_consultartercerodos('"+identificacion+"')");
        }

        public DataTable ConsultarTerceroAvanzado(Terceros ter)
        {
            return data.ConsultarDatos("select * from pr_consultarterceroavanzado('" + identificacion.ToUpper() + "')");
        }
        public bool RegitrarTerceroegreso(Terceros per)
        {
            return data.OperarDatos("SELECT * from public.pr_insertarterceroegreso('"+per.tipotercero_idtipotercero+"','"+per.tipodoc_idtipodoc+"','"+per.identificacion+"','"+per.nombre+"','"+per.correo+"','"+per.telefono+"');");
        }

    }
}