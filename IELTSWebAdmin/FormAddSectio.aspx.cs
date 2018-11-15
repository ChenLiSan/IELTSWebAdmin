 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using Firebase.Storage;
using System.Threading.Tasks;
using System.Data;

namespace IELTSWebAdmin
{
    public partial class FormAddSectio : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //Console.WriteLine("Page clicked");
            //Console.WriteLine("Page clicked");
            //Console.WriteLine("Page clicked");
            //try
            //{

            //}
            //catch (SqlException ex)
            //{

            //}

            conn.Close();

        }

        byte[] buffer;
        //this is the array of bytes which will hold the data (file)


        protected async void ButtonUpload_Click1(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //check the file
            Console.Write("Button clicked");
            //if (FileUpload1.HasFile && FileUpload1.PostedFile != null
            //    && FileUpload1.PostedFile.FileName != "")
            //{
            HttpPostedFile file = FileUpload1.PostedFile;
            //retrieve the HttpPostedFile object

            //buffer = new byte[file.ContentLength];
            //int bytesReaded = file.InputStream.Read(buffer, 0,
            //                  FileUpload1.PostedFile.ContentLength);
            //the HttpPostedFile has InputStream porperty (using System.IO;)
            //which can read the stream to the buffer object,
            //the first parameter is the array of bytes to store in,
            //the second parameter is the zero index (of specific byte)
            //where to start storing in the buffer,
            //the third parameter is the number of bytes 


            string filePath, fileName;
            if (FileUpload1.PostedFile != null)
            {
                filePath = FileUpload1.PostedFile.FileName; // file name with path.
                fileName = FileUpload1.FileName;// Only file name.
                var stream = FileUpload1.PostedFile.InputStream;

                // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                var task = new FirebaseStorage("ielts-9c8f1.appspot.com")
                     .Child("data")
                     .Child("audio")
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

                        cmd.CommandText = "INSERT INTO Audio (url) OUTPUT Inserted.audioid VALUES (@url);";
                        cmd.CommandText = "INSERT INTO Section (category) VALUES (@category);";
                        cmd.Connection = conn;
                        
                        SqlParameter audioUrlParameter = new SqlParameter("@url", url);
                        cmd.Parameters.Add(audioUrlParameter);

                        SqlParameter categoryParameter = new SqlParameter("@category", ddlSection.SelectedItem.Value);
                        cmd.Parameters.Add(categoryParameter);

                        int i = (int)cmd.ExecuteScalar();
                        //int i = (int)IDParameter.Value;
                        Label1.Text = "video Uploaded ";
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





        public new bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {

        }
    }
}






