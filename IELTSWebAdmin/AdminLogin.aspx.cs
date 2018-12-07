using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IELTSWebAdmin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
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
                if (txtUsername.Text == dtrLoginDetail.GetString(0))
                    if (txtPass.Text == dtrLoginDetail.GetString(1))
                    {
                        
                        //Session["StaffID"] = staffID;
                        Response.Redirect("landingPage.aspx", false);
                    }
            }
            conn.Close();
        }
    }
}