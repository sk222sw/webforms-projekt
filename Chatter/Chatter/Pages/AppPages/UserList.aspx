﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Chatter.Pages.AppPages.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Användare</h2>
    <asp:ListView ID="UserListView" runat="server"
        ItemType="Chatter.Model.BLL.User"
        SelectMethod="UserListView_GetData"
        DataKeyNames="UserId">
        <LayoutTemplate>
            <article>
                <table>
                    <tr>
                        <th>Namn</th>
                        <th></th>
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
                    <asp:LinkButton ID="DeleteButton" runat="server" Text="Ta bort"/>
                </td>
                <td>
                    <asp:HyperLink ID="EditButton" runat="server" NavigateUrl='<%# GetRouteUrl("EditUser", new { id = Item.UserId }) %>' Text="Redigera"/>
                </td>
            </tr>
 

        </ItemTemplate>
    </asp:ListView>
</asp:Content>
