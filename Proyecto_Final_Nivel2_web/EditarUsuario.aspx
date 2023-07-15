<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="Proyecto_Final_Nivel2_web.EditarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">

        <div class="col-5 m-3">
            <div class="mb-3 " >
                <asp:Label Text="Id" ID="lblId" runat="server" />
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" />

            </div>
            <div class="mb-3">
                <asp:Label Text="Apellido" ID="lblApellido" runat="server" />
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" ID="lblNombre" runat="server" />
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <%--<div class="mb-3">
                <asp:Label Text="Email" ID="lblEmail" runat="server" />
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="Llene este campo con un email valido" ControlToValidate="txtEmail" runat="server" ValidationExpression="^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$" />
            </div>--%>
            <div class="mb-3">
                <asp:Label Text="Password" ID="lblPass" runat="server" />
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control"  />
            </div>
            <div class="mb-3">
                <%--<asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-outline-dark" runat="server" OnClick="btnAceptar_Click" visible="true"/>--%>
                <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-outline-dark" runat="server" OnClick="btnCancelar_Click" />
              <%-- <%if (modificar == true)
                   {%>--%>
                <asp:Button Text="Modificar" ID="btnModificar" ForeColor="Black" BorderColor="Black" CssClass="btn btn-outline-warning" runat="server" OnClick="btnModificar_Click"/>
                <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-outline-danger" runat="server" OnClick="btnEliminar_Click"/>
             <%--  <%} %>--%>
                <%if (confirmarEliminar == true)
                    { %>
                <asp:CheckBox Text="Confirma Eliminacion" ID="chkConfirmaEliminacion" runat="server" />
                 <asp:Button Text="Confirmar Eliminacion" ID="idConfirmarEliminar" CssClass="btn btn-outline-danger" OnClick="idConfirmarEliminar_Click" runat="server" />
                <%} %>
            </div>
            
        </div>

        <div class="col-6 m-3">
           
           
            <updatepanel>
                <div class="mb-3">
                    <asp:Label Text="Imagen" ID="lblImagen" runat="server" />
                    <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control " OnTextChanged="txtImagen_TextChanged" AutoPostBack="true" />
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server"
                        BorderColor="Black" BorderStyle="Double" ID="ImgUrl" Width="300px" Height="300px" CssClass="mt-3"/>
                </div>
            </updatepanel>

        </div>
    </div>

</asp:Content>
