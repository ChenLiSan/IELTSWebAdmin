<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GenerateReport.aspx.cs" Inherits="IELTSWebAdmin.GenerateReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <h1><strong>
    <asp:Label ID="Label1" runat="server" Text="Generate Report" CssClass="auto-style1"></asp:Label></strong></h1>
        <br />
        <p>
            <a href="Report.aspx">Detail Report</a> |
            <a href="SummaryReport.aspx">Summary Report</a>
        </p>
    </form>
</asp:Content>
