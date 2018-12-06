<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddExamSession.aspx.cs" Inherits="IELTSWebAdmin.AddExamSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 202px;
        }
        .auto-style2 {
            width: 423px;
            height: 295px;
            margin-right: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Add New Exam Session</h2>
  
   
             <form id="form1" runat="server">
       <table class="auto-style2" >
	    <tbody>
		<tr>
			<td>Test date : </td>
			<td class="auto-style1"> <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged">
                     <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                     <NextPrevStyle VerticalAlign="Bottom" />
                     <OtherMonthDayStyle ForeColor="#808080" />
                     <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                     <SelectorStyle BackColor="#CCCCCC" />
                     <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                     <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                     <WeekendDayStyle BackColor="#FFFFCC" />
                 </asp:Calendar>

			</td>
		</tr>
		<tr>
			<td>Test time : </td>
			<td class="auto-style1">  <asp:DropDownList ID="ddlHour" runat="server" OnSelectedIndexChanged="ddlHour_SelectedIndexChanged">
                     <asp:ListItem>8</asp:ListItem>
                     <asp:ListItem>9</asp:ListItem>
                     <asp:ListItem>10</asp:ListItem>
                     <asp:ListItem>11</asp:ListItem>
                     <asp:ListItem>12</asp:ListItem>
                     <asp:ListItem>13</asp:ListItem>
                     <asp:ListItem>14</asp:ListItem>
                     <asp:ListItem>15</asp:ListItem>
                     <asp:ListItem>16</asp:ListItem>
                     <asp:ListItem>17</asp:ListItem>
                     <asp:ListItem>18</asp:ListItem>
                     <asp:ListItem>19</asp:ListItem>
                     <asp:ListItem>20</asp:ListItem>
                 </asp:DropDownList> &nbsp;&nbsp; <asp:DropDownList ID="ddlMinute" runat="server" OnSelectedIndexChanged="ddlMinute_SelectedIndexChanged">
                     <asp:ListItem>00</asp:ListItem>
                     <asp:ListItem>15</asp:ListItem>
                     <asp:ListItem>30</asp:ListItem>
                     <asp:ListItem>45</asp:ListItem>
                 </asp:DropDownList></td>
		</tr>
		<tr>
			<td> Test validity period: </td>
			<td class="auto-style1">          <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                     <asp:ListItem>1</asp:ListItem>
                     <asp:ListItem>2</asp:ListItem>
                     <asp:ListItem>3</asp:ListItem>
                     <asp:ListItem>4</asp:ListItem>
                     <asp:ListItem>5</asp:ListItem>
                     <asp:ListItem>6</asp:ListItem>
                     <asp:ListItem>7</asp:ListItem>
                     <asp:ListItem>8</asp:ListItem>
                     <asp:ListItem>9</asp:ListItem>
                     <asp:ListItem>10</asp:ListItem>
                     <asp:ListItem>11</asp:ListItem>
                     <asp:ListItem>12</asp:ListItem>
                     <asp:ListItem>13</asp:ListItem>
                     <asp:ListItem>14</asp:ListItem>
                     <asp:ListItem>15</asp:ListItem>
                     <asp:ListItem>16</asp:ListItem>
                     <asp:ListItem>17</asp:ListItem>
                     <asp:ListItem>18</asp:ListItem>
                     <asp:ListItem>19</asp:ListItem>
                     <asp:ListItem>20</asp:ListItem>
                     <asp:ListItem>21</asp:ListItem>
                     <asp:ListItem>22</asp:ListItem>
                     <asp:ListItem>23</asp:ListItem>
                     <asp:ListItem>24</asp:ListItem>
                 </asp:DropDownList> hours(s)</td>
		</tr>
		<tr>
			<td> </td>
			<td class="auto-style1"> 
                <asp:Button ID="Button1" runat="server" Text="Save Session" OnClick="Button1_Click" />
            </td>
		</tr>
	</tbody>
</table>
                 <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 
                   <p>Note : Validity period refers to the time period where the test may be started. For example: If the test time is 8.00 am and validity period is set to 1 hour, the test may be started by the latest at 9.00 am. Test end time is not affected. </p>
         </form>     

</asp:Content>
