<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="IELTSWebAdmin.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="text-center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="attemptID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="521px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="attemptID" HeaderText="attemptID" InsertVisible="False" ReadOnly="True" SortExpression="attemptID" />
                    <asp:BoundField DataField="candidate" HeaderText="candidate" SortExpression="candidate" />
                    <asp:BoundField DataField="paper" HeaderText="paper" SortExpression="paper" />
                    <asp:BoundField DataField="sessionID" HeaderText="sessionID" SortExpression="sessionID" />
                    <asp:BoundField DataField="record" HeaderText="record" SortExpression="record" />
                    <asp:BoundField DataField="log" HeaderText="log" SortExpression="log" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [attempt]"></asp:SqlDataSource>
    </form>
</asp:Content>
