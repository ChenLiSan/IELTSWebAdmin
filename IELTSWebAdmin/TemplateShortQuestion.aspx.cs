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
        static DataTable dt;
        static String[] answer;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt = new DataTable();
                answer = new String[10];
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
            //DataTable dt2 = (DataTable)Repeater1.DataSource;
            ControlCollection gv =  this.Repeater1.Controls;
            int j = 0;

        
            foreach (Control c in gv)
            {
                foreach (Control childc in c.Controls)
                {
                    if (childc is TextBox)
                    {
                        answer[j] = (String)((TextBox)childc).Text;
                        j++;
                    }
                }
            }
         


            


            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO QUESTION(questionText, answerOptions) VALUES(@QuestionText, @AnswerOption)"))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@QuestionText", txtQ.Text);
                    cmd.Parameters.AddWithValue("@AnswerOption", insertString(answer));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }


        }

        private String insertString(String[] answer)
        {
            string answerString = "";

            for (int i = 0; i <answer.Length; i++)
            {
                if (answer[i] != "")
                {
                    answerString += answer[i] + ",";
                }
            }

            return answerString;
        }



    }
}