<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HHRR.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Municipalidad de Villa Allende</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
    <!-- Bootstrap 3.3.4 -->
    <link href="App_Themes/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome Icons -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="App_Themes/dist/css/AdminLTE.css?v=1.1" rel="stylesheet" />
    <!-- iCheck -->
    <link href="App_Themes/plugins/iCheck/square/blue.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        body {
            background: url(App_Themes/images/FONDO2.jpeg) no-repeat;
            background-size: cover;
        }
    </style>
    <link href="App_Themes/bootstrap/css/style2.css" rel="stylesheet" />
    <link href="App_Themes/bootstrap/css/color-1.css" rel="stylesheet" />
    <link href="App_Themes/bootstrap/css/color-switcher.css" rel="stylesheet" />
</head>
<body class="login-page">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hCuit" runat="server" />
        <div class="row" style="margin-top: 30px; margin-bottom: 5px; margin-left: 10px;">
            <div class="col-md-12">
                <a href="index.aspx">
                    <img src="App_Themes/images/GESTION vertical 2.png" width="200" />
                </a>
            </div>
        </div>
        <div class="login-box" style="margin: 3% auto;">

            <!-- /.login-logo -->
            <div class="login-box-body" style="background-color: white; border-radius: 20px; text-align:center;">
                <div class="login-logo">
                    <img src="App_Themes/images/logo3.png" style="width: 30%;" />
                </div>
                <p class="login-box-msg" style="color: #424344; font-size: 20px;"><strong>Portal del Empleado</strong></p>
               
                <div id="divLogIn" runat="server">
                    <p>¡Gracias por utilizar Empleado Digital!</p>
                    <p>Para volver a ingresera inicie sesion en Vecino Digital</p>
                    <a href="https://vecino.villaallende.gov.ar">VELCINO DIGITAL</a>
                </div>

            </div>
            <!-- /.login-box-body -->
        </div>
        <!-- /.login-box -->
    </form>
</body>
</html>
