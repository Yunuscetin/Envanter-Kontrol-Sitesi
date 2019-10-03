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
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                //EŞYALARIN GRİDVİEWE ÇEKİLME İŞLEMİ.
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT iID,iName as [Eşya Adı] FROM Items ORDER BY iName", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                

            }
            /*catch (Exception e)
            {
                Response.Write("Veritabanı baglantısı hatası");
            }*/
            finally
            {
                conn.Close();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int iID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
            {
                try
                {// ODALARIN SİLİNMESİ İÇİN YAN TARAFTAKİ SİLME BUTONUNA TIKLANMASI DURUMUNDA YAPILACAK İŞLEMLER.
                    SqlConnection conn = DbConnection();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Items WHERE iID=" + iID, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);                    
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM Match WHERE itemID=" + iID, conn);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    conn.Close();
                    VeriCek();
                }
                catch (Exception)
                {
                    Response.Write("Baglantı Hatası");
                }
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {// EDİT İŞLEMİNE TIKLANIRSA ADDITEMS SAYFASINA YÖNLENDİRİLEREK GÜNCELLEME İŞLEMLERİ YAPILIYOR.
            SqlConnection conn = DbConnection();
            string command = e.CommandName;
            string iID = e.CommandArgument.ToString();
            conn.Open();
            if (command == "Guncelle")
            {
                Response.Redirect("AddItem.aspx?iID=" + iID);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            VeriCek();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {// İD GİZLEME İŞLEMİ
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[3].Visible = false;
            }
        }
    }
}