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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var gelenid = Request.QueryString["uID"];            
            if (gelenid != null)
            {//USERS ODASINDAN GELEN IDYE GORE KULLANICI BELİRLENİYOR
                if (!IsPostBack)
                {
                    Button1.Visible = true;
                    Label4.Text = "Kullanıcı Güncelleme Formu";
                    string name = ExecSkalar("SELECT Name FROM Login WHERE uID ='" + gelenid + "'");
                    TextBox1.Text = name;
                    string username = ExecSkalar("SELECT username FROM Login WHERE uID ='" + gelenid + "'");
                    TextBox2.Text = username;
                    string parola = ExecSkalar("SELECT password FROM Login WHERE uID ='" + gelenid + "'");
                    TextBox3.Text = parola;
                }
               

            }
        }
        public SqlConnection DbConnection()
        {// ConnectionString metoda aktarıldı.
            return new SqlConnection("Data Source= YUNUS\\SQLEXPRESS; Initial Catalog= Project; Integrated Security=True");
        }
        public void ExecNonQuery(string komut)
        {
            SqlConnection conn = DbConnection();
            SqlCommand cmd = new SqlCommand(komut, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            /*catch(Exception e)
            {
                Response.Write("Bir hata oluştu.");
            }*/
            finally
            {
                conn.Close();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            var gelenid = Request.QueryString["uID"];
            if (gelenid != null)
            { // USERS ODASINDAN YÖNLENDİRME YAPILDIYSA GÜNCELLEME İŞLEMİ.
                ExecNonQuery("UPDATE Login SET Name='" + TextBox1.Text + "', username='"+TextBox2.Text+ "', password='"+TextBox3.Text +"' WHERE uID=" + gelenid);
                Label3.Visible = true;
                Label3.Text = "Kayıt başarıyla güncellendi.";
            }
            else
            {//YENİ KAYIT EKLEME İŞLEMİ.
                if (TextBox3.Text == TextBox4.Text)
                {
                    ExecNonQuery("INSERT INTO Login(Name,username,password) VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')");
                    Label3.Visible = true;
                    Label3.Text = "Kayıt başarıyla eklendi.";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "Lütfen parolaları aynı giriniz.";
                }
                
            }

        }
        public string ExecSkalar(string komut)
        {
            SqlConnection conn = DbConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(komut, conn);
            string id = cmd.ExecuteScalar().ToString();
            conn.Close();
            return id;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
    }
}