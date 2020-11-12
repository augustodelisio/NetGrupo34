<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagBajaInscripcion.aspx.cs" Inherits="UI.Web.PagBajaInscripcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            float: left;
            width: 309px;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">

    <div class="bloquePadre">


        <div class="bloqueHijo">

            <asp:Panel ID="gridPanel" Visible="false" runat="server" CssClass="tabla">

                <asp:GridView ID="gridInscripciones" runat="server" AutoGenerateColumns="False" Width="119%" HeaderStyle-Height="40px"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="id_materia" Height="214px"">

                    <Columns>
                        <asp:CommandField SelectText="-->" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="id_materia" DataField="id_materia" InsertVisible="False" ReadOnly="True" SortExpression="id_materia" />
                        <asp:BoundField DataField="desc_materia" HeaderText="desc_materia" SortExpression="desc_materia" />
                        <asp:BoundField DataField="hs_semanales" HeaderText="hs_semanales" SortExpression="hs_semanales" />
                        <asp:CheckBoxField DataField="habilitado" HeaderText="habilitado" SortExpression="habilitado" />
                        <asp:BoundField DataField="hs_totales" HeaderText="hs_totales" SortExpression="hs_totales" />
                        <asp:BoundField DataField="id_plan" HeaderText="id_plan" SortExpression="id_plan" />
                    </Columns>

                    <HeaderStyle Height="40px" />

                    <SelectedRowStyle BackColor="#9BBCFF" ForeColor="Black" />
                </asp:GridView>


                <asp:Panel ID="gridActionsPanel" Visible="false" runat="server" CssClass="botonera">
                    <asp:LinkButton ID="seleccionarMateriaLinkButton" runat="server" OnClick="seleccionarMateriaLinkButton_Click" CssClass="boton">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="cancelarMateriaLinkButton" runat="server" OnClick="cancelarMateriaLinkButton_Click" CssClass="boton">Cancelar</asp:LinkButton>
                </asp:Panel>

            </asp:Panel>


        </div>


    </div>

</asp:Content>
