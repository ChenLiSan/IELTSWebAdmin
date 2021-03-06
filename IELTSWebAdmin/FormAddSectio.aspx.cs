﻿ using System;
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
using Firebase.Database;
using Firebase.Database.Query;

namespace IELTSWebAdmin
{
    public partial class FormAddSectio : System.Web.UI.Page
    {
        int sectionNum;
        static String audiourl;

        protected void Page_Load(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            conn.Close();

            if (!IsPostBack)
            {
                Session["currentQ"] = 1;
            }
            
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
                     .Child("audio")
                     .Child(FileUpload1.FileName)
                     .PutAsync(stream);

                // Track progress of the upload
                task.Progress.ProgressChanged += (s, er) => Console.WriteLine($"Progress: {er.Percentage} %");

                String url = "";
                url = await task;
                audiourl = url;

                if (url != "")
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "INSERT INTO Section (audio) VALUES (@url);SELECT MAX(sectionID) FROM Section";
                        cmd.Connection = conn;
                        SqlParameter audioUrlParameter = new SqlParameter("@url", url);
                        cmd.Parameters.Add(audioUrlParameter);
                        int secIDs = Convert.ToInt32(cmd.ExecuteScalar());
                        Session["sID"] = secIDs;
                        conn.Close();

                        conn.Open();
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "UPDATE Section SET category = @category WHERE sectionID = @secID";
                        cmd1.Connection = conn;
                        int c = int.Parse(ddlSection.SelectedItem.Text);
                        SqlParameter categoryParameter = new SqlParameter("@category", c);
                        cmd1.Parameters.Add(categoryParameter);
                        int secID = (int)Session["sID"];
                        cmd1.Parameters.AddWithValue("@secID", secID);

                        int i = (int)cmd1.ExecuteNonQuery();
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

        protected async void btnProceed_Click(object sender, EventArgs e)
        {

            try
            {
                sectionNum = int.Parse(ddlSection.SelectedValue);
                String sectioncat = "section1";

                if (sectionNum == 1) { sectioncat = "section1"; }
                else if (sectionNum == 2) { sectioncat = "section2"; }
                else if (sectionNum == 3) { sectioncat = "section3"; }
                else if (sectionNum == 4) { sectioncat = "section4"; }

                Section1 q = new Section1();
                q.audio = audiourl;


                var firebase = new FirebaseClient("https://ielts-9c8f1.firebaseio.com/");

                // add new item to list of data and let the client generate new key for you (done offline)
                var dino = await firebase
                  .Child("section")
                  .Child(sectioncat)
                  .PostAsync(q);

                if (dino.Key != null) {

                    Session["sectionKeyFire"] = dino.Key;
                    Session["sectionCatFire"] = sectioncat;

                    if (ddlSection.SelectedValue.Equals(""))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select section number')", true);

                    }
                    else
                    {
                        Response.Redirect("FormSubsection.aspx");
                    }
                }
            }
            catch (Exception ex) {

                string g = "";
            }

         }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}






