<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MP.Master"
    AutoEventWireup="true" CodeBehind="Datos.aspx.cs"
    Inherits="HHRR.Empleado.Datos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .datos {
            border-bottom-color: #ddd;
            border-bottom-style: inset;
        }

        .description {
            font-size: 14px;
            font-weight: 400;
            line-height: 1.8;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="alert alert-danger alert-dismissible" id="divError" runat="server" visible="false">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            <h4><i class="icon fa fa-ban"></i>Error!</h4>
            <p id="txtError" runat="server"></p>
        </div>
    </div>
    <div class="container-fluid container_mobile" style="background-color: white;">
        <div class="row">
            <div class="col-xs-7">
                <h3>Mis Datos Personales</h3>
            </div>
            <div class="col-xs-5">
                <a href="index.aspx" class="btn-outline-warning" style="float: right;">
                    <span class="fa fa-sign-out"></span>&nbsp; Salir</a>
            </div>
        </div>
        <div class="row" style="margin-bottom: 30px;">
            <div class="col-md-12">
                <hr style="margin-top: 10px; margin-bottom: 0; border: 0; border-top: 1px solid #cdcdcd;" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-4">
                        <!--<img class="img-circle img-bordered-sm" src="../App_Themes/images/usuario.png" alt="user image" />-->
                        <p class="description" id="lblNombreEmpleado" runat="server">
                        </p>
                        <p class="description" id="lblLegajoEmpleado" style="display: none" runat="server"></p>
                        <p class="description" id="lblCUIT" runat="server"></p>
                        <p class="description" id="lblNroDoc" runat="server"></p>
                    </div>
                    <div class="col-md-3">
                        <p class="description" id="lblFecNac" runat="server"></p>
                        <p class="description" id="lblSexo" runat="server"></p>
                        <p class="description" id="lblEstCivil" runat="server"></p>
                    </div>
                    <div class="col-md-5">
                        <p>

                            <span class="fa fa-phone">
                                <span id="spanTel" class="description" runat="server"></span>
                                &nbsp;&nbsp;</span>
                            <!-- <a href="#">
                                <span class="fa fa-edit" style="font-size: 20px; color: brown;"></span>
                            </a>-->
                        </p>
                        <p>
                            <span class="description fa fa-envelope">
                                <span id="spanMail2" runat="server"></span>
                            </span>
                            <!--<a href="#">
                                <span class="description fa fa-envelope">
                                    <span id="spanMail" runat="server"></span>
                                    &nbsp;&nbsp;<span class="fa fa-edit" style="font-size: 20px; color: brown;"></span></span>
                            </a>-->
                        </p>
                        <p class="description">
                            <i class="fa fa-map-marker"></i><span id="lblDomicilio" runat="server"></span>
                        </p>


                    </div>
                </div>

                <hr />
                <div class="row">
                    <div class="col-md-6">
                        <div class="box box-primary" style="box-shadow: 0 1px 1px rgba(0, 0, 0, 0.77); border-top-color: #fad613;">
                            <div class="box-header with-border" style="border-bottom: 1px solid #ddd;">
                                <h4>Datos Empleado</h4>
                            </div>
                            <div class="box-body">
                                <p class="datos" id="lblLegajo" runat="server"></p>
                                <p class="datos" id="lblFechaIngreso" runat="server"></p>
                                <p class="datos" id="lblCategoria" runat="server"></p>
                                <p class="datos" id="lblTarea" runat="server"></p>
                                <p class="datos" id="lblCargo" runat="server"></p>
                                <p class="datos" id="lblSeccion" runat="server"></p>
                                <p class="datos" id="lblClasificacion" runat="server"></p>
                                <p class="datos" id="lblSecretaria" runat="server"></p>
                                <p class="datos" id="lblDireccion" runat="server"></p>
                                <p class="datos" id="lblOficina" runat="server"></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="box box-info" style="box-shadow: 0 1px 1px rgba(0, 0, 0, 0.77); border-top-color: #fad613;">
                            <div class="box-header with-border" style="border-bottom: 1px solid #ddd;">
                                <h4>Datos Contrato y Obra Social</h4>
                            </div>
                            <div class="box-body">
                                <p class="datos" id="lblBanco" runat="server"></p>
                                <p class="datos" id="lblTipoCuenta" runat="server"></p>
                                <p class="datos" id="lblCbu" runat="server"></p>
                                <p class="datos" id="lblNroAfiliado" runat="server"></p>
                                <p class="datos" id="lblAntiguedadActual" runat="server"></p>
                                <p class="datos" id="lblAntiguedadAnterior" runat="server"></p>
                            </div>
                            <div class="box-footer">
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
