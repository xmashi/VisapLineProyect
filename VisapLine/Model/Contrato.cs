﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisapLine.DataAccess.Data;
using VisapLine.DataAccess.Connection;
using System.Data;

namespace VisapLine.Model
{
    public class Contrato
    {
        IData data = new Data();
        public string idcontrato { get; set; }
        public string terceros_idterceros { get; set; }
        public string codigo { get; set; }
        public string fechacontrato { get; set; }
        public string fechaactivacion { get; set; }
        public string fechafacturacion { get; set; }
        public string estado { get; set; }
        public string tipocontrato_idtipocontrato { get; set; }
        public string plan_idplan { get; set; }
        public string iva { get; set; }
        public string correo { get; set; }
        public string enviofactura { get; set; }
        public string facturaunica { get; set; }
        public string personal_idpersonal { get; set; }

        public DataTable ConsultarContratoIdTercero(Contrato bar)
        {
            return data.ConsultarDatos("");
        }

        public bool RegistrarContrato(Contrato cont)
        {
            return data.OperarDatos("");
        }
    }
}