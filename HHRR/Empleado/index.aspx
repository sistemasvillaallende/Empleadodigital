<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MP.Master" 
    AutoEventWireup="True" CodeBehind="index.aspx.cs" 
    Inherits="HHRR.Empleado.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="alert alert-danger alert-dismissible" id="divError" runat="server" visible="false">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            <h4><i class="icon fa fa-ban"></i>Error!</h4>
            <p id="txtError" runat="server"></p>
        </div>
    </div>
    <div class="container-fluid container_mobile" style="background-color: white;
    padding: 40px;">
        <div class="row" style="margin-bottom:30px;">
            <div class="col-md-12">
                <h3>Mis servicios</h3>
                <hr style="margin-top: 10px;
    margin-bottom: 0;
    border: 0;
    border-top: 1px solid #cdcdcd;"/>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera">
                        <h4>Datos Personales</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-user-circle" style="font-size: 50px; color: #fad613;"></span>
                    </div>

                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="Datos.aspx">Acceder</a>
                    </div>
                </div>
            </div>
            <!--<div class="col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera">
                        <h4>Titulos Educativos</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-graduation-cap" style="font-size: 50px; color: #fad613;"></span>
                    </div>

                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="#">Acceder</a>
                    </div>
                </div>
            </div>-->
            <div class="col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera">
                        <h4>Documentación</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-files-o" style="font-size: 50px; color: #fad613;"></span>
                    </div>

                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="../Certificados/Certificados.aspx">Acceder</a>
                    </div>
                </div>
            </div>
            <div class="col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera">
                        <h4>Familiares</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-users" style="font-size: 50px; color: #fad613;"></span>
                    </div>
                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="../Empleado/Familiares.aspx">Acceder</a>
                    </div>
                </div>
            </div>
            <div class="col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera">
                        <h4>Recibos de Sueldo</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-money" style="font-size: 50px; color: #fad613;"></span>
                    </div>

                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="RecibosSueldo.aspx">Acceder</a>
                    </div>
                </div>
            </div>
            <div class="col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera">
                        <h4>Marcaciones</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-clock-o" style="font-size: 50px; color: #fad613;"></span>
                    </div>

                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="Fichadas.aspx">Acceder</a>
                    </div>
                </div>
            </div>
            <!--<div class="col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera">
                        <h4>Licencias y Permisos</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-calendar-check-o" style="font-size: 50px; color: #fad613;"></span>
                    </div>

                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="#">Acceder</a>
                    </div>
                </div>
            </div>
            <div class="col-xl-2 col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary caja">
                    <div class="box-header cabecera">
                        <h4>Carpetas Medicas</h4>
                    </div>
                    <div class="box-body cuerpo">
                        <span class="fa fa-plus-square" style="font-size: 50px; color: #fad613;"></span>
                    </div>

                    <div class="box-footer">
                        <a class="btn btn-primary btn-block" href="#">Acceder</a>
                    </div>
                </div>
            </div>-->

        </div>
    </div>
</asp:Content>
