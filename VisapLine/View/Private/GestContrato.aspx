﻿<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/View/Private/Admin.Master" AutoEventWireup="true" CodeBehind="GestContrato.aspx.cs" Inherits="VisapLine.View.Private.GestContrato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function botonmodalgesti() {
            document.getElementById("botonmodalcontr").click();
        }
    </script>
    <style>
        textarea {
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Contenido/assets/vendor_components/sweetalert/sweetalert.min.js"></script>
    <script type="text/javascript">
        function deletealert() {
            swal({
                title: "SE REGISTRO CON EXITO!",
                text: "Se ha registrado con exito ",
                type: "success"
            });
        }
        function gestdeletealert() {
            swal("SE LA OPERACION SE HA REALIZADO CON EXITO!", "Se completo la operacion", "success");
        }
        function alerterror() {
            swal("NO SE REGISTRO!", "No se registro el formulario", "error");
        }
        function nocontro() {
            swal("NO SE ENCONTRO NINGUN REGISTRO!", "Debe registrar el cliente", "error");
        }
        function nocontro() {
            swal("NO SE REALIZO LA OPERACION!", "La operacion no fue posible", "error");
        }
        function errordatos() {
            swal("NO SE REALIZO LA OPERACION!", "La operacion no fue posible, consulte con soporte tecnico", "error");
        }
    </script>


    <asp:Panel ID="Alerta" Visible="false" runat="server" CssClass="col-12 alert alert-success alert-error">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
        <label class="text-center" runat="server" id="textError"></label>
    </asp:Panel>
    <section class="content-header">
        <h1>Gestionar Contratos</h1>
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i>VisapLine</a></li>
            <li class="breadcrumb-item"><a href="#">Clientes</a></li>
            <li class="breadcrumb-item active">Gestinar Contratos</li>
        </ol>
    </section>
    <section class="content">
        <div class="box box-default" id="buscador" runat="server">
            <div class="box-header with-border">
                <h3 class="box-title">Buscar Contrato</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                <div class="row">
                    <div class="col-md-6 col-12">
                        <div class="form-group row">
                            <label for="example-text-input" class="col-sm-3 col-form-label">CC o Nit:</label>
                            <div class="col-sm-9">
                                <asp:TextBox runat="server" CssClass="form-control" ID="texboxdni" Style="text-transform: uppercase"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-12">
                        <div class="form-group row">
                            <div class="col-sm-10">
                                <asp:Button runat="server" class="btn btn-block btn-success btn-lg" ID="Button1" Text="Consultar" OnClick="Button1_Click" Width="146px" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.col -->
            </div>
        </div>
        <!-- /.row -->

        <!-- /.box-header -->
        <div class="row" id="divtablagestcontr" runat="server" visible="false">
            <div class="box box-primary">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="false" class="table table-bordered table-striped table-responsive" OnRowDataBound="GridView1_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" SelectText="" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                        <asp:BoundField HeaderText="Codg" DataField="codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombreter" />
                        <asp:BoundField HeaderText="Fecha" DataFormatString="{0:d}" DataField="fechacontrato" />
                        <asp:BoundField HeaderText="Estado" DataField="estadoc" />
                        <asp:BoundField HeaderText="Direccion" DataField="direnviofactura" />
                        <asp:BoundField HeaderText="Envio Factura" DataField="enviofactura" />
                        <asp:BoundField HeaderText="Observacion" DataField="observacion" />
                        <asp:BoundField HeaderText="Valor" DataField="valor" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                    <RowStyle BackColor="#EFF3FB"></RowStyle>

                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                    <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                    <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                    <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                    <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </div>
        </div>

        <div class="box box-default " id="ideditarcontrat" runat="server" visible="false">
            <div class="box-header with-border">
                <h2 class="box-title">Contrato  N°
                    <asp:Label ID="LabelNumcontra" runat="server" Text=""></asp:Label></h2>
                <div class="box-tools pull-right">
                </div>
            </div>

            <!-- /.box-header -->
            <div class="box-body" style="">
                <div class="row">
                    <div class="col-md-6 col-12">
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Nombre:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <asp:Label ID="TextBox1identificacion" Enabled="false" class="form-control" Style="text-transform: uppercase" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Estado:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <asp:DropDownList ID="DropDownListestadocontrato" Enabled="false" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                        <asp:ListItem>ACTIVO</asp:ListItem>
                                        <asp:ListItem>INACTIVO</asp:ListItem>
                                        <asp:ListItem>ELIMINADO</asp:ListItem>
                                        <asp:ListItem>SUSPENDIDO</asp:ListItem>
                                        <asp:ListItem>ANULADO</asp:ListItem>
                                        <asp:ListItem>EXONERADO</asp:ListItem>
                                        <asp:ListItem>POR INSTALAR</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Tipo Contrato:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <asp:DropDownList ID="DropDownListtipocontrato" Enabled="false" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Direccion de Envio:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <textarea id="TextArea1" cols="20" rows="2" disabled class="form-control" runat="server" style="text-transform: uppercase; margin-top: 0px; margin-bottom: 0px; height: 122px;"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Descuento:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                      <asp:TextBox ID="TextBox1" class="form-control" Enabled="false" Style="text-transform: uppercase" runat="server"></asp:TextBox>                              
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Plan:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <asp:DropDownList ID="DropDownListplanes" Enabled="false" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem>Seleccione</asp:ListItem>                                        
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="Labelidcontrato" runat="server" Visible="false" Text="Label"></asp:Label>
                    <div class="col-md-6 col-12">
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Envio Factura:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <asp:DropDownList ID="DropDownListenviofactura" Enabled="false" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                        <asp:ListItem>CORREO</asp:ListItem>
                                        <asp:ListItem>DOMICILIO</asp:ListItem>
                                        <asp:ListItem>AMBOS</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Factura:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <asp:DropDownList ID="DropDownList1facuracuni" Enabled="false" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                        <asp:ListItem>UNICA</asp:ListItem>
                                        <asp:ListItem>GRUPAL</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">barrio:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <asp:DropDownList ID="DropDownList1" runat="server" Enabled="false" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Iva:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <asp:TextBox ID="TextBoxivacontrato" class="form-control" Enabled="false" Style="text-transform: uppercase" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Observacion:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <textarea id="TextArea2" cols="20" rows="2" disabled class="form-control" runat="server" style="text-transform: uppercase; margin-top: 0px; margin-bottom: 0px; height: 122px;"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label">Wifi:</label>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <asp:DropDownList ID="DropDownList3" runat="server" Enabled="false" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                        <asp:ListItem>SI</asp:ListItem>
                                        <asp:ListItem>NO</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                    </div>

                </div>

            </div>

        </div>

        <center>
            <table>
                <tr>
                    <th>
                          <asp:Button ID="Buttoneditar" runat="server" Visible="false" Text="Editar" class="btn btn-block btn-info btn-lg" Width="143px" Height="30px" OnClick="Buttoneditar_Click" /></th>
                
                    <th>
                        
                        <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" Visible="false" Enabled="false" class="btn btn-block btn-success btn-lg" Width="143px" Height="30px" OnClick="ButtonGuardar_Click" />
                           
                  
                        </th>
                    <th>
                        <asp:Button ID="Buttoncancelar" runat="server" Visible="false" Enabled="false" Text="Cancelar" class="btn btn-block btn-danger btn-lg" Width="143px" Height="30px" OnClick="Buttoncancelar_Click" /></th>
                                <th>
                        <asp:Button ID="Buttonservicio" runat="server" Visible="false"  Text="Modificar Servicio" class="btn btn-block btn-info btn-lg" Width="143px" Height="30px" OnClick="Buttonservicio_Click" /></th>
                    </tr>

            </table> 
      </center>


    </section>

</asp:Content>
