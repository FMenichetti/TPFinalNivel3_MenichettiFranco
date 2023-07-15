<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto_Final_Nivel2_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />



    <div class="row">
        <div class=" col-2 ">
            <asp:Label Text="Categoria" ID="lblCategoria" runat="server" />
            <asp:DropDownList CssClass="form-select" ID="ddlCategoria" runat="server">
            </asp:DropDownList>
        </div>
        <div class=" col-2">
            <asp:Label Text="Marca" ID="lblMarca" runat="server" />
            <asp:DropDownList CssClass="form-select" ID="ddlMarca" runat="server">
            </asp:DropDownList>
        </div>
        <div class="col-5 d-flex mt-4">
            <form class="d-flex" role="search">

                <asp:TextBox ID="txtBuscar" CssClass="form-control me-2" AutoCompleteType="Search" runat="server" />
                <asp:Button Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-outline-secondary" runat="server" />
            </form>
        </div>
        <div class="col-3 mt-4 ">
            <asp:Button Text="Administrador" ID="btnAdinistrador" OnClick="btnAdinistrador_Click" CssClass="form-control btn btn-outline-secondary" runat="server" />
        </div>
    </div>


    <div class="row row-cols-1 row-cols-md-4 g-4">
      <%--  <%foreach (Dominio.Articulo item in Lista)
            {
        %>--%>
        <%-- <div class="">
            <div class="card  m-3">
                <img src="<%:item.ImagenUrl %>" class="card-img-top" id="imgArticulo" height="200" width="200" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:item.Nombre %>  </h5>
                    <p class="card-text"><%:item.Descripcion %></p>
                    <a href="DetalleArticulo.aspx?Id=<%:+item.Id %>" class="btn btn-outline-primary">Ver mas...</a>
                   
                </div>
            </div>
        </div>--%>
       <%-- <%
            }
        %>--%>

        <asp:Repeater runat="server" ID="IdRepeater">
            <ItemTemplate>

                <div class="">
                    <div class="card  m-3">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" id="imgArticulo" height="200" width="200" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%>  </h5>
                            <p class="card-text"><%#Eval("Descripcion")%> </p>
                            <asp:Label class="card-text" Text='<%#Eval("Precio")%>' ID="lblPrecio" runat="server" />
                            <br />
                            <asp:HyperLink  NavigateUrl='<%# "DetalleArticulo.aspx?Id="+Eval("Id")%>' Text="Detalles..." CssClass="btn-outline-light" runat="server" />

                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
        <asp:Label ID="lblBusqueda" Text="No se encontraron articulos relacionados con su busqueda..intente con otros filtros" runat="server" /></asp:label>
    </div>







</asp:Content>
