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
    public partial class TemplateMatchingAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getAnswerOpt(ddlAnswerOpt);
        }

        protected void ddlAnswerOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void getAnswerOpt(DropDownList ddl)
        { 

            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataReader dtrAnsOpt;
            conn.Open();

            String strSelect = "Select DISTINCT answerOptions from Question";

            SqlCommand cmdSelect = new SqlCommand(strSelect, conn);

            dtrAnsOpt = cmdSelect.ExecuteReader();


            if (dtrAnsOpt.HasRows)

            {

                while (dtrAnsOpt.Read())
                {
                    String answerOptions = dtrAnsOpt.GetString(0);

                    ddlAnswerOpt.Items.Add(new ListItem(answerOptions, answerOptions));

                }
            }
            else
            {
                lblMessage.Text = "No Record in Staff List!";
            }

            conn.Close();
            dtrAnsOpt.Close();
        }
    }
}