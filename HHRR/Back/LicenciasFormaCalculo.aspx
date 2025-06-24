<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MP.Master" AutoEventWireup="true" CodeBehind="LicenciasFormaCalculo.aspx.cs" Inherits="HHRR.Back.LicenciasFormaCalculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="alert alert-danger alert-dismissible" id="divError" runat="server" visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <h4><i class="icon fa fa-ban"></i>Error!</h4>
                    <p id="txtError" runat="server"></p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="box">
                    <div class="box-header with-border">
                        <h3 class="box-title" id="lblLicencia" runat="server"></h3>
                    </div>
                    <div class="box-body">
                        <!--id, descripcion, tipoLicencia, habiles, tipo, cantDias, masiva, sexo, fracciona, acumula-->
                        <a href="#"
                            style="margin-bottom: 20px;"
                            class="btn btn-primary" onclick="abrirModal('','','','','True')">
                            <span class="fa fa-plus">Agregar Forma de calculo</span>
                        </a>
                        <asp:GridView
                            ID="gvLicencias"
                            runat="server"
                            CellPadding="4"
                            OnRowCommand="gvLicencias_RowCommand"
                            OnRowDataBound="gvLicencias_RowDataBound"
                            CssClass="table"
                            ForeColor="#333333"
                            GridLines="None" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="De">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesde" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="A">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHasta" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Días">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDias" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="btn-group">
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-info dropdown-toggle"
                                                    data-toggle="dropdown">
                                                    <span class="fa fa-bars"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <!--id, descripcion, tipoLicencia, habiles, tipo, cantDias, masiva, sexo, fracciona, acumula-->
                                                        <a href="#"
                                                            onclick="abrirModal('<%#Eval("id")%>','<%#Eval("anio_desde")%>', 
                                                            '<%#Eval("anios_hasta")%>','<%#Eval("cantidad_dias")%>','<%#Eval("habiles")%>')">
                                                            <span style="font-size: 20px;" class="fa fa-edit"></span>
                                                            Editar
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="lBtnBorrar"
                                                            CommandArgument='<%#Eval("id")%>'
                                                            runat="server"
                                                            OnClientClick="return confirm('Esta seguro de eliminar la licencia')"
                                                            CommandName="borrar">
                                            <span class="fa fa-trash" style="font-size:20px;"></span>Eliminar
                                                        </asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999"></EditRowStyle>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
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
        <div class="modal fade in" id="modalLicencia">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header with-border">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
                        <h4 class="modal-title">Forma de calculo</h4>
                    </div>
                    <div class="modal-body">
                        <div class="box">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>De</label>
                                            <asp:TextBox ID="txtDesde" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Unidad</label>
                                            <asp:DropDownList ID="DDLUnidadDesde" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="1" Text="Años"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="Meses"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>A</label>
                                            <asp:TextBox ID="txtHasta" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Unidad</label>
                                            <asp:DropDownList ID="DDLUnidadHasta" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="1" Text="Años"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="Meses"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Dias</label>
                                            <asp:DropDownList ID="DDLDias" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="1" Text="Habiles"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="Corridos"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Cantidad</label>
                                            <asp:TextBox ID="txtDias" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Proporcional</label>
                                            <asp:CheckBox CssClass="form-control" ID="chkProporcional" Text="SI" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                            <button type="button" class="btn btn-primary" id="btnGuardar" runat="server"
                                onserverclick="btnGuardar_ServerClick" validationgroup="campania">
                                Guardar</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </div>
    </div>
    <script src="../App_Themes/plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <script src="../App_Themes/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../App_Themes/plugins/datatables/dataTables.bootstrap.js"></script>
    <script>
        function abrirModal(id, desde, hasta, cantDias, habiles) {
            $('#modalLicencia').modal('show');
            //ID
            $("#ContentPlaceHolder1_hId").val(id);
            if (desde != '')
                $("#ContentPlaceHolder1_txtDesde").val(desde);

            $("#ContentPlaceHolder1_txtHasta").val(hasta);

            $("#ContentPlaceHolder1_txtDias").val(cantDias);

            if (habiles == "False") {
                $("#ContentPlaceHolder1_DDLDias").val(0);
            }
            else {
                $("#ContentPlaceHolder1_DDLDias").val(1);
            }
        }
    </script>

</asp:Content>
