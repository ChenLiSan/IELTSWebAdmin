<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateAnalyticDiagram1.aspx.cs" Inherits="IELTSWebAdmin.TemplateAnalyticDiagram1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 144px;
        }
        .auto-style2 {
            width: 144px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Correct Answer: "></asp:Label>
                </td>
                <td class="auto-style3">
                    <%--<asp:DropDownList ID="ddlCorrectAns" runat="server" Height="21px" OnSelectedIndexChanged="ddlCorrectAns_SelectedIndexChanged" Width="83px">
                    </asp:DropDownList>--%>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">

                        <ItemTemplate>
                            <%#Container.ItemIndex+1 %>
                            <asp:Label ID="lbl1" runat="server" />
                        </ItemTemplate>

                        <ItemTemplate>
                            <%#Container.ItemIndex+1 %>
                            <asp:DropDownList ID="ddl1" runat="server" />
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <br />
                        </SeparatorTemplate>
        
                    </asp:Repeater>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" Text="Proceed" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</asp:Content>
