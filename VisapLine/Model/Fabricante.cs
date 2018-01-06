﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisapLine.DataAccess.Data;
using VisapLine.DataAccess.Connection;
using System.Data;

namespace VisapLine.Model
{
    public class Fabricante
    {
        IData data = new Data();
        public string idfabricante { get; set; }
        public string fabricante { get; set; }

        public bool RegistrarFabricante(Fabricante fb)
        {
            return data.OperarDatos("");
        }
        public DataTable ConsultarFabricante()
        {
            return data.ConsultarDatos("");
        }
    }
}