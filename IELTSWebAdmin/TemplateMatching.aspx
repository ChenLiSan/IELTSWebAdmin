<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateMatching.aspx.cs" Inherits="IELTSWebAdmin.TemplateMatching" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>


            <table style="width:100%;">
                <tr>
                    <td><asp:Panel ID="pnlTextBoxes" runat="server" Width="552px"></asp:Panel></td>
                    <td><asp:Panel ID="pnlTextBoxes1" runat="server" Width="552px"></asp:Panel></td>
                </tr>

            </table>
<hr />
<asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="AddTextBox" />
<asp:Button ID="btnGet" runat="server" Text="Get Values" OnClick="GetTextBoxValues" />    
            <br />
        </div>
    </form>
</body>
</html>
