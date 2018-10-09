<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateMatching.aspx.cs" Inherits="IELTSWebAdmin.TemplateMatching" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 192px;
        }
        .auto-style2 {
            width: 236px;
        }
        .auto-style3 {
            width: 236px;
            text-align: center;
        }
        .auto-style4 {
            width: 192px;
            text-align: center;
        }
        .auto-style5 {
            width: 647px;
        }
        .auto-style6 {
            width: 225px;
            text-align: center;
        }
        .auto-style7 {
            width: 208px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Question:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style4">Options Left</td>
                    <td class="auto-style3">Options Right</td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Correct Answer:"></asp:Label>
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style6">Options Left</td>
                    <td class="auto-style7">Options Right</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
