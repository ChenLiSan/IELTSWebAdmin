using Firebase.Database;
using Firebase.Database.Query;
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
    public partial class TemplateMatchingAnsOpt : System.Web.UI.Page
    {
        static DataTable dt;
        static String[] answer;
        static List<int> id;
        static List<String> queText;
        static string[] word;
        static String[] answer1;

        static DataTable dt1;
        static DataTable dt2;
        static DataTable dataTable;
        static int sessionI = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = (List<int>)Session["ID"];
            queText = (List<string>)Session["queText"];

            //lblMessage.Text = id.Count.ToString();


            if (!Page.IsPostBack)
            {
                Session["queIndex"] = 0;
                dt = new DataTable();
                dt1 = new DataTable();
                dt2 = new DataTable();
                answer = new String[5];
                answer1 = new String[15];
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

        protected void btnProceed_Click(object sender, EventArgs e)
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

            for (int i = 0; i < id.Count; i++)
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE QUESTION SET answerOptions = @AnswerOptions WHERE questionID = @queID"))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@AnswerOptions", insertString(answer));
                            cmd.Parameters.AddWithValue("@queID", id[i]);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Successfully')", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Unsuccessful')", true);
                }

            }

            //retrieve answer options and dislay it into dynamic ddl
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dtrAnsOpt;
            conn.Open();

            String strSelect = "Select answerOptions from Question WHERE questionID = @queID";

            SqlCommand cmdSelect = new SqlCommand(strSelect, conn);
            cmdSelect.Parameters.AddWithValue("@queID", id[0]);
            dtrAnsOpt = cmdSelect.ExecuteReader();
            dataTable = new DataTable();

            if (dtrAnsOpt.HasRows)
            {
                while (dtrAnsOpt.Read())
                {
                    String AnsOpt = dtrAnsOpt.GetString(0);

                    dt1.Columns.Add("DropDownList");
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

            sessionI = (int)Session["queIndex"];



            dt1.Columns.Add("Label");
            for (int i = 0; i < id.Count; i++)
            {
                dt1.Rows.Add(queText[sessionI]);
            }
            this.Repeater3.DataSource = dt1;
            this.Repeater3.DataBind();

            this.Repeater2.DataSource = dt1;
            this.Repeater2.DataBind();

            sessionI++;
            Session["queIndex"] = sessionI;


            btnProceed.Enabled = false;
            ddlNumberOfRows.Enabled = false;
            btnProceed2.Enabled = true;
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

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddl2 = (DropDownList)e.Item.FindControl("ddl2");
               
                foreach (string w in word)
                {
                    if (!w.Equals(""))
                    {
                        ddl2.Items.Add(w);
                    }
                }
            }

        }

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbl3 = (Label)e.Item.FindControl("label3") as Label;
                sessionI = (int)Session["queIndex"];
                lbl3.Text = queText[sessionI];
                sessionI++;
                Session["queIndex"] = sessionI;

                
            }
        }

        protected void btnProceed2_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnProceed2_Click1(object sender, EventArgs e)
        {
            ControlCollection gv = this.Repeater2.Controls;
            int j = 0;


            foreach (Control c in gv)
            {
                foreach (Control childc in c.Controls)
                {
                    if (childc is DropDownList)
                    {
                        answer1[j] = (String)((DropDownList)childc).SelectedValue;
                        j++;
                    }
                }
            }

            for (int i = 0; i < id.Count; i++)
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))

                    using (SqlCommand cmd = new SqlCommand("UPDATE QUESTION SET answerText = @AnswerText WHERE questionID = @queID"))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@AnswerText", answer1[i]);
                        cmd.Parameters.AddWithValue("@queID", id[i]);
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
            }
            write();
        }

        public async void write()
        {
            String sec = (String)Session["sectionKeyFire"];
            String sectioncat = (String)Session["sectionCatFire"];
            String subsec = (String)Session["subsectionKeyFire"];

            var firebase = new FirebaseClient("https://ielts-9c8f1.firebaseio.com/");

            for (int i = 0; i < id.Count; i++)
            {
                Question1 q1 = new Question1();
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(constr))
                    {

                        SqlCommand myCommand = new SqlCommand("Select * from question where questionID = @id;", conn);
                        myCommand.Parameters.AddWithValue("@id", id[i]);
                        conn.Open();
                        SqlDataReader myReader = myCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            q1.answerOptions = myReader["answerOptions"].ToString();
                            q1.sequence = i + 1;
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

                        if (dino.Key != null && i == id.Count - 1)
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


        }
    }
    }
