<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" ValidateRequest="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
    </div>

    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
             Kullanıcı Adı: <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox> <br />
             Şifre <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password"></asp:TextBox>
             <br />
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
             <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>
