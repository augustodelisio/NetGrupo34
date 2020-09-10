<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="UI.Web.Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="ID">
                    <Columns>
                        <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                        <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                        <asp:BoundField HeaderText="Clave" DataField="Clave" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                        <asp:BoundField HeaderText="Persona" DataField="IdPersona" />
                        <asp:BoundField HeaderText="Tipo Usuario" DataField="IdTipoUsuario" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="formPanel" Visible="false" runat="server">
                <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
                <asp:TextBox ID="legajoTextBox" runat="server"></asp:TextBox>
                <asp:Label ID="usuarioLabel" Visible="false" runat="server" Text="Nombre de Usuario: "></asp:Label>
                <asp:TextBox ID="usuarioTextBox" runat="server"></asp:TextBox>
                <asp:Label ID="claveLabel" runat="server" Text="Clave:"></asp:Label>
                <asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>
                <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: ">
                </asp:Label>
                <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server">
                </asp:TextBox>
                <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado:" ></asp:Label>
                <asp:CheckBox ID="CheckBox1" runat="server"> </asp:CheckBox>
            </asp:Panel>
            
        </div>
    </form>
</body>
</html>
