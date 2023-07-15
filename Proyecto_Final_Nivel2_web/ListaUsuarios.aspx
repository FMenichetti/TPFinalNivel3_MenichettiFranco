<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Proyecto_Final_Nivel2_web.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gvListaUsuarios" runat="server" CssClass="table mt-4" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="gvListaUsuarios_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Pass" DataField="Pass" />
            <asp:BoundField HeaderText="Admin" DataField="Admin" />
            <asp:CommandField HeaderText="Editar/Eliminar" SelectText="📑" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>

    <asp:Button Text="Atras" runat="server" Id="btnAtras" OnClick="btnAtras_Click" CssClass="btn btn-outline-dark" />

</asp:Content>
