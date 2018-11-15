<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateAnalyticDiagram.aspx.cs" Inherits="IELTSWebAdmin.TemplateAnalyticDiagram"  Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 279px;
        }
        .auto-style2 {
            width: 120px;
        }
        .auto-style3 {
            width: 120px;
            height: 29px;
        }
        .auto-style4 {
            height: 29px;
        }
        .auto-style5 {
            height: 29px;
            width: 300px;
        }
        .auto-style6 {
            width: 300px;
        }
        .auto-style7 {
            width: 120px;
            height: 27px;
        }
        .auto-style8 {
            width: 300px;
            height: 27px;
        }
        .auto-style9 {
            height: 27px;
        }
        .auto-style10 {
            height: 29px;
            width: 95px;
        }
        .auto-style11 {
            height: 27px;
            width: 95px;
        }
        .auto-style12 {
            width: 95px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
       
        <table class="w-100">
            <tr>
                <td class="auto-style3">
        <asp:Label ID="Label1" runat="server" Text="Insert Diagram:"></asp:Label>
                </td>
                <td class="auto-style5">
        <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td class="auto-style10">
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
                </td>
                <td class="auto-style4"> <asp:Label ID="Label3" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style8"></td>
                <td class="auto-style11"></td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Correct Answer:"></asp:Label>
        <div>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1"></asp:TextBox>
            <%--<asp:Button ID="Button1" runat="server" CausesValidation="False" OnClick="Button1_Click" Text="Button" />--%>
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" ViewStateMode="Enabled"></asp:PlaceHolder>
        </div>
    </form>
</asp:Content>
