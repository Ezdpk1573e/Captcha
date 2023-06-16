using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Captcha
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Write("Register Succesfuly...");
            }
            Label1.Text = Session["name"].ToString();
        }
    }
}