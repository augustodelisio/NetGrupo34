<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TipoUsuario.aspx.cs" Inherits="UI.Web.TipoUsuario" %>

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
                    DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="ID Tipo Usuario" DataField="IdTipoUsuario" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="formPanel" Visible="false" runat="server">
                
                <asp:Label ID="idTipoUsuarioLabel" runat="server" Text="ID Tipo Usuario: "></asp:Label>
                <asp:TextBox ID="idTipoUsuarioTextBox" runat="server"></asp:TextBox>
                
                <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
                <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
                                              
                
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
            
        </div>
    </form>
</body>
</html>




