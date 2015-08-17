<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="Chatter.Pages.AppPages.NewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article>
        <asp:FormView ID="NewUserFormView" runat="server"
            ItemType="Chatter.Model.BLL.User"
            DefaultMode="Insert"
            RenderOuterTable="false"
            InsertMethod="NewUserFormView_InsertItem">
            <InsertItemTemplate>
                <div>
                    <asp:TextBox ID="NewUserName" runat="server" Text="<%#: BindItem.UserName %>"/>
                </div>
                <div>
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Lägg till" CommandName="Insert"/>
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("UserList", null) %>'/>
                </div>
            </InsertItemTemplate>
        </asp:FormView>
    </article>
</asp:Content>
