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
        protected void Page_Load(object sender, EventArgs e)
        {

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
            //string message = "";

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

            foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; 
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO QUESTION(questionText) VALUES(@Question)"))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Question", textBox.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }


        }
    }
}