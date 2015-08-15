<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="Chatter.Pages.AppPages.Posts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Inlägg</h1>
    <asp:ListView ID="ListView1" runat="server"
        ItemType="Chatter.Model.BLL.BlogPost"
        SelectMethod="BlogPostListView_GetData"
        DataKeyNames="UserId">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <asp:Label ID="UserNameLabel" runat="server" Text='<%#: GetUser(Item.UserId).UserName %>' />
            </div>
            <div>
                <asp:Label ID="TitleLabel" runat="server" Text='<%#: Item.Title %>' />
            </div>
            <div>
                <asp:Label ID="MessageLabel" runat="server" Text='<%#: Item.Message %>' />
            </div>
            <div>
                <asp:Label ID="DateLabel" runat="server" Text='<%#: Item.Date %>' />
            </div>
        </ItemTemplate>

    </asp:ListView>
</asp:Content>
