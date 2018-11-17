using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IELTSWebAdmin
{
    public partial class TemplateMatching : System.Web.UI.Page
    {
        static String[] answer;

        protected void Page_Load(object sender, EventArgs e)
        {
            answer = new String[10];
        }

        protected void AddTextBox(object sender, EventArgs e)
        {
            int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBox("txtDynamic" + index);
        }


        private void CreateTextBox(string id)
        {
            TextBox txt = new TextBox();
            txt.ID = id;
            pnlTextBoxes.Controls.Add(txt);

            Literal lt = new Literal();
            lt.Text = "<br />";
            pnlTextBoxes.Controls.Add(lt);
        }
      

        protected void Page_PreInit(object sender, EventArgs e)
        {
            List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
            int i = 1;
            foreach (string key in keys)
            {
                this.CreateTextBox("txtDynamic" + i);
                i++;
            }
        }

        protected void GetTextBoxValues(object sender, EventArgs e)
        {

            //foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
            //{
            //    message += textBox.ID + ": " + textBox.Text + "\\n";
            //    string cs = "Data Source=VDI-V-PADEE;Initial Catalog=demo;Integrated Security=True";
            //    SqlConnection con = new SqlConnection(cs);
            //    SqlCommand cmd = new SqlCommand("INSERT INTO demo_tbl (val) VALUES('" + textBox.Text + "')", con);
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}

            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
            int j = 0;
            foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
            {
                answer[j] = textBox.Text;
                j++;
            }

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO QUESTION(questionText) VALUES(@Question)"))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Question", insertString(answer));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update Unsuccessful')", true);
            }



        }

        private String insertString(String[] answer)
        {
            string answerString = "";

            for (int i = 0; i < answer.Length; i++)
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