<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="IELTSWebAdmin.Report" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<!DOCTYPE html>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <%--  <style>
        html,body,form,#div1 {
            height: 100%; 
        }
    </style>--%>
    <title></title>
    <style type="text/css">
        .auto-style5 {
            height: 19px;
        }
        .auto-style6 {
            width: 24%;
        }
        .auto-style7 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Style="width: 46px" />

            <div align="center">
                <table class="auto-style6">
                    <tr>
                        <td class="auto-style6">filter:</td>
                        <td class="auto-style5">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style7" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem>---Select filter-------</asp:ListItem>
                                <asp:ListItem>Top 10</asp:ListItem>
                                <asp:ListItem>Bottom 10</asp:ListItem>
                                <asp:ListItem>Highest to Lowest</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>

                <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID"
                    InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid"
                    InternalBorderWidth="1px" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px"
                    ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid"
                    ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226"
                    Height="12in" Width="7.2in" BorderStyle="Solid" BorderWidth="1px" ZoomMode="PageWidth" ShowToolBar="True">
                    <LocalReport ReportPath="Report1.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="IELTSWebAdmin.DataSet1TableAdapters.DataTable1TableAdapter"></asp:ObjectDataSource>

        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
