﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisapLine.Model;
using VisapLine.Exeption;
using System.Data;

namespace VisapLine.View.Private
{
    public partial class Contratoterc : System.Web.UI.Page
    {

        Terceros terc = new Terceros();
        TipoTercero ttr = new TipoTercero();
        Pais pais = new Pais();
        Departamento depart = new Departamento();
        Municipio munic = new Municipio();
        Barrios barr = new Barrios();
        TipoFactura tpfact = new TipoFactura();
        TipoResidencia tpres = new TipoResidencia();
        TipoDoc tpdoc = new TipoDoc();
        Telefono tlf = new Telefono();
        CargoTercero ctg = new CargoTercero();
        static DataTable listtelefono = new DataTable();
        static DataTable listtelefonocorpo = new DataTable();
        static DataTable listtelefonoempre = new DataTable();
        static DataTable listsucursalcorpo = new DataTable();
        static DataTable listsucursalempre = new DataTable();
        Plan pn = new Plan();
        TipoContrato tpoc = new TipoContrato();
        Sucursal scsal = new Sucursal();
        Contrato contrat = new Contrato();
        string idplancontr;
        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "hwa", "deletealert();", true);

            try
            {
                if (!IsPostBack)
                {
                    
                    //CONTRATO

                    DropDownListpaiscontrato.DataSource = pais.ConsultarPais();
                    DropDownListpaiscontrato.DataTextField = "pais";
                    DropDownListpaiscontrato.DataValueField = "idpais";
                    DropDownListpaiscontrato.DataBind();

                    DropDownListtiporedenciacontrato.DataSource = tpres.ConsultarTipoResidencia();
                    DropDownListtiporedenciacontrato.DataTextField = "tiporesidencia";
                    DropDownListtiporedenciacontrato.DataValueField = "idtiporesidencia";
                    DropDownListtiporedenciacontrato.DataBind();

                    DropDownListtipocontrato.DataSource = tpoc.ConsultarTipoContrato();
                    DropDownListtipocontrato.DataTextField = "tipocontrato";
                    DropDownListtipocontrato.DataValueField = "idtipocontrato";
                    DropDownListtipocontrato.DataBind();

                }
            }
            catch (Exception ex)
            {
                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;
            }
        }


        
        
       

        ///contrato
        ///

        protected void cargartabla(string idusuario)
        {
            pn.idtercero_idtercero = terc.idterceros;
            DataTable dt = pn.ConsultarPlantipoterce(idusuario);
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        protected void cargartablasucursal(string idusuario)
        {
            scsal.terceros_idterceros = terc.idterceros;
            DropDownListsucursalcontrato.DataSource = scsal.Consultarsucursal(idusuario);
            DropDownListsucursalcontrato.DataTextField = "nombre";
            DropDownListsucursalcontrato.DataValueField = "idsucursal";
            DropDownListsucursalcontrato.DataBind();

        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);
            GridViewRow gridw = GridView2.SelectedRow;
            Labeldipalcontra.Text = gridw.Cells[1].Text;
            TextArea1detalleplan.Value = gridw.Cells[3].Text;
            Labelsubidaplancontrato.Text = gridw.Cells[7].Text;
            Labelbajadaplancontrato.Text = gridw.Cells[8].Text;
            Labelvaloriva.Text = gridw.Cells[2].Text;
            Labelmedioconexionplancontrato.Text = gridw.Cells[9].Text;
          
        }


        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }



        protected void DropDownListpaiscontrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownListdepartamentocontrato.Items.Clear();
                DropDownListdepartamentocontrato.Items.Add(new ListItem("Seleccione", "Seleccione"));
                depart.pais_idpais = Validar.validarselected(DropDownListpaiscontrato.SelectedValue);
                DropDownListdepartamentocontrato.DataSource = Validar.Consulta(depart.ConsultarDepartamentoIdPais(depart));
                DropDownListdepartamentocontrato.DataTextField = "departamento";
                DropDownListdepartamentocontrato.DataValueField = "iddepartamento";
                DropDownListdepartamentocontrato.DataBind();
                ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);
            }
            catch (Exception ex)
            {
                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);
            }
        }
        protected void DropDownListdepartamentocontrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownListmunicipiocontrato.Items.Clear();
                DropDownListmunicipiocontrato.Items.Add(new ListItem("Seleccione", "Seleccione"));
                munic.departamento_iddepartamento = Validar.validarselected(DropDownListdepartamentocontrato.SelectedValue);
                DropDownListmunicipiocontrato.DataSource = Validar.Consulta(munic.ConsultarMunicipioIdDepartamento(munic));
                DropDownListmunicipiocontrato.DataTextField = "municipio";
                DropDownListmunicipiocontrato.DataValueField = "idmunicipio";
                DropDownListmunicipiocontrato.DataBind();

                ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);

            }
            catch (Exception ex)
            {
                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);

            }


        }
        protected void DropDownListmunicipiocontrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownListbarriocontrato.Items.Clear();
                DropDownListbarriocontrato.Items.Add(new ListItem("Seleccione", "Seleccione"));
                barr.muninicio_idmunicipio = Validar.validarselected(DropDownListmunicipiocontrato.SelectedValue);
                DropDownListbarriocontrato.DataSource = Validar.Consulta(barr.ConsultarBarriosIdMunicipio(barr));
                DropDownListbarriocontrato.DataTextField = "barrios";
                DropDownListbarriocontrato.DataValueField = "idbarrios";
                DropDownListbarriocontrato.DataBind();

       
                ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);
            }
            catch (Exception ex)
            {
                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);
            }
        }

        protected void DropDownListestratocontrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListestratocontrato.Text == "1" || DropDownListestratocontrato.Text == "2" || DropDownListestratocontrato.Text == "3")
            {
                TextBoxivacontrato.Text = "0";
                ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);
            }
            else
            {
                if (DropDownListestratocontrato.Text == "4" || DropDownListestratocontrato.Text == "5" || DropDownListestratocontrato.Text == "6")
                {
                    TextBoxivacontrato.Text = "0.19";
                    ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);
                }

            }


        }

        protected void GridViewsucursalcontrato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListsucursalcontrato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Buttonguardarcontrato_Click(object sender, EventArgs e)
        {
            try
            {

                int sesion = 90;
                string dni = "";
                if (Labelcedulacontrato.Text !="")
                {
                    dni = Labelcedulacontrato.Text;
                }
                else
                {
                    if (Label11.Text!="")
                    {
                        dni = Label11.Text;
                    }
                }
                DataRow datcontcorpo = Validar.Consulta(terc.ConsultarPersonaIdenti(dni)).Rows[0];
                contrat.terceros_idterceros = Validar.validarlleno(datcontcorpo["idterceros"].ToString());
                contrat.codigo = Validar.validarlleno(TextBox4.Text);
                contrat.fechacontrato = Validar.validarlleno(Textboxfechainiciopermanencia.Text);
                contrat.fechaactivacion = Validar.validarlleno(Textboxfechaactivacionservicio.Text);
                contrat.fechafacturacion = Validar.validarlleno(Textboxfechafacturacion.Text);
                contrat.estado = Validar.validarselected(DropDownListestadocontrato.Text);
                contrat.tipocontrato_idtipocontrato = Validar.validarselected(DropDownListtipocontrato.SelectedValue);
                contrat.plan_idplan = Validar.validarlleno(Labeldipalcontra.Text);
                contrat.iva = Validar.validarlleno(TextBoxivacontrato.Text);
                contrat.enviofactura = Validar.validarselected(DropDownList1.SelectedValue);
                contrat.facturaunica = Validar.validarselected(DropDownListfacturaunicacontrato.SelectedValue);
                contrat.personal_idpersonal = Validar.validarsession(sesion.ToString());
                contrat.sucursal_idsucursal = Validar.ConvertNumber(DropDownListsucursalcontrato.SelectedValue);
                contrat.observaciondirec = Validar.validarlleno(TextArea1.Value);
                contrat.direccionenviofact = Validar.validarlleno(TextBox1.Text);
                contrat.barrio_idbarrio = Validar.validarselected(DropDownListbarriocontrato.SelectedValue);



                if (contrat.RegistrarContrato(contrat))
                {
                    textError.InnerHtml = "Se ha registrado con exito";
                    Alerta.CssClass = "alert alert-success";
                    Alerta.Visible = true;                  
                    ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);
                    Response.Redirect("Contratoterc.aspx");
                }
                else
                {
                    textError.InnerHtml = "No se ha registrado";
                    Alerta.CssClass = "alert alert-error";
                    Alerta.Visible = true;
                    ClientScript.RegisterStartupScript(GetType(), "", "panel2();", true);
                }

            }
            catch (Exception ex)
            {

                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;

            }
        }      
  

        protected void Button4cargarmodalcontrato_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "", "botonmodalcontrato();", true);
        }
    }
}






