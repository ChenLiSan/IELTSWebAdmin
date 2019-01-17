<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMultipleChoice.aspx.cs" Inherits="IELTSWebAdmin.TemplateMultipleChoice" Async="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 669px;
        }
        .auto-style2 {
            width: 669px;
            height: 27px;
        }
        .auto-style3 {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

        <table class="w-100">
            <tr>
                <td class="auto-style1">
                    <br />
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>
                    <asp:Label ID="lbl1" runat="server" Text="Step 1: Insert question text and answer options"></asp:Label>
                    </strong></td>
                <td><strong>
                    <asp:Label ID="lbl2" runat="server" Enabled="False" Text="Step 2:&nbsp; Choose correct answer"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">

        <asp:Label ID="lblQ" runat="server" Text="Question Text:"></asp:Label>
        <asp:TextBox ID="txtQ" runat="server" Width="189px"></asp:TextBox>
                </td>
                <td>
        <asp:Label ID="Label2" runat="server" Text="Correct Answer: " Enabled="False"></asp:Label>
        <asp:DropDownList ID="ddlCorrectAns" runat="server" OnSelectedIndexChanged="ddlCorrectAns_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1">
        <asp:Label ID="lblAnsOpt" runat="server" Text="Answer Options: "></asp:Label>
   <asp:DropDownList ID="ddlNumberOfRows" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumberOfRows_SelectedIndexChanged">
            <asp:ListItem Text="One" Value="1" />
            <asp:ListItem Text="Two" Value="2" />
            <asp:ListItem Text="Three" Value="3" />
            <asp:ListItem Text="Four" Value="4" />
            <asp:ListItem Text="Five" Value="5" />
            </asp:DropDownList>
                </td>
                <td>
        <asp:Button ID="btnSave1" runat="server" Text="save" OnClick="btnSave1_Click" Enabled="False" Width="70px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />

        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
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
        

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="save" Height="39px" Width="74px" />
        

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        
    </form>

</asp:Content>
