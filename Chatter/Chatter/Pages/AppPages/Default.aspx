<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Chatter.Pages.AppPages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="UserInfoListView" runat="server"
        ItemType="Chatter.Model.BLL.UserInfo"
        SelectMethod="UserInfoListView_GetData"
        DataKeyNames="UserInfoId">
        <LayoutTemplate>
            <div>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <asp:Label ID="UserNameLabel" runat="server" Text='<%#: Item.Name %>' />
            </div>
            <div>
                <asp:Label ID="EmailLabel" runat="server" Text='<%#: Item.Email %>' />
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
