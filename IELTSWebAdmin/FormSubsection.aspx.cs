using Firebase.Storage;
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
    public partial class FormSubsection : System.Web.UI.Page
    {
        int totalQ ;
        String address = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["TotalQ"] != null)
            {
                totalQ = (int)HttpContext.Current.Session["TotalQ"];
            }
            else
            {
                HttpContext.Current.Session["TotalQ"] = 0;
            }

            //if (HttpContext.Current.Session["TotalQ"].Equals(0))
            //{
            //    Response.Redirect("FormAddSectio.aspx");
            //}
            //else
            //{
            //    Response.Redirect("FormSubsection.aspx");
               
            //}
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DropDownList1.SelectedValue.Equals("Matching"))
            {
                address = "TemplateMatchingAns.aspx";
                Label3.Visible = false;
                FileUpload1.Visible = false;
                btnUpload.Visible = false;
                Label4.Visible = false;
            }
            else if (DropDownList1.SelectedValue.Equals("Multiple Choice"))
            {
                address = "TemplateMultipleChoice.aspx";
                Label3.Visible = false;
                FileUpload1.Visible = false;
                btnUpload.Visible = false;
                Label4.Visible = false;
            }
            else if (DropDownList1.SelectedValue.Equals("Form, Note, Table"))
            {
                address = "TemplateAnalyticDiagram.aspx";
                Label3.Visible = true;
                FileUpload1.Visible = true;
                btnUpload.Visible = true;
                Label4.Visible = true;
            }
            else if (DropDownList1.SelectedValue.Equals("Sentences Completion"))
            {
                address = "TemplateSentenceCompletion.aspx";
                Label3.Visible = false;
                FileUpload1.Visible = false;
                btnUpload.Visible = false;
                Label4.Visible = false;
            }
            else if (DropDownList1.SelectedValue.Equals("Short Answer"))
            {
                address = "TemplateShortAnswer.aspx";
                Label3.Visible = false;
                FileUpload1.Visible = false;
                btnUpload.Visible = false;
                Label4.Visible = false;
            }
            else if (DropDownList1.SelectedValue.Equals("Plan, Map, Diagram labeling"))
            {
                address = "TemplateMap.aspx";
                Label3.Visible = true;
                FileUpload1.Visible = true;
                btnUpload.Visible = true;
                Label4.Visible = true;

            }
        }

        protected void ddlQ_SelectedIndexChanged(object sender, EventArgs e)
        {
                Session["TotalQ"] = int.Parse(ddlQ.SelectedValue); 
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            Response.Redirect(address);
        }

        protected async void btnUpload_ClickAsync(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //check the file
            Console.Write("Button clicked");
            HttpPostedFile file = FileUpload1.PostedFile;



            string filePath, fileName;
            if (FileUpload1.PostedFile != null)
            {
                filePath = FileUpload1.PostedFile.FileName; // file name with path.
                fileName = FileUpload1.FileName;// Only file name.
                var stream = FileUpload1.PostedFile.InputStream;

                // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                var task = new FirebaseStorage("ielts-9c8f1.appspot.com")
                     .Child("data")
                     .Child("photo")
                     .Child(FileUpload1.FileName)
                     .PutAsync(stream);

                // Track progress of the upload
                task.Progress.ProgressChanged += (s, er) => Console.WriteLine($"Progress: {er.Percentage} %");

                String url = "";
                url = await task;

                if (url != "")
                {
                    try
                    {


                        SqlCommand cmd = new SqlCommand();

                        cmd.CommandText = "INSERT INTO IMAGE1 (url) VALUES (@url);";
                        cmd.Connection = conn;

                        SqlParameter photoUrlParameter = new SqlParameter("@url", url);
                        cmd.Parameters.Add(photoUrlParameter);

                        int i = (int)cmd.ExecuteScalar();
                        Label3.Text = "Photo Uploaded ";
                        conn.Close();

                    }
                    catch (Exception ex)
                    {
                        Label4.Text = ex.Message.ToString();
                    }
                }

            }
            else
            {
                Label4.Text = "Choose a valid audio file";
            }
            conn.Close();
        }

        protected async void btnUpload_Click(object sender, EventArgs e)
        {
            
        }
    }
}