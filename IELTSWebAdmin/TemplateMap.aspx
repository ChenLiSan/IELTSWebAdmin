<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMap.aspx.cs" Inherits="IELTSWebAdmin.TemplateMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Insert Diagram:"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Correct Answer:"></asp:Label>
        <div>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CausesValidation="False" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" ViewStateMode="Enabled"></asp:PlaceHolder>
        </div>
    </form>
</asp:Content>
