<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Proyecto_Final_Nivel2_web.Cards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="idRepeater" runat="server">
            <ItemTemplate>
                <div class="">
                    <div class="card  m-3">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" height="300" width="300" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <asp:Button Text="Eliminar favorito" ID="btnEliminarFavorito" CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" runat="server" OnClick="btnEliminarFavorito_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
</asp:Content>
