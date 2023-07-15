<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Proyecto_Final_Nivel2_web.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="Scrpmanager" runat="server"></asp:ScriptManager>

    <div class="row">

        <div class="col-5 m-3">
            <div class="mb-3 ">
                <asp:Label Text="Id" ID="lblId" runat="server" />
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" />

            </div>
            <div class="mb-3">
                <asp:Label Text="Codigo" ID="lblCodigo" runat="server" />
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" ID="lblNombre" runat="server" />
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>




            <div class="mb-3">
                <asp:Label Text="Precio" ID="lblPrecio" runat="server" />
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" AutoPostBack="false" />
                <asp:RegularExpressionValidator ErrorMessage="***Numeros enteros o decimales solamente***" ControlToValidate="txtPrecio" runat="server" ValidationExpression="^$|^(0|\d+(,\d+)?)$" />
               
            </div>


            <div class="mb-3">
                <asp:Label Text="Descripcion" ID="lblDescripcion" runat="server" />
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" />
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>


            
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-outline-dark" runat="server" OnClick="btnAceptar_Click" Visible="true" />
                <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-outline-dark" runat="server" OnClick="btnCancelar_Click" />
                <%if (modificar == true)
                    {%>
                <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn btn-outline-warning" BorderColor="Black" ForeColor="Black" runat="server" OnClick="btnModificar_Click" />
                <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-outline-danger" runat="server" OnClick="btnEliminar_Click" />
                <%} %>
               <%if (confirmaEliminacion == true)
                   { %>
                <br />
                <asp:Button Text="Confirma Eliminacion" ID="btnConfirmaEliminacion" runat="server" CssClass="btn btn-outline-danger" OnClick="btnConfirmaEliminacion_Click" />
                <asp:CheckBox Text="Confirme eliminacion" ID="chkConfirmacion"  runat="server" />
               <%} %>
            </div>

    </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <div class="col-6 m-3">
            <div class="mb-3">
                <asp:Label Text="Categoria" ID="lblCategoria" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Marca" ID="lblMarca" runat="server" />
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <updatepanel>
                <div class="mb-3">
                    <asp:Label Text="Imagen" ID="lblImagen" runat="server" />
                    <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control " OnTextChanged="txtImagen_TextChanged" AutoPostBack="true" />
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server"
                        BorderColor="Black" BorderStyle="Double" ID="ImgUrl" Width="300px" Height="300px" CssClass="mt-3" />
                </div>
            </updatepanel>

        </div>
    </div>
</asp:Content>


