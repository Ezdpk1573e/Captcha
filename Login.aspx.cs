using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Captcha
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection("");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                genCaptcha();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Label1.Text == TextBox3.Text)
            {
                string q="select * from Captcha where Email='"+ TextBox1.Text +"'and Password='"+ TextBox2.Text +"'";
                SqlConnection cn = new SqlConnection("Data Source=DEV;Initial Catalog=Login;Integrated Security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand(q, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader["name"].ToString();
                    Session["name"] = name;
                    Response.Redirect("~/Profile.aspx");
                }
                else
                {
                    Response.Write("Invalid email and password");
                }
            }
            else
            {
                Response.Write("Invalid Captcha");
            }
          
        }
        void genCaptcha()
        {
            //yyyyyyyyaaaaaaaaaaAAAAAAAbbbbbbb6666666
            const string chars = "10000,99999";
            string captcha = new string(Enumerable.Repeat(chars, 6).Select(s => s[new Random().Next(s.Length)]).ToArray());
            Label1.Text = captcha;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            genCaptcha();

        }
    }
    
}