<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagAlumnosCursos.aspx.cs" Inherits="UI.Web.AlumnosCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">

    <div class="bloquePadre">   
        
        <div class="bloqueAdminIncial">

            <asp:Panel ID="panelAdmin" Visible="false" runat="server" CssClass="formulario">


                <asp:Label ID="preguntaLabel" runat="server" Text="Desea ingresar docentes o alumnos?"></asp:Label>
             

                <asp:RadioButtonList ID="seleccionRadioButtonList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="seleccionRadioButtonList_SelectedIndexChanged">
                    <asp:ListItem Value="2">Alumno</asp:ListItem>
                    <asp:ListItem Value="3">Docente</asp:ListItem>
                </asp:RadioButtonList>
                
                
                <asp:Panel ID="botoneraSeleccionAdmin" runat="server">
                    <asp:Button ID="aceptarSeleccionAdminLinkButton" runat="server" Text="Aceptar" CssClass="botonera" />
                    <asp:Button ID="cancelarSeleccionAdminLinkButton" runat="server" Text="Cancelar" CssClass="botonera"/>
                </asp:Panel>


            </asp:Panel>

        </div>
        
        <div class="bloqueDDLs">
            
            <asp:Panel ID="panelDDL" Visible="false" runat="server" CssClass="formulario">
            
            <asp:DropDownList ID="DocentesDDL" runat="server" CssClass="formItem" DataSourceID="AcademiaDataSource" 
                DataTextField="legajo" DataValueField="legajo">            
            </asp:DropDownList>

            
            <asp:SqlDataSource ID="AcademiaDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:AcademiaConnectionString %>
                " SelectCommand="SELECT [legajo] FROM [usuarios] WHERE (([id_tipo_usuario] = @id_tipo_usuario) AND ([habilitado] = @habilitado))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="3" Name="id_tipo_usuario" Type="Int32" />
                    <asp:Parameter DefaultValue="True" Name="habilitado" Type="Boolean" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>



           <asp:DropDownList ID="AlumnosDDL" runat="server" CssClass="formItem" DataSourceID="AcademiaDataSource" 
                DataTextField="legajo" DataValueField="legajo">            
            </asp:DropDownList>

            
            <asp:SqlDataSource ID="AlumnosDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:AcademiaConnectionString %>
                " SelectCommand="SELECT [legajo] FROM [usuarios] WHERE (([id_tipo_usuario] = @id_tipo_usuario) AND ([habilitado] = @habilitado))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="2" Name="id_tipo_usuario" Type="Int32" />
                    <asp:Parameter DefaultValue="True" Name="habilitado" Type="Boolean" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server"></asp:SqlDataSource>



          </asp:Panel>
            
            
       </div>


        
        <div class="bloqueSeleccionMateria">  
            
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

        <div class="bloqueSeleccionComision">

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







