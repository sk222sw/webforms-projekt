<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="Chatter.Pages.AppPages.Posts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Inlägg</h2>
    <asp:ListView ID="ListView1" runat="server"
        ItemType="Chatter.Model.BLL.BlogPost"
        SelectMethod="BlogPostListView_GetData"
        DataKeyNames="BlogPostId"
        DeleteMethod="BlogPostListView_DeleteMethod">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <article>
                <div id="title">
                    <h3>
                        <asp:Label ID="TitleLabel" runat="server" Text='<%#: Item.Title %>' />
                    </h3>
                </div>
                <div id="message">
                    <asp:Label ID="MessageLabel" runat="server" Text='<%#:Item.Message %>' />
                </div>
                <div id="userName">
                    <asp:Label ID="UserNameLabel" runat="server" Text='<%#: GetUser(Item.UserId).UserName %>' />
                </div>
                <div id="date">
                    <asp:Label ID="DateLabel" runat="server" Text='<%#: Item.Date.Date.ToShortDateString() %>' />
                </div>
                <div id="commands">
                    <asp:LinkButton ID="DeleteLinkButton" CommandName="Delete" runat="server" Text="Ta bort" CausesValidation="false"
                        OnClientClick='<%# String.Format("return confirm(\"Ta bort meddelande?\")") %>' />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("EditPost", new { id = Item.BlogPostId })%>' Text="Redigera"/>
                </div>
            </article>
        </ItemTemplate>

    </asp:ListView>
</asp:Content>
