<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Chatter.Pages.AppPages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="UserListView" runat="server"
        ItemType="Chatter.Model.BLL.User"
        SelectMethod="UserListView_GetData"
        DataKeyNames="UserId">
        <LayoutTemplate>
            <div>
                Namn
            </div>
            <div>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <asp:Label ID="UserNameLabel" runat="server" Text='<%#: Item.UserName %>'/>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
