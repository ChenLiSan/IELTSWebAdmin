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
            width: 300px;
        }
        .auto-style6 {
            width: 300px;
        }
        .auto-style7 {
            width: 162px;
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
                <td class="auto-style2">Insert Answer Option:</td>
                <td class="auto-style6">
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
                
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
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
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CausesValidation="False" />
       

        </div>
    </form>
</asp:Content>
