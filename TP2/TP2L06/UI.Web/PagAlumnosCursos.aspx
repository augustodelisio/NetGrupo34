<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagAlumnosCursos.aspx.cs" Inherits="UI.Web.AlumnosCursos" %>

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

        <div class="bloqueAdminIncial">

            <asp:Panel ID="panelAdmin" Visible="false" runat="server" CssClass="formulario">


                <asp:Label ID="preguntaLabel" runat="server" Text="Desea ingresar docentes o alumnos?"></asp:Label>


                <asp:RadioButtonList ID="seleccionRadioButtonList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="seleccionRadioButtonList_SelectedIndexChanged">
                    <asp:ListItem Value="2">Alumno</asp:ListItem>
                    <asp:ListItem Value="3">Docente</asp:ListItem>
                </asp:RadioButtonList>


                <asp:Panel ID="botoneraSeleccionAdmin" runat="server" Width="268px">
                    <asp:Button ID="aceptarSeleccionAdminLinkButton" runat="server" Text="Aceptar" CssClass="botonera" OnClick="aceptarSeleccionAdminLinkButton_Click" />
                    <asp:Button ID="cancelarSeleccionAdminLinkButton" runat="server" Text="Cancelar" CssClass="botonera" OnClick="cancelarSeleccionAdminLinkButton_Click" />
                </asp:Panel>


            </asp:Panel>

        </div>

        <div class="bloqueHijo" style="margin-top: 100px;">

            <asp:Panel ID="panelDDL" Visible="false" runat="server" CssClass="formulario">

                <asp:DropDownList ID="DocentesDDL" runat="server" CssClass="formItem" DataSourceID="DocentesDataSource"
                    DataTextField="legajo" DataValueField="legajo" Width="264px">
                </asp:DropDownList>


                <asp:SqlDataSource ID="DocentesDataSource" runat="server" ConnectionString="Data Source=localhost\SqlExpress;Initial Catalog=Academia;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [legajo] FROM [usuarios] WHERE ([id_tipo_usuario] = @id_tipo_usuario)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="3" Name="id_tipo_usuario" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>



                <asp:DropDownList ID="AlumnosDDL" runat="server" CssClass="formItem" DataSourceID="AlumnosDataSource"
                    DataTextField="legajo" DataValueField="id_usuario" Width="268px">
                </asp:DropDownList>


                <asp:SqlDataSource ID="AlumnosDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringExpress %>" SelectCommand="SELECT [legajo], [id_usuario] FROM [usuarios] WHERE ([id_tipo_usuario] = @id_tipo_usuario)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="2" Name="id_tipo_usuario" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>


                <asp:Panel ID="panelSeleccionDeUsuario" Visible="false" runat="server" CssClass="botonera">
                    <asp:LinkButton ID="ingresarUsuarioLinkButton" runat="server" OnClick="ingresarUsuarioLinkButton_Click" CssClass="boton">Inscribirse</asp:LinkButton>
                    <asp:LinkButton ID="cancelarUsuarioLinkButton" runat="server" OnClick="cancelarUsuarioLinkButton_Click" CssClass="boton">Cancelar</asp:LinkButton>
                </asp:Panel>



            </asp:Panel>


        </div>



        <div class="bloqueHijo">

            <asp:Panel ID="gridPanel" Visible="false" runat="server" CssClass="tabla">

                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" Width="119%" HeaderStyle-Height="40px"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="id_materia" OnSelectedIndexChanged="gridView_SelectedIndexChanged" Height="214px" DataSourceID="MateriasDataSource">

                    <Columns>
                        <asp:CommandField SelectText="-->" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="Id Materia" DataField="id_materia" InsertVisible="False" ReadOnly="True" SortExpression="id_materia" />
                        <asp:BoundField DataField="desc_materia" HeaderText="Descripcion" SortExpression="desc_materia" />
                        <asp:BoundField DataField="hs_semanales" HeaderText="Hs Semanales" SortExpression="hs_semanales" />
                        <asp:CheckBoxField DataField="habilitado" HeaderText="Habilitado" SortExpression="habilitado" />
                        <asp:BoundField DataField="hs_totales" HeaderText="Hs Totales" SortExpression="hs_totales" />
                        <asp:BoundField DataField="id_plan" HeaderText="Id Plan" SortExpression="id_plan" />
                    </Columns>

                    <HeaderStyle Height="40px" />

                    <SelectedRowStyle BackColor="#9BBCFF" ForeColor="Black" />
                </asp:GridView>
                <asp:SqlDataSource ID="MateriasDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringExpress %>" SelectCommand="SELECT [id_materia], [desc_materia], [hs_semanales], [habilitado], [hs_totales], [id_plan] FROM [materias] WHERE ([habilitado] = @habilitado)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="habilitado" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:Panel ID="gridActionsPanel" Visible="false" runat="server" CssClass="botonera">
                    <asp:LinkButton ID="seleccionarMateriaLinkButton" runat="server" OnClick="seleccionarMateriaLinkButton_Click" CssClass="boton">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="cancelarMateriaLinkButton" runat="server" OnClick="cancelarMateriaLinkButton_Click" CssClass="boton">Cancelar</asp:LinkButton>
                </asp:Panel>

            </asp:Panel>


        </div>

        <div class="bloqueHijo">

            <asp:Panel ID="comisionPanel" Visible="false" runat="server" CssClass="tabla">

                <asp:GridView ID="gridComision" runat="server"
                    AutoGenerateColumns="False" Width="100%" HeaderStyle-Height="40px"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="IdComision" OnSelectedIndexChanged="gridComision_SelectedIndexChanged">

                    <Columns>

                        <asp:CommandField SelectText="-->" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="Comision" DataField="Descripcion" />
                        <asp:BoundField HeaderText="ID" DataField="IdComision" />
                        <asp:BoundField HeaderText="Año de cursado" DataField="AnioEspecialidad" />

                    </Columns>

                    <SelectedRowStyle BackColor="#9BBCFF" ForeColor="Black" />


                </asp:GridView>


                <asp:DropDownList ID="cargosDDL" Visible="false" runat="server">

                    <asp:ListItem Selected="True" Value="1"> Docente Práctica </asp:ListItem>
                    <asp:ListItem Value="2"> Docente Teoría </asp:ListItem>
                    <asp:ListItem Value="3"> Jefe de cátedra </asp:ListItem>


                </asp:DropDownList>



                <asp:Panel ID="panelInscripcionCursado" Visible="false" runat="server" CssClass="botonera">
                    <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="boton">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="cancelarCursoLinkButton" runat="server" OnClick="cancelarCursoLinkButton_Click" CssClass="boton">Cancelar</asp:LinkButton>
                </asp:Panel>


            </asp:Panel>



        </div>

    </div>

</asp:Content>







