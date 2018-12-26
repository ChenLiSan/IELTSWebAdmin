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
    public partial class TemplateMatchingAns : System.Web.UI.Page
    {
        static DataTable dt;
        static List<String> question;
        static int[] id;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt = new DataTable();
                question = new List<String>();

                id = new int[5];
            }
        }

        protected void ddlNumberOfRows_SelectedIndexChanged(object sender, EventArgs e)
        {

            dt.Columns.Add("TextBox");
            int count = Convert.ToInt32(ddlNumberOfRows.SelectedItem.Value);
            for (int i = 0; i < count; i++)
            {
                dt.Rows.Add();
            }
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ControlCollection gv = this.Repeater1.Controls;
            int j = 0;


            foreach (Control c in gv)
            {
                foreach (Control childc in c.Controls)
                {
                    if (childc is TextBox)
                    {
                        question.Add ((String)((TextBox)childc).Text);
                        j++;
                    }
                }
            }
         
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))

                using (SqlCommand cmd = new SqlCommand("INSERT INTO SUBSECTION(sectionText) VALUES(@SectionText);SELECT MAX(subsectionID) FROM SUBSECTION"))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@SectionText", txtQ.Text);
                    con.Open();
                   // cmd.ExecuteNonQuery();
                    int subID = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                
           

            for (int a = 0; a < question.Count; a++)
            {

                string constr1 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con1 = new SqlConnection(constr1))

                using (SqlCommand cmd1 = new SqlCommand("INSERT INTO QUESTION(questionText) VALUES(@QuestionText);SELECT MAX(questionID) FROM QUESTION"))
                {
                    cmd1.Connection = con1;
                    cmd1.Parameters.AddWithValue("@QuestionText", question[a]);
                    con1.Open();
                    int maxId = Convert.ToInt32(cmd1.ExecuteScalar());
                    //cmd1.ExecuteNonQuery();
                    con1.Close();
                    id[a] = maxId;
                    Session["ID"] = id;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Successfully')", true);
                }

            }

        }
    }
}