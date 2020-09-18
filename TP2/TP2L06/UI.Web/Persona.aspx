<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Persona.aspx.cs" Inherits="UI.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                        <asp:BoundField HeaderText="Email" DataField="Telefono" />
                        <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
         <asp:Panel ID="formPanel" Visible="false" runat="server">
                
                <asp:Label ID="nombrePersona" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
                
                <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
                
                <asp:Label ID="direccionLabel" runat="server" Text="Direccion: "></asp:Label>
                <asp:TextBox ID="direccionTextBox" runat="server"></asp:TextBox>
                               
                <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>

                <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                <asp:TextBox ID="fechaNacimientoTextBox" runat="server"></asp:TextBox>

                <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado:" ></asp:Label>
                <asp:CheckBox ID="habilitadoCheckBox" runat="server"> </asp:CheckBox>
            </asp:Panel>


        <asp:Panel ID="gridActionsPanel" runat="server">
             <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
             <asp:LinkButton ID="elimiarLinkButton" runat="server" OnClick="elimiarLinkButton_Click">Eliminar</asp:LinkButton>
             <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>

        <asp:Panel ID="formActionPanel" runat="server">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
    </form>
</body>
</html>
