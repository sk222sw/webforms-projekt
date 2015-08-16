<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Chatter.Pages.AppPages.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article>
        <asp:FormView ID="FormView1" runat="server"
            ItemType="Chatter.Model.BLL.User"
            DataKeyNames="UserId"
            DefaultMode="Edit"
            RenderOuterTable="false"
            SelectMethod="EditUserFormView_GetItem">
            <EditItemTemplate>
                <div>
                    <asp:Label ID="UserNameLabel" runat="server" Text="Användarnamn" />
                    <%#: Item.UserName %>

                    Full name: <%#: GetUserInfoByUserId(Item.UserId).Name %>
                    Email: <%#: GetUserInfoByUserId(Item.UserId).Email %>
                </div>
                <div>
                </div>
            </EditItemTemplate>
        </asp:FormView>
    </article>
</asp:Content>
