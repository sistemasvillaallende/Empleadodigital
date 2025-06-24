<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MP.Master" 
    AutoEventWireup="true" CodeBehind="Familiares.aspx.cs" 
    Inherits="HHRR.Empleado.Familiares" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/stacktable.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid container_mobile" style="background-color: white; padding: 40px;">
        <div class="row">
            <div class="col-xs-7">
                <h3>Familiares a Cargo</h3>
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
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-12">
                    <asp:GridView ID="gvFamiliares" CssClass="table"
                        runat="server"
                        CellPadding="4"
                        OnRowDataBound="gvFamiliares_RowDataBound"
                        AutoGenerateColumns="false"
                        ForeColor="#101244"
                        GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="fecha_alta_registro" HeaderText="Fecha Alta"
                                DataFormatString="{0:d}" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="nro_documento" HeaderText="Nro. Documento" />

                            <asp:TemplateField HeaderText="SEXO">
                                <ItemTemplate>
                                    <p id="lblSexo" runat="server"></p>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="parentezco" HeaderText="Parentezco" />
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

    <script src="../App_Themes/plugins/jQuery/jQuery-2.1.4.min.js"></script>

    <script src="../App_Themes/stacktable.js"></script>
    <script>
        $('#<%=gvFamiliares.ClientID %>').cardtable();
    </script>
</asp:Content>
