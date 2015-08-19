<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="Chatter.Pages.AppPages.NewPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Nytt inlägg</h2>
    <asp:Image ID="Image1" ImageUrl="http://animatedgif.net/underconstruction/anim0205-1_e0.gif" runat="server" />
    <asp:FormView ID="FormView1" runat="server"
        ItemType="Chatter.Model.BLL.BlogPost"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="BlogPostFormView_InsertItem">
        <InsertItemTemplate>
            <div>
                <asp:ListView ID="ListView1" runat="server"
                    ItemType="Chatter.Model.BLL.User"
                    SelectMethod="GetUsers"
                    DataKeyNames="UserId">
                    <LayoutTemplate>
                        <select id="select" name="selectList">
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </select>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <option value='<%#: Item.UserId %>'>
                            <%#: Item.UserName %>
                        </option>
                    </ItemTemplate>
                </asp:ListView>
            </div>
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
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" Text="Posta" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Posts", null) %>'/>
            </div>
        </InsertItemTemplate>


    </asp:FormView>
</asp:Content>
