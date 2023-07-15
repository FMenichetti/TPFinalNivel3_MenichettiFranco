<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="Proyecto_Final_Nivel2_web.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:GridView ID="GridView1" runat="server" CssClass="table mt-4" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Editar/Eliminar" SelectText="📑" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>

    <div class="col-6">
        <div class=" mb-3">
            <asp:Button Text="Nuevo Producto" ID="Button1" runat="server" OnClick="btnNuevo_Click" CssClass="btn btn-outline-dark"  />
            <asp:Button Text="Lista usuarios" ID="btnUsuarios" runat="server" OnClick="btnUsuarios_Click" CssClass="btn btn-outline-dark"  />
        </div>
    </div>

</asp:Content>
