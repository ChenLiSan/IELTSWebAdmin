<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMatchingAnsOpt.aspx.cs" Inherits="IELTSWebAdmin.TemplateMatchingAnsOpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 391px;
            height: 286px;
        }
        .auto-style4 {
            width: 91%;
            height: 497px;
        }
        .auto-style5 {
            width: 455px;
        }
        .auto-style7 {
            width: 455px;
            height: 78px;
        }
        .auto-style9 {
            width: 455px;
            height: 272px;
        }
        .auto-style10 {
            width: 629px;
            height: 78px;
        }
        .auto-style11 {
            width: 629px;
            height: 272px;
        }
        .auto-style12 {
            width: 629px;
        }
        .auto-style13 {
            width: 355px;
            height: 78px;
        }
        .auto-style14 {
            width: 355px;
            height: 272px;
        }
        .auto-style15 {
            width: 355px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form id="form1" runat="server">
      
          <table class="auto-style4">
              <tr>
                  <td class="auto-style10">
                      &nbsp;</td>
                  <td class="auto-style13">&nbsp;</td>
                  <td class="auto-style7">&nbsp;</td>
              </tr>
              <tr>
                  <td class="auto-style10">
                    <strong>
                    <asp:Label ID="lbl1" runat="server" Text="Step 2: Insert answer options"></asp:Label>
                    </strong>
                    </td>
                  <td class="auto-style13">&nbsp;</td>
                  <td class="auto-style7">
                    <strong>
                    <asp:Label ID="lbl2" runat="server" Text="Step 3: Choose correct answer"></asp:Label>
                    </strong>
                    </td>
              </tr>
              <tr>
                  <td class="auto-style10">
            <asp:Label ID="Label2" runat="server" Text="No of answer options"></asp:Label>
            <asp:DropDownList ID="ddlNumberOfRows" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumberOfRows_SelectedIndexChanged">
                <asp:ListItem Text="One" Value="1" />
                <asp:ListItem Text="Two" Value="2" />
                <asp:ListItem Text="Three" Value="3" />
                <asp:ListItem Text="Four" Value="4" />
            </asp:DropDownList>
                  </td>
                  <td class="auto-style13">Example of Answer Options:</td>
                  <td class="auto-style7">
                      <asp:Label ID="lblMessage" runat="server"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="auto-style11">
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
                  <td class="auto-style14">
                      <img alt="" class="auto-style3" src="answerOpt.png" /></td>
                  <td class="auto-style9">
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
                  <td class="auto-style12">
                      <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" Text="Proceed" />
                  </td>
                  <td class="auto-style15">&nbsp;</td>
                  <td class="auto-style5">
                      <asp:Button ID="btnProceed2" runat="server" Text="Proceed" />
                  </td>
              </tr>
          </table>
      
    </form>
</asp:Content>
