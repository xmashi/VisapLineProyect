﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisapLine.Model;
using System.Data;
using VisapLine.Exeption;
namespace VisapLine.View.Private
{
    public partial class Incidencia : System.Web.UI.Page
    {

        Servicios serv = new Servicios();
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {


            ScriptManager.RegisterStartupScript(this, this.GetType(), "hwa", "deletealert();", true);


        }


        protected void Buttonbuscarcodg_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dat = Validar.Consulta(serv.consultaservicioscont1(Validar.validarlleno(TextBox1.Text)));
                GridView1.DataSource = dat;
                GridView1.DataBind();
                divtablagestcontr.Visible = true;
            }
            catch (Exception ex)
            {
                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridw = GridView1.SelectedRow;
            idservicio.Text = gridw.Cells[1].Text;
            divincidencia.Visible = true;

        }
    }
}