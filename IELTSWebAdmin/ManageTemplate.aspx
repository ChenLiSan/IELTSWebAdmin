<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageTemplate.aspx.cs" Inherits="IELTSWebAdmin.ManageTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 14;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="lblText" runat="server" CssClass="auto-style2" style="font-size: x-large" Text="Please Choose One Template Question:"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="btnMultipleChoice" runat="server" Text="Multiple Choice" Width="269px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="btnMatching" runat="server" Text="Matching " Width="303px" />
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnShortAnswerQ" runat="server" Text="Short Answer Questions" CssClass="auto-style1" Width="268px" />
                </td>
                <td>
                    <asp:Button ID="btnMap" runat="server" OnClick="btnMap_Click" Text="Plan, Map, Diagram Labelling" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSentenceComplete" runat="server" Text="Senteces Completion" Width="265px" />
                </td>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="Note, Form, Table, Flow-chart" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</asp:Content>
