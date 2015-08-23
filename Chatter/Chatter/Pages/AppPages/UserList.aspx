<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Chatter.Pages.AppPages.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Användare</h2>
    <asp:Panel ID="SuccessPanel" CssClass="successMessage" Visible="false" runat="server">
        <div class="successContainer">   
            <asp:Literal ID="SuccessLiteral" runat="server" />
            <asp:LinkButton ID="CloseButton" runat="server" OnClick="CloseButton_Click" CssClass="CloseButton" Text="X"/>
        </div>
    </asp:Panel>
    <asp:ListView ID="UserListView" runat="server"
        ItemType="Chatter.Model.BLL.User"
        SelectMethod="UserListView_GetData"
        DeleteMethod="UserListView_DeleteItem"
        DataKeyNames="UserId">
        <LayoutTemplate>
            <article>
                <table>
                    
                    <tr>
                        <th>Namn</th>
                            <th>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=NewUser %>' Text="Ny användare" />
                            </th>
                        </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
            </article>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="UserNameLabel" runat="server" Text='<%#: Item.UserName %>'/>
                </td>
                <td>
                    <asp:LinkButton ID="DeleteButton" CommandName="Delete" runat="server" Text="Ta bort" CausesValidation="false"
                        OnClientClick='<%# String.Format("return confirm(\"Ta bort {0}?\")", Item.UserName) %>'/>
                </td>
                <td>
                    <asp:HyperLink ID="EditButton" runat="server" NavigateUrl='<%# GetRouteUrl("EditUser", new { id = Item.UserId }) %>' Text="Redigera"/>
                </td>
            </tr>
 

        </ItemTemplate>
    </asp:ListView>
</asp:Content>
