using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Firebase.Database;
using Firebase.Database.Query;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace IELTSWebAdmin
{
    public partial class SampleReportaspx : Page

    {
        List<JSONModel.Staff> myDataSet;
        DataSet myDS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Set the processing mode for the ReportViewer to Local  
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                LocalReport localReport = ReportViewer1.LocalReport;

                localReport.ReportPath = "SampleReport.rdlc";

                getFirebaseData();

                ReportDataSource dsSalesOrder = new ReportDataSource();
                dsSalesOrder.Name = "Staff";
                dsSalesOrder.Value = myDS.Tables[0];

                localReport.DataSources.Add(dsSalesOrder);
            }
        }

        public void getFirebaseData() {

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://ielts-9c8f1.firebaseio.com/" + "staff.json");

                request.Method = "GET";
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();
                       myDataSet = JsonConvert.DeserializeObject<List<JSONModel.Staff>>(objText);
                    myDataSet.RemoveAt(0);
                       myDS = DatasetConvert.ToDataSet<JSONModel.Staff>(myDataSet);
                    }
                }
        }
            catch (Exception ex) {

            }


}



        



    }

    public static class DatasetConvert
    {
        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }
    }
}