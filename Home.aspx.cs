using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Captcha
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Button1.Visible = true;
                Button2.Visible = true;
                Button3.Visible = false;
                Button4.Visible = false;
            }
            else
            {
                Button1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = true;
                Button4.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}