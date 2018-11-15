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
    public partial class TemplateAnalyticDiagram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnUpload_Click(object sender, EventArgs e)
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
                        Label1.Text = ex.Message.ToString();
                    }
                }

            }
            else
            {
                Label1.Text = "Choose a valid audio file";
            }
            conn.Close();
        }
    }
}