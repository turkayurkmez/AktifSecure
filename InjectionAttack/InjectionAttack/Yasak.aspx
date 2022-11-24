<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Yasak.aspx.cs" Inherits="_Default" ValidateRequest="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
    </div>

    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="TextBoxComment" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="ButtonAddComment" runat="server" OnClick="ButtonAddComment_Click" Text="Button" />
            &nbsp;<asp:Label ID="LabelResult" runat="server" Text="Label"></asp:Label>


        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
</asp:Content>
