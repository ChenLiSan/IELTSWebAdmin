﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMatchingAnsOpt.aspx.cs" Inherits="IELTSWebAdmin.TemplateMatchingAnsOpt" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
            width: 457px;
            height: 78px;
        }
        .auto-style11 {
            width: 457px;
            height: 272px;
        }
        .auto-style12 {
            width: 457px;
        }
        .auto-style13 {
            width: 199px;
            height: 78px;
        }
        .auto-style14 {
            width: 199px;
            height: 272px;
        }
        .auto-style15 {
            width: 199px;
        }
        .auto-style16 {
            width: 85px;
            height: 272px;
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
                  <td class="auto-style7" colspan="2">&nbsp;</td>
              </tr>
              <tr>
                  <td class="auto-style10">
                    <strong>
                    <asp:Label ID="lbl1" runat="server" Text="Step 2: Insert answer options"></asp:Label>
                    </strong>
                    </td>
                  <td class="auto-style13">&nbsp;</td>
                  <td class="auto-style7" colspan="2">
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
                  <td class="auto-style13">&nbsp;</td>
                  <td class="auto-style7" colspan="2">
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
                      &nbsp;</td>
                  <td class="auto-style16">
                      <asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound">
                          <ItemTemplate>
                            <%#Container.ItemIndex+1 %>
                            <asp:Label ID="label3" runat="server"  ViewStateMode="Inherit" />
                        </ItemTemplate>
                           <SeparatorTemplate>
                            <br />
                        </SeparatorTemplate>
                      </asp:Repeater>
                      <br />
                  </td>
                  <td class="auto-style9">
                    <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">                    
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
                  <td class="auto-style5" colspan="2">
                      <asp:Button ID="btnProceed2" runat="server" Text="Proceed" OnClick="btnProceed2_Click1" Enabled="False" />
                  </td>
              </tr>
          </table>
      
    </form>
</asp:Content>
