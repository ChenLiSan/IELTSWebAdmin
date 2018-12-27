<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMatchingAns.aspx.cs" Inherits="IELTSWebAdmin.TemplateMatchingAns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin-bottom: 1px;
        }
        .auto-style3 {
            width: 598px;
        }
        .auto-style4 {
            height: 25px;
            width: 598px;
        }
        .auto-style5 {
            width: 400px;
            height: 321px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
        <div>

            &nbsp;<table class="auto-style1">
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">

                    <strong>
                    <asp:Label ID="lbl1" runat="server" Text="Step 1: Insert questions text"></asp:Label>
                    </strong>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">

                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">

            <asp:Label ID="Label1" runat="server" Text="Main Question:"></asp:Label>
            <asp:TextBox ID="txtQ" runat="server" Width="425px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Example of main quetion and question text:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
            <asp:Label ID="Label2" runat="server" Text="No of question text："></asp:Label>
            <asp:DropDownList ID="ddlNumberOfRows" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumberOfRows_SelectedIndexChanged" CssClass="mt-0">
            <asp:ListItem Text="One" Value="1" />
            <asp:ListItem Text="Two" Value="2" />
            <asp:ListItem Text="Three" Value="3" />
            <asp:ListItem Text="Four" Value="4" />
            </asp:DropDownList>
                    </td>
                    <td class="text-center" rowspan="5">
                        <img alt="" class="auto-style5" src="mainQ.png" /></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <%#Container.ItemIndex+1 %>
                    <asp:TextBox ID="txtTextBox1" runat="server" />
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
       

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
       

            <asp:Label ID="lbl3" runat="server"></asp:Label>
       

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
       

                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
       

                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Proceed" CausesValidation="False" />
</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
       

            <br />
            <br />
            <br />
            <br />
            <br />
       

        </div>
    </form>
</asp:Content>
