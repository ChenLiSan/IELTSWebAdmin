<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateMatching.aspx.cs" Inherits="IELTSWebAdmin.TemplateMatching" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 319px;
        }
        .auto-style9 {
            width: 296px;
        }

        .auto-style10 {
            height: 19px;
        }
        .auto-style11 {
            width: 120px;
        }
        .auto-style12 {
            height: 19px;
            width: 120px;
        }
        .auto-style13 {
            width: 388px;
        }
        .auto-style14 {
            height: 19px;
            width: 388px;
        }
        .auto-style15 {
            width: 296px;
            height: 20px;
        }
        .auto-style16 {
            width: 319px;
            height: 20px;
        }
        .auto-style17 {
            height: 20px;
        }
        .auto-style18 {
            width: 100%;
            height: 69px;
        }

    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div class="left-div">
            <table class="auto-style18">
                <tr>
                    <td class="auto-style11">Question:</td>
                    <td class="auto-style13">
                        <asp:TextBox ID="txtQuestion" runat="server" Width="352px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12"></td>
                    <td class="auto-style14"></td>
                    <td class="auto-style10"></td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Panel ID="pnlTextBoxes" runat="server" Width="467px" CssClass="left-div">
            </asp:Panel> </div>

            <hr />
            <br />
       
        <table style="width:100%;">
            <tr>
                <td class="auto-style9">
<asp:Button ID="btnAdd" runat="server" Text="Add Question" OnClick="AddTextBox" />
                </td>
                <td class="auto-style1">
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style16"></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>
<asp:Button ID="btnGet" runat="server" Text="Get Values" OnClick="GetTextBoxValues" />    
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
