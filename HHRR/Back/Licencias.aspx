<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MP.Master" AutoEventWireup="true" CodeBehind="Licencias.aspx.cs"
    Inherits="HHRR.Back.Licencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="../App_Themes/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hId" runat="server" />
    <asp:HiddenField ID="hUsuario" runat="server" />
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
                        <h3 class="box-title">Listado de Licencias</h3>
                    </div>
                    <div class="box-body">
                        <!--id, descripcion, tipoLicencia, habiles, tipo, cantDias, masiva, sexo, fracciona, acumula-->
                        <a href="#"
                            style="margin-bottom: 20px;"
                            class="btn btn-primary" onclick="abrirModal('','','1','True','0','','False','0','False','False','False')">
                            <span class="fa fa-plus">Agregar Licencia</span>
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
                                <asp:BoundField DataField="cod_tipo_licencia" HeaderText="Cod"></asp:BoundField>
                                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion"></asp:BoundField>
                                <asp:TemplateField HeaderText="Tipo">
                                    <ItemTemplate>
                                        <span id="lblTipo" runat="server"></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Forma Calculo">
                                    <ItemTemplate>
                                        <span id="lblCalculo" runat="server"></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cant. Dias">
                                    <ItemTemplate>
                                        <span id="lblCantDias" runat="server"></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aplica a">
                                    <ItemTemplate>
                                        <span id="lblSexo" runat="server"></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Masiva">
                                    <ItemTemplate>
                                        <span id="lblMasiva" runat="server"></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fracciona">
                                    <ItemTemplate>
                                        <span id="lblFracciona" runat="server"></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acumula">
                                    <ItemTemplate>
                                        <span id="lblAcumula" runat="server"></span>
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
                                                            onclick="abrirModal('<%#Eval("cod_tipo_licencia")%>', '<%#Eval("descripcion")%>',
                                                            '<%#Eval("tipo")%>','<%#Eval("habiles")%>','<%#Eval("fija")%>',
                                                            '<%#Eval("cantidad_dias")%>','<%#Eval("masiva")%>','<%#Eval("sexo")%>',
                                                            '<%#Eval("separa")%>','<%#Eval("acumula")%>')">
                                                            <span style="font-size: 20px;" class="fa fa-edit"></span>
                                                            Editar
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="lBtnBorrar"
                                                            CommandArgument='<%#Eval("cod_tipo_licencia")%>'
                                                            runat="server"
                                                            OnClientClick="return confirm('Esta seguro de eliminar la licencia')"
                                                            CommandName="borrar">
                                            <span class="fa fa-trash" style="font-size:20px;"></span>Eliminar
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="btnActivo"
                                                            CommandArgument='<%#Eval("cod_tipo_licencia")%>'
                                                            runat="server"
                                                            CommandName="activar">
                                            <span class="fa fa-eye-slash" style="font-size:20px;"></span>Activar
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="btnDesactivo"
                                                            CommandArgument='<%#Eval("cod_tipo_licencia")%>'
                                                            runat="server"
                                                            CommandName="desactivar">
                                            <span class="fa fa-eye" style="font-size:20px;"></span>Desactivar
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
                        <h4 class="modal-title">Nueva Licencia</h4>
                    </div>
                    <div class="modal-body">
                        <div class="box">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Nombre</label>
                                            <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Tipo</label>
                                            <asp:DropDownList ID="DDLTipo" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Dias</label>
                                            <asp:DropDownList ID="DDLDias" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="1" Text="Habiles"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="Corridos"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Forma de calculo</label>
                                            <asp:DropDownList ID="select" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="0" Text="Calculada"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Fija"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:HiddenField Value="1" ID="hTipo" runat="server" />
                                        <div class="form-group" id="cant_dias">
                                            <label>Cantidad de días</label>
                                            <asp:TextBox TextMode="Number" ID="txtCantDias"
                                                Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Masiva</label>
                                            <asp:DropDownList ID="DDLMasiva" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="0" Text="NO"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="SI"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Aplica a</label>
                                            <asp:DropDownList ID="DDLSexo" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="0" Text="TODOS"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="MUJERES"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="HOMBRES"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Puede Fraccionar</label>
                                            <asp:DropDownList ID="DDLFracciona" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="1" Text="SI"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="NO"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Acumula Anualmente</label>
                                            <asp:DropDownList ID="DDLAcumula" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="1" Text="SI"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="NO"></asp:ListItem>
                                            </asp:DropDownList>
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
        function abrirModal(id, descripcion, tipoLicencia, habiles, tipo, cantDias, masiva, sexo, fracciona, acumula) {
            $('#modalLicencia').modal('show');
            //ID
            $("#ContentPlaceHolder1_hId").val(id);
            //DESCRIPCION
            $("#ContentPlaceHolder1_txtDescripcion").val(descripcion);
            //TIPO LICENCIA
            $("#ContentPlaceHolder1_DDLTipo").val(tipoLicencia);
            //TIPO DE DIAS
            if (habiles)
                $("#ContentPlaceHolder1_DDLDias").val(1);
            else
                $("#ContentPlaceHolder1_DDLDias").val(0);
            //FORMA DE CALCULO
            if (tipo == "False") {
                $("#ContentPlaceHolder1_select").val(0);
                $('#cant_dias').hide();
            }
            else {
                $("#ContentPlaceHolder1_select").val(1);
                $('#cant_dias').show();
            }
            //CANTIDAD DE DIAS
            $("#ContentPlaceHolder1_txtCantDias").val(cantDias);
            //MASIVA
            if (masiva == "False") {
                $("#ContentPlaceHolder1_DDLMasiva").val(0);
            }
            else {
                $("#ContentPlaceHolder1_DDLMasiva").val(1);
            }
            //APLICA A
            $("#ContentPlaceHolder1_DDLSexo").val(sexo);
            //FRACCIONA
            if (fracciona == "False") {
                $("#ContentPlaceHolder1_DDLFracciona").val(0);
            }
            else {
                $("#ContentPlaceHolder1_DDLFracciona").val(1);
            }
            //ACUMULA
            if (acumula == "False") {
                $("#ContentPlaceHolder1_DDLAcumula").val(0);
            }
            else {
                $("#ContentPlaceHolder1_DDLAcumula").val(1);
            }
        }
        jQuery(document).ready(function ($) {


            $('#' + '<%=gvLicencias.ClientID %>').DataTable(
            );
            $('body').on('change', '#ContentPlaceHolder1_select', function () {
                var f = this.value;
                $('#show_selected').val(this.value);
                if (f == "1")
                    $('#cant_dias').show();
                else
                    $('#cant_dias').hide();
            });
        });
    </script>
</asp:Content>
