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
    public partial class AdminRegistration1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
        
            //Boolean validUser = true;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            String password = txtPass.Text;
            String cfmPassword = txtConPass.Text;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strCon);

            string strInsert = "Insert into Staff (staffName, gmailID, password ) Values (@staffName, @email, @password)";

            conn.Open();
            SqlCommand cmdInsert;
            cmdInsert = new SqlCommand(strInsert, conn);

            cmdInsert.Parameters.AddWithValue("@staffName", username);
            cmdInsert.Parameters.AddWithValue("@email", email);
            cmdInsert.Parameters.AddWithValue("@password", password);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("AdminLogin.aspx");
        }
        
    }
}