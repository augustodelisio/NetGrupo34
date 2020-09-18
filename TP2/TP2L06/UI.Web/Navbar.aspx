<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Navbar.aspx.cs" Inherits="UI.Web.PagPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <title></title>
    <style>
        .auto-style1 {
            width: 100%;
            max-width: 1140px;
            min-width: 992px;
            height: 58px;
            margin-left: auto;
            margin-right: auto;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</head>
<body style="height: 230px">
    <form id="form1" runat="server" class="form-inline">
        <div class="auto-style1">
            <nav class="navbar navbar-expand-xl bg-dark navbar-dark fixed-top">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Inicio</a>
                    </li>
                    <!-- Dropdown -->
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Usuarios
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                            <a class="dropdown-item" href="Usuario.aspx">Ver Usuarios</a>
                            <a class="dropdown-item" href="TipoUsuario.aspx">Tipos de Usuarios</a>
                        </div>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Persona.aspx">Personas</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Materias</a>
                    </li>
                </ul>
                <ul class="navbar-nav">
                    <li class="nav-item form-inline">
                        <a id="usuarioNavItem" class="nav-link" href="#">Usuario</a>
                    </li>
                </ul>
            </nav>
        </div>
    </form>

    <h1>Pagina Academica</h1>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>
