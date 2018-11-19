﻿using System;
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

        protected void txtTextBox1_TextChanged(object sender, EventArgs e)
        {
            String text = txtTextBox1.text;
            ddlCorrectAns.Items.Add(text);
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
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO QUESTION(questionText, answerOptions) VALUES(@QuestionText, @AnswerOption)"))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@QuestionText", txtQ.Text);
                        cmd.Parameters.AddWithValue("@AnswerOption", insertString(answer));
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

            lblQ.Visible = false;
            txtQ.Visible = false;
            lblAnsOpt.Visible = false;
            ddlNumberOfRows.Visible = false;
            Repeater1.Visible = false;
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
    }
}