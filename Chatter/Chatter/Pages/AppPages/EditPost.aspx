<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="Chatter.Pages.AppPages.EditPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:FormView ID="FormView1" runat="server"
        ItemType="Chatter.Model.BLL.BlogPost"
        DataKeyNames="BlogPostId"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="EditBlogPostFormView_GetItem"
        UpdateMethod="BlogPostFormView_UpdateItem">
        <EditItemTemplate>
            <div>
                <h3>Titel</h3>
            </div>
            <div>
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%#: BindItem.Title %>' />
            </div>
            <div>
                <h3>Meddelande</h3>
            </div>
            <div>
                <asp:TextBox ID="MessageTextBox" runat="server" Text='<%#: BindItem.Message %>'/>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Uppdatera"/>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%#: GetRouteUrl("Posts", null) %>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
