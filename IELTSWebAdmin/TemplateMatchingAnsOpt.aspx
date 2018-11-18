﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TemplateMatchingAnsOpt.aspx.cs" Inherits="IELTSWebAdmin.TemplateMatchingAnsOpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 391px;
            height: 286px;
        }
        .auto-style4 {
            width: 87%;
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
            width: 575px;
            height: 78px;
        }
        .auto-style11 {
            width: 575px;
            height: 272px;
        }
        .auto-style12 {
            width: 575px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form id="form1" runat="server">
      
          <table class="auto-style4">
              <tr>
                  <td class="auto-style10">
            <asp:Label ID="Label2" runat="server" Text="Number of Answer Options"></asp:Label>
            <asp:DropDownList ID="ddlNumberOfRows" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumberOfRows_SelectedIndexChanged">
                <asp:ListItem Text="One" Value="1" />
                <asp:ListItem Text="Two" Value="2" />
                <asp:ListItem Text="Three" Value="3" />
                <asp:ListItem Text="Four" Value="4" />
            </asp:DropDownList>
                  </td>
                  <td class="auto-style7">&nbsp;</td>
                  <td class="auto-style7">Example of Answer Options:</td>
                  <td class="auto-style5" rowspan="3">&nbsp;</td>
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
                  <td class="auto-style9">&nbsp;</td>
                  <td class="auto-style9">
                      <img alt="" class="auto-style3" src="answerOpt.png" /></td>
              </tr>
              <tr>
                  <td class="auto-style12">
                      <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" Text="Proceed" />
                  </td>
                  <td class="auto-style5">&nbsp;</td>
                  <td class="auto-style5">&nbsp;</td>
              </tr>
          </table>
      
    </form>
</asp:Content>