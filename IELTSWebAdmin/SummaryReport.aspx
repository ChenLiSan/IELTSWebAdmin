<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SummaryReport.aspx.cs" Inherits="IELTSWebAdmin.SummaryReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
            
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <div align="center">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID"
                InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid"
                InternalBorderWidth="1px" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px"
                ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid"
                ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226"
                Height="12in" Width="7.2in" BorderStyle="Solid" BorderWidth="1px" ZoomMode="PageWidth" ShowToolBar="True">
                <LocalReport ReportPath="Report2.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="DataSet1" Name="GrammarType" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
