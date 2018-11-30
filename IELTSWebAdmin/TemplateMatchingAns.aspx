﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMatchingAns.aspx.cs" Inherits="IELTSWebAdmin.TemplateMatchingAns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
        <div>

            Main

            <asp:Label ID="Label1" runat="server" Text="Question:"></asp:Label>
            <asp:TextBox ID="txtQ" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Number of Question Text："></asp:Label>
            <asp:DropDownList ID="ddlNumberOfRows" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumberOfRows_SelectedIndexChanged">
            <asp:ListItem Text="One" Value="1" />
            <asp:ListItem Text="Two" Value="2" />
            <asp:ListItem Text="Three" Value="3" />
            <asp:ListItem Text="Four" Value="4" />
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
            </asp:Repeater>
       

            <asp:Label ID="lbl3" runat="server"></asp:Label>
       

            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Proceed" CausesValidation="False" />
       

        </div>
    </form>
</asp:Content>
