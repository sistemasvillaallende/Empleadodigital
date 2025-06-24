<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MP.Master" 
    AutoEventWireup="true" CodeBehind="RecibosSueldo.aspx.cs"
    Inherits="HHRR.Empleado.RecibosSueldo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pry {
            background-color: #3c8dbc;
            border-color: #367fa9;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid container_mobile" style="background-color: white; padding: 40px;">
        <div class="row">
            <div class="col-xs-7">
                <h3>Recibos de Sueldo</h3>
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

        <div class="col-md-12">
            <div class="alert alert-danger alert-dismissible" id="divError" runat="server" visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-ban"></i>Error!</h4>
                <p id="txtError" runat="server"></p>
            </div>
        </div>
        <div class="row" style="margin-bottom:30px;">
            <div class="col-md-12">
                <div class="btn-group pull-right">
                    <div class="btn-group">
                        <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-expanded="true">
                            Buscar Anteriores <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu" id="ddlAnteriores" runat="server">
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div id="divSueldos" runat="server">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <hr style="border-top: 1px solid #cacaca;" />
            </div>
            <div class="col-md-12" id="divAguinaldos" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
