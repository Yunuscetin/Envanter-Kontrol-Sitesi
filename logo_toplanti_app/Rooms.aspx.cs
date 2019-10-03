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
    public partial class Rooms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VeriCek();
                
            }
        }
        public SqlConnection DbConnection()
        {// ConnectionString metoda aktarıldı.
            return new SqlConnection("Data Source = YUNUS\\SQLEXPRESS; Initial Catalog = Project; Integrated Security = True");
        }
        public void VeriCek()
        {// Gridviewe Sqlden veri çekilerek metoda aktarıldı istenilen yerde çağırılabilmesi için. ODALARIN LİSTESİ ÇEKİLDİ.
            SqlConnection conn = DbConnection();
            try
            {

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT rID,rName as [Oda Adı] FROM Rooms ORDER BY rName", conn);
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
            int rID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
            {// ODA LİSTESİNDEKİ SİLME İŞLEMİ
                try
                {
                    SqlConnection conn = DbConnection();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Rooms WHERE rID=" + rID, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            VeriCek();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {        // EDİTE TIKLANIRSA ADDROOMS ODASINA YÖNLENDİRİLEREK GÜNCELLEME İŞLEMİ.    
            SqlConnection conn = DbConnection();
            string command = e.CommandName;
            string rID = e.CommandArgument.ToString();
            conn.Open();            
            if (command == "Guncelle")
            {
                Response.Redirect("AddRoom.aspx?rID="+rID);
                
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            VeriCek();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[3].Visible = false;
            }
        }
       
    }
}