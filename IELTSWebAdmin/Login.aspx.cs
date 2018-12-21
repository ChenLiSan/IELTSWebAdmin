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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signin_Click(object sender, EventArgs e)
        {
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            string strSelect = "Select staffName, password from staff";

            SqlCommand cmdSelect = new SqlCommand(strSelect, conn);
            SqlDataReader dtrLoginDetail = cmdSelect.ExecuteReader();
            //int staffID = Convert.ToInt32(cmdSelect.ExecuteScalar());
            while (dtrLoginDetail.Read())
            {
                if (txtUsername.Value == dtrLoginDetail.GetString(0))
                    if (txtPass.Value == dtrLoginDetail.GetString(1))
                    {
                        Session["user"] = txtUsername.Value;
                        Response.Redirect("landingPage.aspx", false);
                    }
                    else
                    {
                        lblMessage.Text = "Incorrect username or password";
                    }
            }
            conn.Close();
        }

    }
}