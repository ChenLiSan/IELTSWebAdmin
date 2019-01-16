using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
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
    public partial class TemplateAnalyticDiagram : System.Web.UI.Page
    {
        //declare for repeater1
        static DataTable dt;
        static String[] answer;
        //declare for repeater2
        static DataTable dt1;
        DropDownList ddl1;
        static string[] word;
        static DataTable dataTable;
        static String[] answer1;
        int tq;
        static int [] qID;

        protected void Page_Load(object sender, EventArgs e)
        {
            tq = (int)Session["TotalQ"];

            if (!Page.IsPostBack)
            {
                //declare for repeater1
                dt = new DataTable();
                answer = new String[10];
                //declare for repeater2
                dt1 = new DataTable();
                answer1 = new String[15];

                qID = new int[tq];
                int y = 0;
            }
        }


        protected void ddlNumberOfRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            dt.Columns.Add();
            //add textbox according user's selection
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
            //find textbox control in repeater1
            ControlCollection gv = this.Repeater1.Controls;
            int j = 0;

            //retrieve text in each of the textbox
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
            //insert answerOptions into db
            for(int i=0; i<tq; i++) { 
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO QUESTION(answerOptions) VALUES(@AnswerOptions);SELECT MAX(questionID) FROM QUESTION"))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@AnswerOptions", insertString(answer));
                        con.Open();
                        int queIDs = Convert.ToInt32(cmd.ExecuteScalar());
                       // cmd.ExecuteNonQuery();
                        con.Close();
                        qID[i] = queIDs;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Successfully')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insert Unsuccessful')", true);
            }
                }
            //Response.Redirect("TemplateAnalyticDiagram1.aspx");

            //retrieve answer options and dislay it into dynamic ddl
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dtrAnsOpt;
            conn.Open();

            String strSelect = "Select answerOptions from Question WHERE questionID = @queID";

            SqlCommand cmdSelect = new SqlCommand(strSelect, conn);
            cmdSelect.Parameters.AddWithValue("@queID", qID[0]);
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
            
            dt1.Columns.Add("Label");
            for (int i = 0; i < tq; i++)
            {
                dt1.Rows.Add();
            }
            this.Repeater2.DataSource = dt1;
            this.Repeater2.DataBind();

            btnProceed.Enabled = true;
        }


        //make all the answer become a string and save to db
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

        //add answerOptions to dynamic ddl
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

        protected void btnProceed_Click(object sender, EventArgs e)
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

            for (int i = 0; i < tq; i++)
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))

                    using (SqlCommand cmd = new SqlCommand("UPDATE QUESTION SET answerText = @AnswerText WHERE questionID = @queID"))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@AnswerText", answer1[i]);
                        cmd.Parameters.AddWithValue("@queID", qID[i]);
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

        public async void write() {
            String sec = (String)Session["sectionKeyFire"];
            String sectioncat = (String)Session["sectionCatFire"];
            String subsec = (String) Session["subsectionKeyFire"];


            var firebase = new FirebaseClient("https://ielts-9c8f1.firebaseio.com/");

            for (int i = 0; i < tq; i++) {
                Question1 q1 = new Question1();
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(constr))
                    {

                        SqlCommand myCommand = new SqlCommand("Select * from question where questionID = @id;",conn);
                        myCommand.Parameters.AddWithValue("@id", qID[i]);
                        conn.Open();
                        SqlDataReader myReader = myCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            q1.answerOptions = myReader["answerOptions"].ToString();
                            q1.sequence = i+1;
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

                        if (dino.Key != null && i==tq-1)
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