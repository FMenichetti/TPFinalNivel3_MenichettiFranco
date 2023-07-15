<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Proyecto_Final_Nivel2_web.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Bienvenido/a a la pagina de registro.</h3>
    <div class="m-3 ">

        <div class="col-md-4 ">
            <asp:Label Text="Email" ID="lblEmail"  runat="server" />
            <asp:TextBox runat="server"  ID="txtEmail" CssClass="form-control" />
            <asp:RegularExpressionValidator ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                ErrorMessage="*** Solo Formato Email ***" ForeColor="Red" ControlToValidate="txtEmail" runat="server"  />
        </div>
        <div class="col-md-4">
            <asp:Label Text="Contraseña" ID="lblContraseña"  runat="server" />
            <asp:TextBox runat="server"  ID="txtContraseña" CssClass="form-control" TextMode="Password" />
        </div>

        <div >
            
            <asp:Button Text="Aceptar" ID="btnAceptar"  OnClick="btnAceptar_Click" CssClass="btn btn-primary mt-3" runat="server" />
            <asp:Label Text="Por favor complete todos los campos" ForeColor="Red" ID="lblCompletarCampos" runat="server" Visible="false" />
        </div>

    </div>

</asp:Content>
