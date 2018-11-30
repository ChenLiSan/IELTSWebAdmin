<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateAnalyticDiagram.aspx.cs" Inherits="IELTSWebAdmin.TemplateAnalyticDiagram"  Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 162px;
        }
        .auto-style3 {
            width: 162px;
            height: 29px;
        }
        .auto-style4 {
            height: 29px;
        }
        .auto-style5 {
            height: 29px;
            width: 176px;
        }
        .auto-style6 {
            width: 176px;
        }
        .auto-style10 {
            height: 29px;
            width: 129px;
        }
        .auto-style12 {
            width: 129px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
       
        <table class="w-100">
            <tr>
                <td class="auto-style3">
                    </td>
                <td class="auto-style5">
                    </td>
                <td class="auto-style10">
                    </td>
                <td class="auto-style4"> </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblAnswerOpt" runat="server" Text="Insert Answer Options:"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="ddlNumberOfRows" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumberOfRows_SelectedIndexChanged">
                        <asp:ListItem Text="One" Value="1" />
                        <asp:ListItem Text="Two" Value="2" />
                        <asp:ListItem Text="Three" Value="3" />
                        <asp:ListItem Text="Four" Value="4" />
                        <asp:ListItem Text="Five" Value="5" />
                        <asp:ListItem Text="Six" Value="6" />
                        <asp:ListItem Text="Seven" Value="7" />
                        <asp:ListItem Text="Eight" Value="8" />
                        <asp:ListItem Text="Nine" Value="9" />
                        <asp:ListItem Text="Ten" Value="10" />
                    </asp:DropDownList>
                </td>
                
                <td class="auto-style10">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
                
                <td class="auto-style12">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <%#Container.ItemIndex+1 %>
                    <asp:TextBox ID="txtTextBox1" runat="server" />
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
            <br />
            <br />
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Proceed" CausesValidation="False" />
       

        </div>
    </form>
</asp:Content>
