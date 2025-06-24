<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printFichadas.aspx.cs" Inherits="HHRR.Reportes.printFichadas" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #Line23 {
            display: none;
        }

        .crystalstyle {
            padding: 0 !important;
            margin: 0 !important;
            margin-right:10px !important;
        }
    </style>

</head>
<body onload="ocultar();">
    <form id="form1" runat="server">
    <script src="../App_Themes/plugins/jQuery/jQuery-2.1.4.min.js"></script>

        <div id="divFichadas" runat="server">
        </div>
    </form>
</body>
</html>
