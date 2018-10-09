<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormSubsection.aspx.cs" Inherits="IELTSWebAdmin.FormSubsection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
        .auto-style2 {
            height: 29px;
            width: 170px;
        }
        .auto-style3 {
            width: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Choose Template:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Matching</asp:ListItem>
                    <asp:ListItem>Multiple Choice</asp:ListItem>
                    <asp:ListItem>Form, Note, Table</asp:ListItem>
                    <asp:ListItem>Sentences Completion</asp:ListItem>
                    <asp:ListItem>Short QUestion</asp:ListItem>
                    <asp:ListItem>Plan, Map, Diagram labeling</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="No. of Questions:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
