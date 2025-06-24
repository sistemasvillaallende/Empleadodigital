<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MP.Master" 
    AutoEventWireup="True" CodeBehind="Fichadas.aspx.cs"
    Inherits="HHRR.Empleado.Fichadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/stacktable.css" rel="stylesheet" />
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
        <div class="row">
            <div class="col-md-3">
                <div class="box" style="border-top: 3px solid #6f6f6e;">
                    <div class="box-header">
                        <h3 class="box-title" id="lblTurno" runat="server">Horarios</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Dia</th>
                                    <th>Horarios</th>
                                </tr>
                            </thead>
                            <tbody id="divTablaHorarios" runat="server">
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
                <div class="box" style="border-top: 3px solid #6f6f6e;">
                    <div class="box-header">
                        <h3 class="box-title" id="H1" runat="server">Razones Particulares <span id="lblAnio" runat="server"></span></h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Utilizados</th>
                                    <th>Disponibles</th>
                                </tr>
                            </thead>
                            <tbody id="Tbody1" runat="server">
                            </tbody>
                        </table>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Fechas</th>
                                </tr>
                            </thead>
                            <tbody id="Tbody2" runat="server">
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
            <div class="col-md-9">
                <div class="box box-primary" style="box-shadow: 0 1px 1px rgba(0, 0, 0, 0.77); border-top: 3px solid #6f6f6e;">
                    <div class="box-header with-border" style="border-bottom: 1px solid #ddd;">
                        <div class="col-md-6">
                            <h4>Fichadas</h4>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Año</label>
                                <asp:DropDownList ID="DDLAnio" OnSelectedIndexChanged="DDLAnio_SelectedIndexChanged"
                                    AutoPostBack="true"
                                    CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Mes</label>
                                <asp:DropDownList ID="DDLMes" CssClass="form-control" runat="server"
                                    AutoPostBack="true" OnSelectedIndexChanged="DDLMes_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="box-body">
                        <asp:GridView
                            ID="gvFichadas"
                            CssClass="table"
                            OnRowDataBound="gvFichadas_RowDataBound"
                            runat="server"
                            CellPadding="4"
                            ForeColor="#333333"
                            AutoGenerateColumns="false"
                            GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                            <Columns>
                                <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="E1" HeaderText="Entra" />
                                <asp:BoundField DataField="S1" HeaderText="Sale" />
                                <asp:BoundField DataField="E2" HeaderText="Entra" />
                                <asp:BoundField DataField="S2" HeaderText="Sale" />
                                <asp:BoundField DataField="HORAS" HeaderText="Horas" />
                                <asp:BoundField DataField="HORAS_EXTRAS" HeaderText="Horas Extras" />
                                <asp:TemplateField HeaderText="Novedades">
                                    <ItemTemplate>
                                        <span id="lblNovedad" runat="server"></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        <EditRowStyle BackColor="#999999"></EditRowStyle>
                        <FooterStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></FooterStyle>
                        <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                        <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                        <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                        <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="alert alert-danger alert-dismissible" id="divError" runat="server" visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <h4><i class="icon fa fa-ban"></i>Error!</h4>
                    <p id="txtError" runat="server"></p>
                </div>
            </div>
        </div>
    </div>



    <script src="../App_Themes/plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <script src="../App_Themes/stacktable.js"></script>
    <script>
        $('#<%=gvFichadas.ClientID %>').cardtable();
    </script>
</asp:Content>
