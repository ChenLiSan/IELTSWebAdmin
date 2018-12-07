<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="IELTSWebAdmin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
        .auto-style2 {
            height: 22px;
        }
        .auto-style3 {
            height: 19px;
            width: 125px;
        }
        .auto-style4 {
            width: 125px;
        }
        .auto-style5 {
            height: 22px;
            width: 125px;
        }
        .auto-style6 {
            height: 19px;
            width: 150px;
        }
        .auto-style7 {
            width: 150px;
        }
        .auto-style8 {
            height: 22px;
            width: 150px;
        }
        .auto-style9 {
            width: 100%;
        }
        .auto-style10 {
            font-weight: bold;
        }
        .auto-style11 {
            width: 125px;
            height: 26px;
        }
        .auto-style12 {
            width: 150px;
            height: 26px;
        }
        .auto-style13 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style9">
                <tr>
                    <td class="auto-style3">
                        <h3>Login Page</h3>
                    </td>
                    <td class="auto-style6"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                    </td>
                    <td class="auto-style12"><asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td class="auto-style13"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style8"> 
            <br /><strong>
            <asp:Button ID="btnLogin" runat="server"  Text="Login" OnClick="btnLogin_Click" Height="34px" CssClass="auto-style10" Width="106px" />
                        </strong></td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="~/AdminRegistration1.aspx">Register new account</asp:HyperLink>
            </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
