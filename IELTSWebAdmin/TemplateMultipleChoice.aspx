<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMultipleChoice.aspx.cs" Inherits="IELTSWebAdmin.TemplateMultipleChoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

        <asp:Label ID="Label1" runat="server" Text="Question Text:"></asp:Label>
        <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Answer Options:"></asp:Label>
        <asp:TextBox ID="txtOpt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Correct Answer:"></asp:Label>
        <asp:DropDownList ID="ddlAnswer" runat="server">
        </asp:DropDownList>
       

    </form>

</asp:Content>
