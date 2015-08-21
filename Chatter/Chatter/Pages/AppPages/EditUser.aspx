<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Chatter.Pages.AppPages.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
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
                    <asp:TextBox ID="EditName" runat="server" Text='<%#: BindItem.Name %>' />
                    <asp:TextBox ID="EditEmail" runat="server" Text='<%#: BindItem.Email %>' />
                </div>
                <div>
                    <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                    <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%$ RouteUrl:routename=UserList %>' />
                </div>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <asp:FormView ID="NewUserInfoFormView" runat="server"
                    ItemType="Chatter.Model.BLL.UserInfo"
                    DefaultMode="Insert"
                    RenderOuterTable="false"
                    SelectMethod="EditUserFormView_GetItem"
                    InsertMethod="UserInfoFormView_InsertItem">
                    <InsertItemTemplate>
                        <div>
                            Ingen info finns för 
                            <b><%#: GetUser(Convert.ToInt32(RouteData.Values["id"])).UserName %></b>,
                                 fyll i nedan
                        </div>
                        <div>
                            <asp:TextBox ID="InsertUserInfoName" runat="server" Text='<%#: BindItem.Name %>' />
                            <asp:TextBox ID="InsertUserInfoEmail" runat="server" Text='<%#: BindItem.Email%>' />
                        </div>
                        <div>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Spara" />
                            <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%$ RouteUrl:routename=UserList %>' />
                        </div>
                    </InsertItemTemplate>

                </asp:FormView>
            </EmptyDataTemplate>
        </asp:FormView>
    </article>
</asp:Content>
