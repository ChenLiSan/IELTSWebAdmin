<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMultipleChoice.aspx.cs" Inherits="IELTSWebAdmin.TemplateMultipleChoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

        <asp:Label ID="Label1" runat="server" Text="Question Text:"></asp:Label>
        <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>
        <br />
         Options for question:
    <asp:DropDownList ID="ddlNumberOfRows" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumberOfRows_SelectedIndexChanged">
        <asp:ListItem Text="A" Value="1" />
        <asp:ListItem Text="B" Value="2" />
        <asp:ListItem Text="C" Value="3" />
        <asp:ListItem Text="D" Value="4" />
    </asp:DropDownList>
    <br />
    <br />
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <%#Container.ItemIndex+1 %>
            <asp:TextBox ID="txtTextBox1" runat="server" />
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater><br />
        <asp:Label ID="Label3" runat="server" Text="Correct Answer:"></asp:Label>
        <asp:DropDownList ID="ddlAnswer" runat="server">
        </asp:DropDownList>
       

    </form>

</asp:Content>
