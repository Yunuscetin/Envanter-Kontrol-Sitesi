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
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) // Login giriş kontrolü
            {
                
                Response.Redirect("login.aspx");
            }
            else
            {
                string logon = ExecSkalar("SELECT name FROM Login WHERE username='" + Session["username"]+"'"); // Sayfanın sağ üst köşesinde görünen kullanıcı ismi çekiliyor. Giren Usernameye göre kullanıcının ismi çekiliyor.
                Label1.Text = logon;
            }
            if (!IsPostBack)
            {
                DropDown();
                VeriCek();

            }
                     
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {       
            VeriCek();
            LblBilgi.Text = DropDownList1.SelectedItem + " hakkında girilecek bilgi";
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
        public void VeriCek()
        {// Gridviewe Sqlden veri çekilerek metoda aktarıldı istenilen yerde çağırılabilmesi için. Metotta Dropdownun seçili değerinin idsini alarak o odaya ait eşyalar gridviewe çekiliyor.
            try
            {
                int deger = Convert.ToInt32(DropDownList1.SelectedValue);
                SqlConnection conn = DbConnection();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select mID,iName as [Ürün Adı], StatusName as [Durum] FROM Match INNER JOIN Rooms ON Match.roomID= Rooms.rId INNER JOIN Items ON Match.itemID=Items.iID INNER JOIN Status ON Match.StatID = Status.StatusID WHERE rID=" + deger, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();                               
                conn.Close();

            }
            catch (Exception e)
            {
                Response.Write("Veritabanı baglantısı hatası");
            }
            
        }
        
        public SqlConnection DbConnection()
        {// ConnectionString metoda aktarıldı.
            return new SqlConnection("Data Source= YUNUS\\SQLEXPRESS; Initial Catalog= Project; Integrated Security=True");
        }
        public void DropDown() // Odalar tablosundaki eşyalar dropdownlistin içine çekiliyor. 
        {
            SqlConnection conn = DbConnection();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM Rooms ORDER BY rName", conn);
            DataTable tbl = new DataTable();
            adptr.Fill(tbl);
            DropDownList1.DataSource = tbl;
            DropDownList1.DataTextField = "rName";
            DropDownList1.DataValueField = "rId";
            DropDownList1.DataBind();
        }
     
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Gridview içerisindeki Çalışıyor ve Arızalı butonları CommandNamesine göre tıklanma durumunda veritabanında arızalı veya çalışıyor olarak değişiyor.
            // Bunun için DataKeyNames ve Datafield ID si alınarak CommandArgumentle tıklanan butona id atanıyor. Eşlenen idler işlem yapılacak odaya göre hareket ediyor.
            string command = e.CommandName;
            string mID = e.CommandArgument.ToString();
            if (e.CommandName == "Calisiyor")
            {
                try
                {

                    SqlConnection conn = DbConnection();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Match SET StatID='1' WHERE mID="+mID, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    VeriCek();
                    conn.Close();

                }
                catch (Exception)
                {
                    Response.Write("Bağlantı Hatası");
                }
            }
            if (e.CommandName == "Arizali")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                try
                {
                    SqlConnection conn = DbConnection();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Match SET StatID='0' WHERE mID="+mID, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    cmd.ExecuteNonQuery();
                    VeriCek();

                    conn.Close();
                }
                catch (Exception)
                {
                    Response.Write("Bağlantı Hatası");
                }
            }
        }
        
        protected void Button4_Click(object sender, EventArgs e)
        {  
            // Aşağıdaki text boxta girilen bilgi rapor sayfasında görünmesi için veritabanında Rapor tablosuna kayıt ediliyor.
            int deger = Convert.ToInt32(DropDownList1.SelectedValue);            
            SqlConnection conn = DbConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO Rapor(reportName,roomID) VALUES(@text,@room)",conn);
            cmd.Parameters.AddWithValue("@text", TxtBilgi.Text);
            cmd.Parameters.AddWithValue("room", deger);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch
            {
                Response.Write("Bir hata oluştu.");
            }
            finally
            {
                conn.Close();
            }
            TxtBilgi.Text = "";

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            // Idye göre atanmasını yaptığımız tabloların gridviewde idsinin görünmemesi için kullanıldı.
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        protected void CikisBtn_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("username");// Login ekranına dönüş çıkış butonu.
            Response.Redirect("login.aspx");
        }

        protected void BtnRpr_Click(object sender, EventArgs e)// Rapor sayfasına yönlendirme
        {
            Response.Redirect("rapor.aspx");
        }
    }
                    
                    
                
}
        

