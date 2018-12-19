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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_Click(object sender, EventArgs e)
        {

            //Boolean validUser = true;
            string username = txtUsername.Value;
            string email = txtEmail.Value;
            String password = txtPass.Value;
            String cfmPassword = txtConPass.Value;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strCon);

            string strInsert = "Insert into Staff (staffName, gmailID, password ) Values (@staffName, @gmailID, @password)";

            conn.Open();
            SqlCommand cmdInsert;
            cmdInsert = new SqlCommand(strInsert, conn);

            cmdInsert.Parameters.AddWithValue("@staffName", username);
            cmdInsert.Parameters.AddWithValue("@gmailID", email);
            cmdInsert.Parameters.AddWithValue("@password", password);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Login.aspx");
        }
    }
}