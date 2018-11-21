<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="IELTSWebAdmin.LandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <ol class="breadcrumb">
        <li class="breadcrumb-item">
          <a href="LandingPage.aspx">Dashboard</a>
        </li>
        <li class="breadcrumb-item active">Welcome</li>
      </ol>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Welcome Admin."></asp:Label>
    </form>

</asp:Content>
