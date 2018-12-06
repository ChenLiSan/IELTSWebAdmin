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
    public partial class AddExamSession : System.Web.UI.Page
    {
        private static DateTime date;
        private static int hour;
        private static int minute;
        private static int validity;
        private static DateTime time;
        private static DateTime t;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                minute = int.Parse(ddlMinute.SelectedValue);
                date = Calendar1.TodaysDate;
                hour = int.Parse(ddlHour.SelectedValue);
                validity = int.Parse(DropDownList1.SelectedValue);
            }
        }

        protected void ddlMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            minute = int.Parse(ddlMinute.SelectedValue);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            date  = Calendar1.SelectedDate;
        }

        protected void ddlHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            hour = int.Parse(ddlHour.SelectedValue);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            validity = int.Parse(DropDownList1.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            t = date.Date;
            time = t;
            time = time.AddHours((Double)hour);
            time = time.AddMinutes((Double)minute);
            date = time;
            t = t.AddHours(validity);

            if (save())
            {
                Label1.Text = "Successful";
            }
            else {
               Label1.Text = "Failed";
            }
        }

        private Boolean save() {
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Session (startTime, date, validPeriod) VALUES (@time, @date, @valid);";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SqlParameter("@time", time.TimeOfDay));
                cmd.Parameters.Add(new SqlParameter("@date", date));
                cmd.Parameters.Add(new SqlParameter("@valid", t.TimeOfDay));
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                return false;
            }
        }

        
    }
}