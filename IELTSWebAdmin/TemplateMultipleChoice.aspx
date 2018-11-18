﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMultipleChoice.aspx.cs" Inherits="IELTSWebAdmin.TemplateMultipleChoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

        <asp:Label ID="Label1" runat="server" Text="Question Text:"></asp:Label>
        <asp:TextBox ID="txtQ" runat="server"></asp:TextBox>
        <br />
        <br />
   <asp:DropDownList ID="ddlNumberOfRows" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumberOfRows_SelectedIndexChanged">
            <asp:ListItem Text="One" Value="1" />
            <asp:ListItem Text="Two" Value="2" />
            <asp:ListItem Text="Three" Value="3" />
            <asp:ListItem Text="Four" Value="4" />
            <asp:ListItem Text="Five" Value="5" />
            </asp:DropDownList>
        <br />

        <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <%#Container.ItemIndex+1 %>
                    <asp:TextBox ID="txtTextBox1" runat="server" />
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
        
       

        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        
       

        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
        
       

    </form>

</asp:Content>
