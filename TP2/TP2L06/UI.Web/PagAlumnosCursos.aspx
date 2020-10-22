<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagAlumnosCursos.aspx.cs" Inherits="UI.Web.AlumnosCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">

    <div class="bloquePadre">   
        <div class="bloqueHijo">  
            
            <asp:Panel ID="gridPanel" runat="server" CssClass="tabla">
                
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-Height="40px"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="IdMateria" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    
                    <Columns>
                        <asp:CommandField SelectText="-->" ShowSelectButton="True"/>
                        <asp:BoundField HeaderText="Materia" DataField="Descripcion" />
                    </Columns>

                    <SelectedRowStyle BackColor="#9BBCFF" ForeColor="Black" />
                </asp:GridView>
            </asp:Panel>

            <asp:Panel ID="gridActionsPanel" runat="server" CssClass="botonera">
                <asp:LinkButton ID="inscribirseLinkButton" runat="server" OnClick="inscribirseLinkButton_Click" CssClass="boton">Inscribirse</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="boton">Cancelar</asp:LinkButton>
            </asp:Panel>
        </div>

        <div class="bloqueHijo">

            <asp:Panel ID="comisionPanel" Visible="false" runat="server" CssClass="tabla">

                <asp:GridView ID="gridComision" runat="server" 
                    AutoGenerateColumns="false" Width="100%" HeaderStyle-Height="40px"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="IdComision" OnSelectedIndexChanged="gridComision_SelectedIndexChanged">

                    <Columns>

                        <asp:CommandField SelectText="-->" ShowSelectButton="True"/>
                        <asp:BoundField HeaderText="Comision" DataField="Descripcion" />
                        <asp:BoundField HeaderText="ID" DataField="IdComision" />
                        <asp:BoundField HeaderText="Año de cursado" DataField="AnioEspecialidad" />
                        
                    </Columns>


               </asp:GridView>

            <asp:Panel ID="panelInscripcionCursado" runat="server" CssClass="botonera">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="boton">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarCursoLinkButton" runat="server" OnClick="cancelarCursoLinkButton_Click" CssClass="boton">Cancelar</asp:LinkButton>
            </asp:Panel>


            </asp:Panel>





            </asp:GridView>

        </div>
    
    </div>

</asp:Content>







