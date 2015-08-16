<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Chatter.Pages.AppPages.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article>
        <asp:FormView ID="FormView1" runat="server"
            ItemType="Chatter.Model.BLL.UserInfo"
            DataKeyNames="UserInfoId"
            DefaultMode="Edit"
            RenderOuterTable="false"
            SelectMethod="EditUserFormView_GetItem"
            UpdateMethod="UserFormView_UpdateItem">
            <EditItemTemplate>
                <div>
                    <%#: GetUser(Item.UserId).UserName %>
                </div>
                <div>
                    <asp:TextBox ID="EditName" runat="server" Text='<%#: BindItem.Name %>'/>
                    <asp:TextBox ID="EditEmail" runat="server" Text='<%#: BindItem.Email %>' />
                </div>
                <div>
                    <asp:LinkButton runat="server" CommandName="Update" Text="Spara"/>
                    <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%$ RouteUrl:routename=UserList %>'/>
<%--                    <asp:Label ID="UserNameLabel" runat="server" Text="Användarnamn" />
                    <%#: Item.UserName %>

                    Full name: <%#: GetUserInfoByUserId(Item.UserId).Name %>
                    Email: <%#: GetUserInfoByUserId(Item.UserId).Email %>
                </div>--%>
                <div>

                </div>
            </EditItemTemplate>
        </asp:FormView>
    </article>
</asp:Content>
