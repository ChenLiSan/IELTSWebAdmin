<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormAddSectio.aspx.cs" Inherits="IELTSWebAdmin.FormAddSectio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 116px;
        }
        .auto-style2 {
            width: 116px;
            height: 28px;
        }
        .auto-style3 {
            height: 28px;
        }
        .auto-style4 {
            width: 163px;
        }
        .auto-style5 {
            width: 163px;
            height: 28px;
        }
        .auto-style6 {
            width: 290px;
        }
        .auto-style7 {
            height: 28px;
            width: 290px;
        }
        .auto-style8 {
            width: 116px;
            height: 35px;
        }
        .auto-style9 {
            width: 163px;
            height: 35px;
        }
        .auto-style10 {
            width: 290px;
            height: 35px;
        }
        .auto-style11 {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--<div _designerregion="0">
</div>-->
     <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label2" runat="server" Text="Choose Section:"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="78px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style10">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td class="auto-style11">
                <asp:Button ID="ButtonUpload" runat="server" OnClick="ButtonUpload_Click1" Text="Upload" CausesValidation="False" />
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style5"></td>
            <td class="auto-style7"></td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Proceed" CausesValidation="False" />
            </td>
        </tr>
    </table>
       </form>
</asp:Content>
