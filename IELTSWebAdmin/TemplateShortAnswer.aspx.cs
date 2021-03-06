﻿using Firebase.Database;
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
    public partial class TemplateShortAnswer : System.Web.UI.Page
    {
        static DataTable dt;
        static String[] answer;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                dt = new DataTable();
                answer = new String[5];
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
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO QUESTION(questionText, answerText) VALUES(@QuestionText, @AnswerText)"))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@QuestionText", txtQ.Text);
                        cmd.Parameters.AddWithValue("@AnswerText", insertString(answer));
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

            write();
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

                    SqlCommand myCommand = new SqlCommand("Select * from question", conn);
                    //myCommand.Parameters.AddWithValue("@id", queID);
                    conn.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
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
                        Response.Redirect("TemplateShortAnswer.aspx");
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
    }
}