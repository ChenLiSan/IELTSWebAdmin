<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="landingPage.aspx.cs" Inherits="IELTSWebAdmin.landingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
    .auto-style1 {
        font-weight: normal;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h2>
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="auto-style1">Welcome, Admin</asp:Label>
            </h2>
    </form>
</asp:Content>
