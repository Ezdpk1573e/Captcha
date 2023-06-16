using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Captcha
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                genCaptcha();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Label1.Text == TextBox5.Text)
            {
                string email = "select Email from Captcha where Email='" + TextBox2 + "'";
                SqlConnection cn = new SqlConnection("Data Source=DEV;Initial Catalog=Login;Integrated Security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand(email, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Response.Write("Email Already exit..");
                }
            
                else
                {
                cn.Close();
                cn.Open();
                string store="insert into Captcha(Name,Email,Password) values('"+ TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
                SqlCommand cmd2 = new SqlCommand(store, cn);
                cmd2.ExecuteNonQuery();
                Response.Write("Register Succesfuly...");
                }
            }
            else
            {
                Response.Write("Invalid Captcha...");
            }
        }
        void genCaptcha()
        {
            const string chars = "yyyyyyyyaaaaaaaaaaAAAAAAAbbbbbbb6666666";
            string captcha = new string(Enumerable.Repeat(chars, 6).Select(s => s[new Random().Next(s.Length)]).ToArray());
            Label1.Text = captcha;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            genCaptcha();

        }
    }
    
}