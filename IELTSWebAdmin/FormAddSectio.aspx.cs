using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

using System.Configuration;
using MySql.Data.MySqlClient;

namespace IELTSWebAdmin
{
    public partial class FormAddSectio : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString = "server=127.0.0.1;uid=root;pwd=wenda123;database=ielts";

        protected void Page_Load(object sender, EventArgs e)
        {

            Console.WriteLine("Page clicked");
            Console.WriteLine("Page clicked");
            Console.WriteLine("Page clicked");
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }

        }

        byte[] buffer;
        //this is the array of bytes which will hold the data (file)


        protected void ButtonUpload_Click1(object sender, EventArgs e)
        {
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
                //you want to read (do u care about this?)

                if (bytesReaded > 0)
                {
                    try
                    {
                        conn = new MySql.Data.MySqlClient.MySqlConnection();
                        conn.ConnectionString = myConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                       
                        cmd.CommandText = "INSERT INTO Audio (audioid, file, size) VALUES (?id, ?file, ?size);";
                        cmd.Connection = conn;
                        MySqlParameter idNameParameter = new MySqlParameter("?id", 1);
                        MySqlParameter audioFileParameter = new MySqlParameter("?file", buffer);
                        MySqlParameter audioSizeParameter = new MySqlParameter("?size", bytesReaded);

                        cmd.Parameters.Add(idNameParameter);
                        cmd.Parameters.Add(audioFileParameter);
                        cmd.Parameters.Add(audioSizeParameter);


                        using (conn)
                        {
                            conn.Open();
                            int i = cmd.ExecuteNonQuery();
                            Label1.Text = "uploaded, " + i.ToString() + " rows affected";

                        }
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

    
   

   
       
