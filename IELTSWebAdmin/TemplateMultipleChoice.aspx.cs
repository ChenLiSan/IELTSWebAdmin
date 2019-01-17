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
using Firebase.Database;
using Firebase.Database.Query;

namespace IELTSWebAdmin
{
    public partial class TemplateMultipleChoice : System.Web.UI.Page
    {

        static DataTable dt;
        static String[] answer;
        static int queID;


        protected void Page_Load(object sender, EventArgs e)
        {
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

            lbl1.Enabled = false;
            lblQ.Enabled = false;
            txtQ.Enabled = false;
            lblAnsOpt.Enabled = false;
            ddlNumberOfRows.Enabled = false;
            Repeater1.Visible = false;
            Button1.Enabled = false;

            lbl2.Enabled = true;
            Label2.Enabled = true;
            ddlCorrectAns.Enabled = true;
            btnSave1.Enabled = true;

            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dtrAnsOpt;
            conn.Open();

            String strSelect = "Select answerOptions from Question WHERE questionID = @queID";

            queID = (int)Session["qID"];
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
                queID = (int)Session["qID"];
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

            write();


        }

        public async void write()
        {
            String sec = (String)Session["sectionKeyFire"];
            String sectioncat = (String)Session["sectionCatFire"];
            String subsec = (String)Session["subsectionKeyFire"];


            var firebase = new FirebaseClient("https://ielts-9c8f1.firebaseio.com/");

            Question1 q1 = new Question1();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    SqlCommand myCommand = new SqlCommand("Select * from question where questionID = @id;", conn);
                    myCommand.Parameters.AddWithValue("@id", queID);
                    conn.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        q1.answerOptions = myReader["answerOptions"].ToString();
                        q1.sequence = 1;
                        q1.answerText = myReader["answerText"].ToString();
                        q1.questionText = myReader["questionText"].ToString();
                    }

                    var dino = await firebase
                    .Child("section")
                    .Child(sectioncat)
                    .Child(sec)
                    .Child("subsection")
                    .Child(subsec)
                    .Child("question")
                    .PostAsync(q1);

                    int tq = (int)Session["TotalQ"];

                    if (dino.Key != null && tq > 1)
                    {
                        Session["TotalQ"] = tq - 1;
                        Response.Redirect("TemplateMultipleChoice.aspx");
                    }
                    else
                    {
                        Response.Redirect("FormSubsection.aspx");
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }



        }


            protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}