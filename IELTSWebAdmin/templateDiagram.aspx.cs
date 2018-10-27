using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace IELTSWebAdmin
{
    public partial class templateDiagram : System.Web.UI.Page
    {
        int num = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                int num = 0;
                if (Session["controlnum"] != null)
                    num = (int)Session["controlnum"];

                for (int i = 0; i < num; i++)
                {
                    TextBox t = (TextBox)Page.FindControl("Textbox" + (i + 1));
                    t.ID = "Textbox" + (i + 1);
                    t.Text = (String)Session["tbtext " + (i + 1)];
                }
            }
            else
            {
                int num = 0;
                for (int i = 0; i < num; i++)
                {
                    TextBox t = (TextBox)Page.FindControl("Textbox" + (i + 1));
                    Session["tbtext " + (i + 1)] = t.Text;
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (Session["controlnum"] != null)
                num = (int)Session["controlnum"];
            else
                Session["controlnum"] = 0;


            num++;

            for (int i = 0; i < num; i++)
            {
                TextBox myLabel = new TextBox();
                // Set the label's Text and ID properties.
                // myLabel.Text = "texbox" + (i + 1);
                myLabel.ID = "Textbox" + (i + 1);
                PlaceHolder1.Controls.Add(myLabel);
                myLabel.ViewStateMode = System.Web.UI.ViewStateMode.Enabled;
                myLabel.EnableViewState = true;
                // Add a spacer in the form of an HTML <br /> element.
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));

            }

            Session["controlnum"] = num;


        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn1 = new SqlConnection(strConn);
            conn1.Open();

            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName.ToString();
                string uploadFolderPath = "~/Image/";
                string filePath = HttpContext.Current.Server.MapPath(uploadFolderPath);
                FileUpload1.SaveAs(filePath + "\\" + fileName);
                //Image1.ImageUrl = "~/Image/" + "/" + FileUpload1.FileName.ToString();
            }

            
            //SqlCommand cmd3 = new SqlCommand("insert into Image1(image1) values('" + ImageButton1.ImageUrl + "')", conn1);
            //cmd3.ExecuteNonQuery();

            conn1.Close();
        }
    }    

}