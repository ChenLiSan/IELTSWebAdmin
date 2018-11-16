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
    public partial class TemplateShortQuestion : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        int[] answer = new int[10];

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlNumberOfRows_SelectedIndexChanged(object sender, EventArgs e)
        {

          
            dt.Columns.Add("TextBox");
            int count = Convert.ToInt32(ddlNumberOfRows.SelectedItem.Value);
            for (int i = 0; i < count; i++)
            {
                dt.Rows.Add("");
            }
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                string answer = row[i].ToString();
            }

            i++;

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO QUESTION(questionText, answerOptions) VALUES(@QuestionText, @AnswerOption)"))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@QuestionText", txtQ.Text);
                        cmd.Parameters.AddWithValue("@AnswerOption", answer[i].ToString());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            

        }
    }
}