<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateAnalyticDiagram.aspx.cs" Inherits="IELTSWebAdmin.TemplateAnalyticDiagram"  Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 290px;
        }
        .auto-style3 {
            width: 290px;
            height: 29px;
        }
        .auto-style5 {
            height: 29px;
            width: 176px;
        }
        .auto-style6 {
            width: 176px;
        }
        .auto-style13 {
            width: 290px;
            height: 26px;
        }
        .auto-style14 {
            width: 176px;
            height: 26px;
        }
        .auto-style15 {
            width: 100%;
            height: 397px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
       
        <table class="auto-style15">
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <strong>
                    <asp:Label ID="lbl1" runat="server" Text="Step 1: Insert answer options"></asp:Label>
                    </strong>
                    </td>
                <td class="auto-style5">
                    <strong>
                    <asp:Label ID="lbl2" runat="server" Enabled="False" Text="Step 2:&nbsp; Choose correct answer"></asp:Label>
                    </strong>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblAnswerOpt" runat="server" Text="Insert Answer Options:"></asp:Label>
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
                <td class="auto-style5">
                    <asp:Label ID="Label2" runat="server" Text="Correct Answer: "></asp:Label>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
                
            </tr>
            <tr>
                <td class="auto-style2">
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
                <td class="auto-style6">
                    <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">

                        <ItemTemplate>
                            <%#Container.ItemIndex+1 %>
                            <asp:Label ID="lbl3" runat="server" />
                        </ItemTemplate>

                        <ItemTemplate>
                            <%#Container.ItemIndex+1 %>
                            <asp:DropDownList ID="ddl2" runat="server" />
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <br />
                        </SeparatorTemplate>
        
                    </asp:Repeater>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style14">
                    </td>
                
            </tr>
            <tr>
                <td class="auto-style13">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Proceed" CausesValidation="False" Height="35px" Width="87px" />
       

                </td>
                <td class="auto-style14">
                    <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" Text="Proceed" Enabled="False" />
                </td>
                
            </tr>
        </table>

        <div>
            <br />
       

        </div>
    </form>
</asp:Content>
