﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace VisapLine.Exeption
{
    public class Validar
    {
        public static DataRow Login(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0];
            }
            else
            {
                throw new ValidarExeption("Credenciales Invalidas");
            }
        }

        public static DataTable Consulta(DataTable data)
        {
            if (data != null && data.Rows.Count > 0)
            {
                return data;
            }
            else
            {
                throw new ValidarExeption("No se encontro ningun registro");
            }
        }
        public static string validarlleno(string dat)
        {
            if (dat != null && dat.Length > 0)
            {
                return dat;
            }
            else
            {
                throw new ValidarExeption("Campo vacio");
            }
        }

        public static string validarselected(string dat)
        {
            if (dat != "Seleccione")
            {
                return dat;
            }
            else
            {
                throw new ValidarExeption("Debe selecionar un elemento");
            }
        }

        public static string validarnumero(string dat)
        {
            long numero;
            try
            {
                numero = Convert.ToInt64(validarlleno(dat));
                return numero.ToString();
            }
            catch (FormatException)
            {
                throw new ValidarExeption("Esta ingresando letras en donde debe ir un numero");
            }
        }

        public static bool validartrue(bool check)
        {
            
                if (check)
                {
                    return true;
                }
                else
                {
                    throw new ValidarExeption("Debe seleccionar un plan de servicio");
                }
           
           
        }

    }
}