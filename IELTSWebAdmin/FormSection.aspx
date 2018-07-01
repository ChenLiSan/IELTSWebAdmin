<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormSection.aspx.cs" Inherits="IELTS_Listening_Test_System.FormSection" MasterPageFile="~/FormMainPage.Master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <p>
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style16">
                            <asp:Label ID="lblSection" runat="server" Text="Choose Section:"></asp:Label>
                        </td>
                        <td class="auto-style17">
                            <asp:DropDownList ID="ddlSection" runat="server" Height="21px" Width="68px">
                                <asp:ListItem>A</asp:ListItem>
                                <asp:ListItem>B</asp:ListItem>
                                <asp:ListItem>C</asp:ListItem>
                                <asp:ListItem>D</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style17"></td>
                    </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            <asp:Label ID="lblTotalQuestions" runat="server" Text="Total Questions of Whole Section:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTotalQuestions" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </p>
        </asp:Content>


