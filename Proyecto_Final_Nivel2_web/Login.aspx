<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_Final_Nivel2_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Bienvenido/a a la pagina de Ingreso, Por favor logueate.</h3>
    <div class="m-3 ">

        <div class="col-md-4 ">
            <asp:Label Text="Email"  ID="lblEmail"  runat="server" />
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            <asp:RegularExpressionValidator ForeColor="Red" ErrorMessage="***Llenar este campo con un email valido***" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" ControlToValidate="txtEmail" runat="server" />

        </div>
        <div class="col-md-4">
            <asp:Label Text="Contraseña"  ID="lblContraseña"  runat="server" />
            <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control"  TextMode="Password" />
        </div>

        <div >
            
            <asp:Button Text="Aceptar" ID="btnAceptar"  OnClick="btnAceptar_Click" CssClass="btn btn-primary mt-3" runat="server" />
            <asp:Label id="lblIncorrecto" ForeColor="Red" Text="Usuario o contraseña incorrectos" runat="server" />
            </div>

    </div>

</asp:Content>
