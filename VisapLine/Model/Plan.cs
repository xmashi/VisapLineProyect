﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisapLine.DataAccess.Data;
using VisapLine.DataAccess.Connection;
using System.Data;
namespace VisapLine.Model
{
    public class Plan
    {
        IData data = new Data();
        public string idplan { get; set; }
        public string valor { get; set; }
        public string detalle { get; set; }
        public string telefonia { get; set; }
        public string televicion { get; set; }
        public string internet { get; set; }
        public string estado { get; set; }
        public string tipoplan { get; set; }
        public string subida { get; set; }
        public string bajada { get; set; }




        public DataTable ConsultarPlan()
        {
            return data.ConsultarDatos("select * from pr_consultarpplan()");
        }


        public bool RegistrarPlan(Plan pln)
        {
            return data.OperarDatos("");
        }
    }


  


}