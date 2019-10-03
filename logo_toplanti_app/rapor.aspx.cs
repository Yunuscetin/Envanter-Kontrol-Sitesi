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
    public partial class rapor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) // Login giriş kontrolü
            {
                Response.Redirect("login.aspx");
            }          
            else
            {
                string logon = ExecSkalar("SELECT name FROM Login WHERE username='" + Session["username"] + "'"); // Sağ üstteki kişi ismini çekme.
                Label1.Text = logon;
            }
            if (!IsPostBack)
            {
                GridCagir();

            }           
        }
        public SqlConnection DbConnection()
        {// ConnectionString metoda aktarıldı.
            return new SqlConnection("Data Source= YUNUS\\SQLEXPRESS; Initial Catalog= Project; Integrated Security=True");
        }       
        public void GridCagir()
        {
            try
            {
                // Gridviewe rapor tablosundaki veriler çekiliyor.
                SqlConnection conn = DbConnection();
                conn.Open();                
                SqlCommand cmd = new SqlCommand("Select DISTINCT reportID,reportDate as Tarih ,rName as [Oda Adı],reportName as [Bilgi] FROM Match INNER JOIN Rooms ON Match.roomID = Rooms.rId INNER JOIN Rapor ON Rooms.rID = Rapor.roomID ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                conn.Close();

            }
            catch (Exception)
            {
                Response.Write("Bağlantı Hatası");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        protected void Cikis_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("username");
            Response.Redirect("login.aspx");
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
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {// Raporların yanındaki silme işlemi.

            int reportID=Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString());           
            {               
                try
                {
                    SqlConnection conn = DbConnection();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Rapor WHERE reportID="+reportID, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();                   
                    GridCagir();
                    conn.Close();
                }
                catch(Exception)
                {
                    Response.Write("Baglantı Hatası");
                }
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {// Gizleme işlemleri.
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[2].Visible = false;
            }
        }
    }
}