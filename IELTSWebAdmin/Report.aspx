<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="IELTSWebAdmin.Report" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<!DOCTYPE html>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <style>
        html,body,form,#div1 {
            height: 100%; 
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
          <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="100%" Width="100%" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" AsyncRendering="False">
              <localreport reportpath="Report1.rdlc">
                  <datasources>
                      <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                  </datasources>
              </localreport>
        </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="IELTSWebAdmin.DataSet1TableAdapters.DataTable1TableAdapter" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
        </div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    </form>
    </body>
</html>
