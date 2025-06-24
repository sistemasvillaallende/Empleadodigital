<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="CertNoAsignaciones.aspx.cs" 
    Inherits="HHRR.Certificados.CertNoAsignaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <title></title>
    <link href="../App_Themes/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../App_Themes/css/font-awesome.min.css" rel="stylesheet" />
    <style media="print">
        .impresora{
            display:none;
        }
    </style>
    <style>
        .col-print-1 {
            width: 8%;
            float: left;
        }

        .col-print-2 {
            width: 16%;
            float: left;
        }

        .col-print-3 {
            width: 25%;
            float: left;
        }

        .col-print-4 {
            width: 33%;
            float: left;
        }

        .col-print-5 {
            width: 42%;
            float: left;
        }

        .col-print-6 {
            width: 50%;
            float: left;
        }

        .col-print-7 {
            width: 58%;
            float: left;
        }

        .col-print-8 {
            width: 66%;
            float: left;
        }

        .col-print-9 {
            width: 75%;
            float: left;
        }

        .col-print-10 {
            width: 83%;
            float: left;
        }

        .col-print-11 {
            width: 92%;
            float: left;
        }

        .col-print-12 {
            width: 100%;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            function imprimir() {
                window.print();
            }
        </script>
        <div class="container" style="margin-top: 30px;">
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <div class="col-print-12" style="text-align: center;">
                        <img src="../App_Themes/images/LogoGestion.png?v=1" style="height:55px; margin-bottom:25px;"/>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 col-md-offset-2" style="text-align: center;">
                    <h3>MUNICIPALIDAD DE VILLA ALLENDE</h3>
                    <h3>DIRECCION DE RR.HH.</h3>
                    <hr style="border-top: 1px solid #ccc;" />
                </div>
                <div class="col-md-8 col-md-offset-2" id="divCert" runat="server" style="text-align: justify;">
                </div>
                <div class="col-md-8 col-md-offset-2" style="text-align: right;">
                    <button class="btn btn-default impresora" onclick="imprimir()">
                        <span class="fa fa-print" style="font-size: 50px;"></span>
                    </button>
                    <a class="btn btn-default impresora" href="Certificados.aspx">
                        <span class="fa fa-sign-out" style="font-size: 50px;"></span>
                    </a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
