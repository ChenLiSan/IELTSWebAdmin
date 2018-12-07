using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IELTSWebAdmin
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // Set the processing mode for the ReportViewer to Local  
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                //LocalReport localReport = ReportViewer1.LocalReport;

                ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                ReportViewer1.LocalReport.Refresh();





            }
            //// Create the sales order number report parameter  
            //ReportParameter rpSalesOrderNumber = new ReportParameter();
            //rpSalesOrderNumber.Name = "SalesOrderNumber";
            //rpSalesOrderNumber.Values.Add("SO43661");

            //// Set the report parameters for the report  
            //localReport.SetParameters(
            //    new ReportParameter[] { rpSalesOrderNumber });
        }



    }
}