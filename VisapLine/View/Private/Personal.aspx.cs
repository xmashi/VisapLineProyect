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
    public partial class Personal : System.Web.UI.Page
    {
        Model.Personal pers = new Model.Personal();
        UsuarioL usua = new UsuarioL();
        Random rnd1 = new Random();
        class_correo cor = new class_correo();
        Rol rol = new Rol();
        public static bool activacion = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    rol_.DataSource = Validar.Consulta(rol.ConsultarRol());
                    rol_.DataTextField = "rol";
                    rol_.DataValueField = "idrol";
                    rol_.DataBind();
                }
            }
            catch (Exception ex)
            {
                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;
            }
        }

        protected void ConsultarUsuario(object sender, EventArgs e)
        {
            try
            {
                pers.identificacion = Validar.validarlleno(identif_.Value);
                tablausuario.DataSource = Validar.Consulta(pers.ConsultarPersonalIdentf(pers));
                tablausuario.DataBind();
            }
            catch (Exception ex)
            {
                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;
            }
        }

        protected void tablausuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void tablausuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "ver")
                {
                    string DeleteRowId = e.CommandArgument.ToString();
                    //pendiete para la vista de contratos
                }
                if (e.CommandName.ToString() == "Editar")
                {
                    ClientScript.RegisterStartupScript(GetType(), "alerta", "panel2();", true);
                    pers.identificacion = e.CommandArgument.ToString();
                    DataRow dat = pers.ConsultarPersonalIdentf(pers).Rows[0];
                    codigo.InnerHtml = dat["idpersonal"].ToString();
                    codigo1.InnerHtml = dat["usuario_idusuario"].ToString();
                    identificacion_.Value = dat["identificacion"].ToString();
                    nombre_.Value = dat["nombre"].ToString();
                    apellido_.Value = dat["apellido"].ToString();
                    fecnac_.Value = Convert.ToDateTime(dat["fechanat"].ToString()).ToString("yyyy-MM-dd");
                    rh_.SelectedValue = dat["rh"].ToString();
                    estado_.SelectedValue = dat["estado"].ToString().ToLower();
                    correo_.Value = dat["correo"].ToString();
                    rol_.SelectedValue = dat["rol_idrol"].ToString();
                    usua.idusuario = dat["usuario_idusuario"].ToString();
                    DataRow daat = usua.ConsultarUsuarioId(usua).Rows[0];
                    usuario_.Value = daat["usuario"].ToString();
                    textediccion.InnerHtml = "Edicción habilitada para " + dat["nombre"].ToString() + " " + dat["apellido"].ToString();
                    viewedicion.Visible = true;
                    activacion = true;
                }
                if (e.CommandName.ToString() == "Eliminar")
                {
                    pers.identificacion = e.CommandArgument.ToString();
                    DataRow dat = pers.ConsultarPersonalIdentf(pers).Rows[0];
                    pers.idpersonal = dat["idpersonal"].ToString();
                    pers.identificacion = dat["identificacion"].ToString();
                    pers.nombre = dat["nombre"].ToString();
                    pers.apellido = dat["apellido"].ToString();
                    pers.fechanac = Convert.ToDateTime(dat["fechanat"].ToString()).ToString("yyyy-MM-dd");
                    pers.rh = dat["rh"].ToString();
                    pers.estado = "false";
                    pers.correo = dat["correo"].ToString();
                    pers.usuario_idusuario= dat["usuario_idusuario"].ToString();
                    if (pers.ActualizarPersonal(pers))
                    {
                        pers.identificacion = pers.identificacion;
                        tablausuario.DataSource = Validar.Consulta(pers.ConsultarPersonalIdentf(pers));
                        tablausuario.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;
            }
        }
        protected void RegistrarPersonal(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "alerta", "panel2();", true);
            try
            {
                if (activacion)
                {
                    
                    pers.identificacion = Validar.validarlleno(identificacion_.Value);
                    pers.nombre = Validar.validarlleno(nombre_.Value);
                    pers.apellido = Validar.validarlleno(apellido_.Value);
                    pers.fechanac = Validar.validarlleno(fecnac_.Value);
                    pers.rh = Validar.validarselected(rh_.SelectedValue);
                    pers.estado = Validar.validarselected(estado_.SelectedValue);
                    pers.correo = Validar.validarlleno(correo_.Value);
                    pers.idpersonal = codigo.InnerHtml;
                    if (pers.ActualizarPersonal(pers))
                    {
                        usua.idusuario = codigo1.InnerHtml;
                        usua.rol_idrol = rol_.SelectedValue;
                        if (usua.ActualizarUsuarioRol(usua))
                        {
                            textError.InnerHtml = "Actualizado correctamente";
                            Alerta.CssClass = "alert alert-success";
                            Alerta.Visible = true;
                        }
                        else
                        {
                            textError.InnerHtml = "Se actualizo el empleado pero no se le actualizo el rol";
                            Alerta.CssClass = "alert alert-error";
                            Alerta.Visible = true;
                        }
                    }
                    else
                    {
                        textError.InnerHtml = "No se ha podido actualizar el empleado";
                        Alerta.CssClass = "alert alert-error";
                        Alerta.Visible = true;
                    }
                }
                else
                {
                    usua.usuapassw = Convert.ToString(rnd1.Next(10000, 99999));
                    usua.usuauser = Validar.validarlleno(identificacion_.Value);
                    usua.rol_idrol = Validar.validarselected(rol_.SelectedValue);

                    //Datos del Personal
                    pers.identificacion = Validar.validarlleno(identificacion_.Value);
                    pers.nombre = Validar.validarlleno(nombre_.Value);
                    pers.apellido = Validar.validarlleno(apellido_.Value);
                    pers.fechanac = Validar.validarlleno(fecnac_.Value);
                    pers.rh = Validar.validarselected(rh_.SelectedValue);
                    pers.estado = Validar.validarselected(estado_.SelectedValue);
                    pers.correo = Validar.validarlleno(correo_.Value);
                    if (usua.RegistrarUsuario(usua))
                    {
                        DataRow dat = usua.ConsultarUsuarioByUsuarioCed(usua).Rows[0];
                        pers.usuario_idusuario = dat["idusuario"].ToString();
                        if (pers.RegistrarPersonal(pers))
                        {
                            cor.destinatario = pers.correo;
                            cor.asunto = "Bienvenido a VisapLine";
                            cor.cuerpo = "Ya eres parte de la empresa.\n Inicia sesión con:\n Usuario:" + pers.identificacion + " Contraseña:" + usua.usuapassw + "";
                            cor.EnviarMensaje();
                            textError.InnerHtml = "Registrado correctamente";
                            Alerta.CssClass = "alert alert-success";
                            Alerta.Visible = true;
                        }
                        else
                        {
                            textError.InnerHtml = "No se ha podido conpletar el registro, es posible que ya se encuente registrado";
                            Alerta.CssClass = "alert alert-error";
                            Alerta.Visible = true;
                        }
                    }
                    else
                    {
                        textError.InnerHtml = "No se ha podido completar el registro, verifique el usuario no se encuentre registrado";
                        Alerta.CssClass = "alert alert-error";
                        Alerta.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                textError.InnerHtml = ex.Message;
                Alerta.CssClass = "alert alert-error";
                Alerta.Visible = true;
            }

        }
        protected void CancelarPersonal(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "alerta", "panel2();", true);
            codigo.InnerHtml ="";
            codigo1.InnerHtml = "";
            identificacion_.Value = "";
            nombre_.Value = "";
            apellido_.Value = "";
            fecnac_.Value = "";
            rh_.SelectedValue = "Seleccione";
            estado_.SelectedValue = "Seleccione";
            correo_.Value = "";
            rol_.SelectedValue = "Seleccione";
            usuario_.Value = "";
            activacion = false;
            textediccion.InnerHtml = "";
            viewedicion.Visible = false;
            Alerta.Visible = false;
        }
    }
}