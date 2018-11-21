<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateSentenceCompletion.aspx.cs" Inherits="IELTSWebAdmin.TemplateSentenceCompletion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
        .auto-style2 {
            height: 25px;
            width: 101px;
        }
        .auto-style3 {
            width: 101px;
        }
    </style>
    <script type="text/javascript" src="place.js"></script>
    <script type="text/javascript">
        
        function onCLickButton() {
        var text_to_be_inserted = "<<answer>>";
        var existing = document.getElementById("TextBox2").value;
        document.getElementById("TextBox2").value = existing+text_to_be_inserted;
        }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style1" colspan="2">
                    <asp:Label ID="Label3" runat="server" Text="Please type [ ] as a placeholder for the answer in the question text."></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="2">
                    <asp:Label ID="Label4" runat="server" Text="Example: John was [ ] years old."></asp:Label>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Question Text:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtQ" runat="server" Width="321px"></asp:TextBox>
&nbsp;</td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Answer Text:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAns" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Proceed" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</asp:Content>
