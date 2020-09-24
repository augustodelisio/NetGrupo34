<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">

    <title></title>
    <style type="text/css">
        
        body {
            background-color:lightblue;
        }
        #miTabla {
            width:80%;
        }
        #divTabla {
            display: flex;
            justify-content: center;
            align-items: center;
            width:30%;
            margin-top:10%;
            margin-left:35%;
            margin-right:35%;
            border: 3px solid gray;
        }
        .auto-style2 {
            width: 38%;
            height: 214px;
        }
        .auto-style7 {
            width: 118px;
            height: 45px;
        }
        .auto-style10 {
            height: 23px;
            width: 195px;
        }
        .auto-style11 {
            width: 195px;
        }

        .auto-style12 {
            height: 23px;
            width: 120px;
        }
        .auto-style13 {
            width: 100px;
        }
        .auto-style14 {
            width: 45%
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divTabla" class="auto-style14 p-3 mb-2 bg-light text-dark">
            <table id="miTabla"  class="auto-style2">
                <tr>
                    <td class="auto-style12 text-center" colspan="2" style="padding-bottom:30px;">
                        <asp:Label ID="lblBienvenido" runat="server" Text="¡Bienvenido al Sistema!"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style13 text-right">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                    </td>
                    <td class="auto-style11 text-right">
                        <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7 text-right">
                        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                    </td>
                    <td class="auto-style11 text-right">
                        <asp:TextBox ID="txtClave" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style11 text-right">

                        <asp:Button ID="btnIngresar" CssClass="btn-primary" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13" style="padding-top:20px;">
                        <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi Clave" OnClick="lnkRecordarClave_Click"></asp:LinkButton>

                    </td>
                    <td class="auto-style11">&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>
