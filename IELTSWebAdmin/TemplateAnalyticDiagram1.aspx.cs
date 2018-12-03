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
    public partial class TemplateAnalyticDiagram1 : System.Web.UI.Page
    {
        static DataTable dt;
        DropDownList ddl1;
        static string[] word;
        static DataTable dataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
          
            int tq = (int)Session["TotalQ"];
            
            if (!Page.IsPostBack)
            {
                dt = new DataTable();

            }


            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dtrAnsOpt;
            conn.Open();

            String strSelect = "Select answerOptions from Question WHERE questionID = @queID";

            int queID = (int)Session["qID"];
            SqlCommand cmdSelect = new SqlCommand(strSelect, conn);
            cmdSelect.Parameters.AddWithValue("@queID", queID);
            dtrAnsOpt = cmdSelect.ExecuteReader();
            dataTable = new DataTable();
 
            if (dtrAnsOpt.HasRows)
            {

                while (dtrAnsOpt.Read())
                {
                    String AnsOpt = dtrAnsOpt.GetString(0);


                    dt.Columns.Add("DropDownList");
                    dataTable.Columns.Add("DropDownList");
                    word = AnsOpt.Split('|');


                }
            }

            else
            {
                lblMessage.Text = "No Record Found!";
            }

                    conn.Close();
                    dtrAnsOpt.Close();

                    dt.Columns.Add("Label");
                    for (int i = 0; i < tq; i++)
                    {
                        dt.Rows.Add();

                    }
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();

                
            
        }

        protected void btnSave1_Click(object sender, EventArgs e)
        {
            
            
            //try
            //{
            //    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //    using (SqlConnection con = new SqlConnection(constr))

            //    using (SqlCommand cmd = new SqlCommand("UPDATE QUESTION SET answerText = @AnswerText WHERE questionID = @queID"))
            //    {
            //        cmd.Connection = con;
            //        cmd.Parameters.AddWithValue("@AnswerText", ddlCorrectAns.SelectedValue);
            //        int queID = (int)Session["qID"];
            //        cmd.Parameters.AddWithValue("@queID", queID);
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Successfully')", true);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Unsuccessful')", true);
            //}

            Response.Redirect("FormSubsection.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }   

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {   

                DropDownList ddl1 = (DropDownList)e.Item.FindControl("ddl1");
                foreach (string w in word)
                {
                    if (!w.Equals(""))
                    {
                        ddl1.Items.Add(w);
                    }
                }
                   

            }
        }


        protected void ddlCorrectAns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}