<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormSubsection.aspx.cs" Inherits="IELTSWebAdmin.FormSubsection"  Async="true"%>
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

    <form id="form1" runat="server">

    <table style="width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Choose Template:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="width: 91px" AutoPostBack="True">
                    <asp:ListItem>Matching</asp:ListItem>
                    <asp:ListItem>Multiple Choice</asp:ListItem>
                    <asp:ListItem>Form, Note, Table</asp:ListItem>
                    <asp:ListItem>Sentences Completion</asp:ListItem>
                    <asp:ListItem>Short Answer</asp:ListItem>
                    <asp:ListItem>Plan, Map, Diagram labeling</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style2">
        <asp:Label ID="Label3" runat="server" Text="Insert Diagram:" Visible="False"></asp:Label>
            </td>
            <td class="auto-style1">
        <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_ClickAsync" Text="Upload" Visible="False" />
                <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="No. of Subsection:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddlQ" runat="server" OnSelectedIndexChanged="ddlQ_SelectedIndexChanged">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style2">
                </td>
            <td class="auto-style1">
                </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" Text="Proceed" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

    </form>

</asp:Content>
