using System;
using System.Collections.Generic;
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

            if (HttpContext.Current.Session["TotalQ"].Equals(0))
            {
                Response.Redirect("FormAddSectio.aspx");
            }
            else
            {
                Response.Redirect("FormSubsection.aspx");
                ddlQ.Visible = false;
                Label2.Visible = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DropDownList1.SelectedValue.Equals("Matching"))
            {
                address = "TemplateMatchingAns.aspx";
            }
            else if (DropDownList1.SelectedValue.Equals("Multiple Choice"))
            {
                address = "TemplateMultipleChoice.aspx";
            }
            else if (DropDownList1.SelectedValue.Equals("Form, Note, Table"))
            {
                address = "TemplateAnalyticDiagram.aspx";
            }
            else if (DropDownList1.SelectedValue.Equals("Sentences Completion"))
            {
                address = "TemplateSentenceCompletion.aspx";
            }
            else if (DropDownList1.SelectedValue.Equals("Short Answer"))
            {
                address = "TemplateShortAnswer.aspx";
            }
            else if (DropDownList1.SelectedValue.Equals("Plan, Map, Diagram labeling"))
            {
                address = "TemplateMap.aspx";

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
    }
}