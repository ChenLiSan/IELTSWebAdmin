<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormAddSectio.aspx.cs" Inherits="IELTSWebAdmin.FormAddSectio" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 154px;
        }
        .auto-style2 {
            width: 154px;
            height: 28px;
        }
        .auto-style3 {
            height: 28px;
        }
        .auto-style4 {
            width: 315px;
        }
        .auto-style5 {
            width: 315px;
            height: 28px;
        }
        .auto-style6 {
            width: 335px;
        }
        .auto-style7 {
            height: 28px;
            width: 335px;
        }
        .auto-style8 {
            width: 154px;
            height: 35px;
        }
        .auto-style9 {
            width: 315px;
            height: 35px;
        }
        .auto-style10 {
            width: 335px;
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
     <ol class="breadcrumb">
        <li class="breadcrumb-item">
          <a href="LandingPage.aspx">Dashboard</a>
        </li>
        <li class="breadcrumb-item active">Add Section</li>
      </ol>
     <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label2" runat="server" Text="Choose Section:"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:DropDownList ID="ddlSection" runat="server" Height="23px" Width="78px" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style10">
                &nbsp;</td>
            <td class="auto-style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="Select Audio File:"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td class="auto-style7">
                <asp:Button ID="ButtonUpload" runat="server" OnClick="ButtonUpload_Click1" Text="Upload" CausesValidation="False" />
                </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style4">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" Text="Proceed" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
       </form>
</asp:Content>
