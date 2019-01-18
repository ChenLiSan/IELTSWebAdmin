using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IELTSWebAdmin
{
    public partial class SummaryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set the processing mode for the ReportViewer to Local  
                ReportViewer1.ProcessingMode = ProcessingMode.Local;


                DataTable dt = GetSPResult();
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.ReportPath = "Report2.rdlc";
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                //ReportViewer1.LocalReport.Refresh();

            }
        }


        private DataTable GetSPResult()
        {
            DataTable ResultsTable = new DataTable();


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("Summary", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Month", DropDownList1.SelectedValue);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ResultsTable);
            }

            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return ResultsTable;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerateReport.aspx");
        }
    }
}