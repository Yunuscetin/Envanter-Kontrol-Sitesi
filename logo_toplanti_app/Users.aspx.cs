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
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) // Login giriş kontrolü
            {
                Response.Redirect("adminlogin.aspx");
            }
            if (!IsPostBack)
            {
                VeriCek();
            }
            
        }
        public SqlConnection DbConnection()
        {// ConnectionString metoda aktarıldı.
            return new SqlConnection("Data Source= YUNUS\\SQLEXPRESS; Initial Catalog= Project; Integrated Security=True");
        }
        public void VeriCek()
        {// Gridviewe Sqlden veri çekilerek metoda aktarıldı istenilen yerde çağırılabilmesi için.
            SqlConnection conn = DbConnection();
            try
            {
                // KİŞİ LİSTESİNİN ÇEKİMİ.
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT uID,Name as[İsim Soyisim], username as [Kullanıcı Adı], password as [Parola] FROM Login", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception e)
            {
                Response.Write("Veritabanı baglantısı hatası");
            }
            finally
            {
                conn.Close();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int uID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
            SqlConnection conn = DbConnection();
            {// KULLANICI SİLME İŞLEMLERİ
                try
                {
                   
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Login WHERE uID=" + uID, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    
                }
                /*catch (Exception)
                {
                    Response.Write("Baglantı Hatası");
                }*/
                finally
                {
                    conn.Close();
                    VeriCek();
                }
            }

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[3].Visible = false;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {// EDİT İŞLEMİ İÇİN ADDUSER SAYFASINA YÖNLENDİRME
            SqlConnection conn = DbConnection();
            string command = e.CommandName;
            string uID = e.CommandArgument.ToString();
            conn.Open();
            if (command == "Guncelle")
            {
                Response.Redirect("AddUser.aspx?uID=" + uID);
            }
        }

        
    }
}