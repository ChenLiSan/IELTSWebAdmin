using System;
using System.Collections.Generic;
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

            int index1 = pnlTextBoxes1.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBox("txtDynamic1" + index1);

        }

        private void CreateTextBox(string id)
        {
            TextBox text = new TextBox();
            text.ID = id;
            pnlTextBoxes.Controls.Add(text);

            //Literal lt = new Literal();
            //pnlTextBoxes.Controls.Add(lt);
            //lt.Text = "<br />";
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
            string message = "";

            foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
            {
                message += textBox.ID + ": " + textBox.Text + "\\n";
                string cs = "Data Source=VDI-V-PADEE;Initial Catalog=demo;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO demo_tbl (val) VALUES('" + textBox.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);

        }
    }
}