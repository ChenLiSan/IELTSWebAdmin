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
    public partial class Report : System.Web.UI.Page
    {
        //IELTSWebAdminDataContext db = new IELTSWebAdminDataContext();

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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = DropDownList1.SelectedValue;

            if (filter == "Top 10")
            {
                DataTable dt = GetSPResult();
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                ReportViewer1.LocalReport.Refresh();
            }
            else if (filter == "Bottom 10")
            {
                DataTable dt = GetSPResult2();
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                ReportViewer1.LocalReport.Refresh();

            }
            else if (filter == "Highest to Lowest")
            {
                DataTable dt = GetSPResult1();
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                ReportViewer1.LocalReport.Refresh();
            }
            
        }


        private DataTable GetSPResult()
        {
            DataTable ResultsTable = new DataTable();


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("Top10", conn);
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

        private DataTable GetSPResult1()
        {
            DataTable ResultsTable = new DataTable();


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("HighToLow", conn);
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

        private DataTable GetSPResult2()
        {
            DataTable ResultsTable = new DataTable();


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("Bottom10", conn);
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