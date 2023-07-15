<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Proyecto_Final_Nivel2_web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <asp:Image   ImageUrl="https://images.unsplash.com/photo-1562113530-57ba467cea38?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=399&q=80" ID="imgPerfil" class="rounded" Height="300px" Width="300px" runat="server" />
        </br>
        <asp:Label ID="lblNombreImagen" Text="Nombre" runat="server" />
    </div>
    <div class="row">

    <div class="col-5  m-3 " >
        <asp:Label Text="Email" ID="lblEmail" runat="server"  />
        <asp:TextBox ID="txtEmail" CssClass="form-control" Enabled="false" runat="server" />
        <br />
        <asp:Label Text="Nombre" ID="lblNombre" runat="server" />
        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
        <br />
        <asp:Label Text="Apellido" ID="lblApellido" runat="server" />
        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
    </div>

     <div class="col-5 m-3">
        <asp:Label Text="Url Imagen" ID="lblUrlImagen" runat="server" />
        <asp:TextBox ID="txtUrlImagen" CssClass="form-control" runat="server" OnTextChanged="txtUrlImagen_TextChanged"/>
       <%-- <br />
        <asp:Label Text="Contraseña" ID="lblContraseña" runat="server" />
        <asp:TextBox ID="txtContraseña" CssClass="form-control " TextMode="Password" runat="server" />
         <asp:Label Text="Confirme su contraseña" ID="lblContraseña2" runat="server" />
         <asp:TextBox ID="txtContraseña2" CssClass="form-control " runat="server" TextMode="Password"/>
         <asp:Label Text="No se actualizaron los datos, las contraseñas no coinciden" CssClass="form-control" ForeColor="Red" ID="lblErrorContraseña" Visible="false" runat="server" />--%>
         <br />
         <asp:Button Text="Actualizar datos" CssClass="btn btn-outline-dark" ID="btnActualizar" OnClick="btnActualizar_Click" runat="server" />
        
    </div>
    </div>




</asp:Content>
