using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace logo_toplanti_app
{
    public partial class admin_login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public SqlConnection DbConnection()
        {
            return new SqlConnection("Data Source= YUNUS\\SQLEXPRESS; Initial Catalog= Project; Integrated Security=True");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = DbConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM login WHERE username='" + username.Text + "'and password='" + password.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session.Add("username", username.Text);
                Response.Redirect("default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kullanıcı adı veya şifre yanlış');</script>");
            }
            con.Close();
        }
    }
}