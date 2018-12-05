using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IELTSWebAdmin
{
    public partial class TemplateMultipleChoice : System.Web.UI.Page
    {

        static DataTable dt;
        static String[] answer;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //Label2.Text = Session["TotalQ"].ToString();

            if (!Page.IsPostBack)
            {
                dt = new DataTable();
                answer = new String[6];

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


        protected void Button1_Click(object sender, EventArgs e)
        {
            ControlCollection gv = this.Repeater1.Controls;
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

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO QUESTION(questionText, answerOptions) VALUES(@QuestionText, @AnswerOption);SELECT MAX(questionID) FROM QUESTION"))
                    
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@QuestionText", txtQ.Text);
                        cmd.Parameters.AddWithValue("@AnswerOption", insertString(answer));
                        con.Open();
                        //cmd.ExecuteNonQuery();
                        int queIDs = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        Session["qID"] = queIDs;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Successfully')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Unsuccessful')", true);
            }

            lblQ.Visible = false;
            txtQ.Visible = false;
            lblAnsOpt.Visible = false;
            ddlNumberOfRows.Visible = false;
            Repeater1.Visible = false;
            Button1.Visible = false;

            Label2.Visible = true;
            ddlCorrectAns.Visible = true;
            btnSave1.Visible = true;

            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dtrAnsOpt;
            conn.Open();

            String strSelect = "Select answerOptions from Question WHERE questionID = @queID";

            int queID = (int)Session["qID"];
            SqlCommand cmdSelect = new SqlCommand(strSelect, conn);
            cmdSelect.Parameters.AddWithValue("@queID", queID);
            dtrAnsOpt = cmdSelect.ExecuteReader();


            if (dtrAnsOpt.HasRows)
            {

                while (dtrAnsOpt.Read())
                {
                    String AnsOpt = dtrAnsOpt.GetString(0);

                    string[] word = AnsOpt.Split('|');
                    foreach (string w in word)
                    {
                        ddlCorrectAns.Items.Add(new ListItem(w, w));
                    }

                }
            }
            else
            {
                lblMessage.Text = "No Record Found!";
            }

            conn.Close();
            dtrAnsOpt.Close();

        }

        private String insertString(String[] answer)
        {
            string answerString = "";

            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] != "")
                {
                    answerString += answer[i] + "|";
                }
            }

            return answerString;
        }


        protected void ddlCorrectAns_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnSave1_Click(object sender, EventArgs e)
        {

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))

            using (SqlCommand cmd = new SqlCommand("UPDATE QUESTION SET answerText = @AnswerText WHERE questionID = @queID"))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@AnswerText", ddlCorrectAns.SelectedValue);
                int queID = (int)Session["qID"];
                cmd.Parameters.AddWithValue("@queID", queID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Successfully')", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Unsuccessful')", true);
            }

            int tq = (int)Session["TotalQ"];

            if (tq > 1)
            {
                Session["TotalQ"] = tq - 1;
                Response.Redirect("TemplateMultipleChoice.aspx");
            }
            else
            {
                Response.Redirect("FormSubsection.aspx");
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}