using Firebase.Database;
using Firebase.Database.Query;
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
        static int totalQ ;
        static String address = "";
        static String url;
        static String type;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["TotalQ"] != null)
            {
                totalQ = (int)HttpContext.Current.Session["TotalQ"];
            }
            else
            {
                HttpContext.Current.Session["TotalQ"] = 0;
                Session["imageurl"] = "";
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["typeofsection"] = DropDownList1.SelectedValue;
            Session["address"] = "TemplateMatchingAns.aspx";

            if (DropDownList1.SelectedValue.Equals("Matching"))
            {
                Session["address"] = "TemplateMatchingAns.aspx";
                Label3.Visible = false;
                FileUpload1.Visible = false;
                btnUpload.Visible = false;
                Label4.Visible = false;
                Label2.Visible = false;
                ddlQ.Visible = false;
            }
            else if (DropDownList1.SelectedValue.Equals("Multiple Choice"))
            {
                Session["address"] = "TemplateMultipleChoice.aspx";
                Label3.Visible = false;
                FileUpload1.Visible = false;
                btnUpload.Visible = false;
                Label4.Visible = false;
                Label2.Visible = true;
                ddlQ.Visible = true;
            }
            else if (DropDownList1.SelectedValue.Equals("Form, Note, Table"))
            {
                Session["address"] = "TemplateAnalyticDiagram.aspx";
                Label3.Visible = true;
                FileUpload1.Visible = true;
                btnUpload.Visible = true;
                Label4.Visible = true;
                Label2.Visible = true;
                ddlQ.Visible = true;
            }
            else if (DropDownList1.SelectedValue.Equals("Sentences Completion"))
            {
                Session["address"] = "TemplateSentenceCompletion.aspx";
                Label3.Visible = false;
                FileUpload1.Visible = false;
                btnUpload.Visible = false;
                Label4.Visible = false;
                Label2.Visible = true;
                ddlQ.Visible = true;

            }
            else if (DropDownList1.SelectedValue.Equals("Short Answer"))
            {
                Session["address"] = "TemplateShortAnswer.aspx";
                Label3.Visible = false;
                FileUpload1.Visible = false;
                btnUpload.Visible = false;
                Label4.Visible = false;
                Label2.Visible = true; ;
                ddlQ.Visible = true;
            }
            else if (DropDownList1.SelectedValue.Equals("Plan, Map, Diagram labeling"))
            {
                Session["address"] = "TemplateAnalyticDiagram.aspx";
                Label3.Visible = true;
                FileUpload1.Visible = true;
                btnUpload.Visible = true;
                Label4.Visible = true;
                Label2.Visible = true;
                ddlQ.Visible = true;
            }
        }

        protected void ddlQ_SelectedIndexChanged(object sender, EventArgs e)
        {
                Session["TotalQ"] = int.Parse(ddlQ.SelectedValue); 
        }

        protected async void btnProceed_Click(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            try
            {
                url = (String)Session["imageurl"];
                type = (String)Session["typeofsection"];

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT INTO SUBSECTION (totalQuestions, typeOfQuestion,imageurl, section, sectionText) VALUES (@t, @toQ, @url, @section, @sectionText);";
                cmd.Connection = conn;

                SqlParameter photoUrlParameter = new SqlParameter("@url", url);
                cmd.Parameters.Add(photoUrlParameter);
                cmd.Parameters.Add(new SqlParameter("@t", totalQ));
                cmd.Parameters.Add(new SqlParameter("@toq", type));
                int id= (int)Session["sID"];
                
                cmd.Parameters.Add(new SqlParameter("@section", id));
                cmd.Parameters.Add(new SqlParameter("@sectionText", txtSecText.Text));

               cmd.ExecuteNonQuery();
               conn.Close();

                write();


            }
            catch (Exception ex)
            {
                Label4.Text = ex.Message.ToString();
            }
           
        }

        protected async void btnUpload_ClickAsync(object sender, EventArgs e)
        {
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
                Session["imageurl"] = url;

                if (url != "")
                {
                    
                    Label3.Text = "Photo Uploaded ";
                }

            }
            else
            {
                Label4.Text = "Choose a valid image file";
            }
            
        }

        public async void write() {
            try
            {
                Subsection1 s1 = new Subsection1();
                s1.imageurl = url;
                s1.sectionText = txtSecText.Text;
                s1.totalQuestion = totalQ;
                s1.typeofQuestion = type;

                String sec = (String)Session["sectionKeyFire"];
                String sectioncat = (String)Session["sectionCatFire"];

                var firebase = new FirebaseClient("https://ielts-9c8f1.firebaseio.com/");

                // add new item to list of data and let the client generate new key for you (done offline)
                var dino = await firebase
                  .Child("section")
                  .Child(sectioncat)
                  .Child(sec)
                  .Child("subsection")
                  .PostAsync(s1);

                if (dino.Key != null)
                {
                    Session["subsectionKeyFire"] = dino.Key;


                    address = (string)Session["address"];
                    totalQ = (int)Session["TotalQ"];
                    Session["TotalQ"] = totalQ;

                    Response.Redirect(address);
                }
            }
            catch (Exception ex)
            {

            }

            

            
        }

    }
}