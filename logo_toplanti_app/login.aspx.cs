using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace logo_toplanti_app
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source= YUNUS\\SQLEXPRESS; Initial Catalog= Project; Integrated Security=True");// Sql Metota tanımlandı.
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GirisBtn_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM login WHERE username='" + TxtUsername.Text + "'and password='" + TxtPassword.Text + "'", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session.Add("username", TxtUsername.Text); //Username'ye göre sessiona atanıp giren kullanıcı çekiliyor.
                Response.Redirect("main.aspx");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kullanıcı adı veya şifre yanlış');</script>");
            }
            baglanti.Close();

        }
    }
}