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


        protected void ButtonUpload_Click1(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //check the file
            Console.Write("Button clicked");
            if (FileUpload1.HasFile && FileUpload1.PostedFile != null
                && FileUpload1.PostedFile.FileName != "")
            {
                HttpPostedFile file = FileUpload1.PostedFile;
                //retrieve the HttpPostedFile object

                buffer = new byte[file.ContentLength];
                int bytesReaded = file.InputStream.Read(buffer, 0,
                                  FileUpload1.PostedFile.ContentLength);
                //the HttpPostedFile has InputStream porperty (using System.IO;)
                //which can read the stream to the buffer object,
                //the first parameter is the array of bytes to store in,
                //the second parameter is the zero index (of specific byte)
                //where to start storing in the buffer,
                //the third parameter is the number of bytes 
              

                if (bytesReaded > 0)
                {
                    try
                    {
                        

                        SqlCommand cmd = new SqlCommand();
                       
                        cmd.CommandText = "INSERT INTO Audio (audioid, file, size) VALUES (@id, @file, @size);";
                        cmd.Connection = conn;
                        SqlParameter idNameParameter = new SqlParameter("@id", 1);
                        SqlParameter audioFileParameter = new SqlParameter("@file", buffer);
                        SqlParameter audioSizeParameter = new SqlParameter("@size", bytesReaded);

                        cmd.Parameters.Add(idNameParameter);
                        cmd.Parameters.Add(audioFileParameter);
                        cmd.Parameters.Add(audioSizeParameter);
                        

                        
                            
                            int i = cmd.ExecuteNonQuery();
                            Label1.Text = "uploaded, " + i.ToString() + " rows affected";
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

      

    }
}

    
   

   
       
