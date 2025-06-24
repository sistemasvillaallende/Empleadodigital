<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MP.Master" 
    AutoEventWireup="true" CodeBehind="Certificados.aspx.cs" 
    Inherits="HHRR.Certificados.Certificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid container_mobile" style="background-color: white; padding: 40px;">
        <div class="row">
            <div class="col-xs-7">
                <h3>Certificados Disponibles</h3>
            </div>
            <div class="col-xs-5">
                <a href="../Empleado/index.aspx" class="btn-outline-warning" style="float: right;">
                    <span class="fa fa-sign-out"></span>&nbsp; Salir</a>
            </div>
        </div>
        <div class="row" style="margin-bottom: 30px;">
            <div class="col-md-12">
                <hr style="margin-top: 10px; margin-bottom: 0; border: 0; border-top: 1px solid #cdcdcd;" />
            </div>
        </div>
        <div class="row">
            <div class="col-xl-3 col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera" style="height:60.59px">
                        <h4>Certificado de Trabajo</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-user-circle" style="font-size: 50px; color: #fad613;"></span>
                    </div>

                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="CertLaboral.aspx">Acceder</a>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-lg-3 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera" style="height:60.59px">
                        <h4>Certificado de "No cobro de Asignaciones Familiares"</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-user-circle" style="font-size: 50px; color: #fad613;"></span>
                    </div>

                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="CertNoAsignaciones.aspx">Acceder</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
