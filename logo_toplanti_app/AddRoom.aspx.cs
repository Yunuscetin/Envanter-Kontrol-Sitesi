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
    public partial class AddRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var gelenid = Request.QueryString["rID"];
                if (gelenid != null)
                {
                    //ROOMS ODASINDAN GELEN IDYI ALARAK GELEN IDYE GÖRE İŞLEM YAPILIYOR.
                    Button6.Visible = true;
                    Label2.Text = "Oda Güncelle";
                    Label1.Text = "Oda Güncelleme işlemleri";
                    string roomname = ExecSkalar("SELECT rName FROM Rooms WHERE rID ='" + gelenid + "'"); //GELEN ODA IDNE GÖRE ODANIN ADI ALINIYOR.
                    TextBox1.Text = roomname;
                    //VeriCek();               
                    DataTable dt = new DataTable();
                    dt = ExecReader("Select DISTINCT iName FROM Match INNER JOIN Rooms ON Match.roomID = Rooms.rId INNER JOIN Items ON Match.itemID = Items.iID INNER JOIN Status ON Match.StatID = Status.StatusID WHERE rID=" + gelenid);// ADI ALINAN EŞYANIN BULUNDUĞU ODALAR ÇAĞIRILIYOR.
                    foreach (DataRow dr in dt.Rows)
                    {// ÇAĞIRILAN EŞYALAR LİSTBOX2 İÇİNE ATILIYOR.
                        ListBox2.Items.Add(dr["iName"].ToString());
                    }
                    DataTable dt2 = new DataTable();
                    dt2 = ExecReader("SELECT iName FROM Items WHERE iID NOT IN(Select itemID FROM Match WHERE roomID =" + gelenid + ")");
                    foreach (DataRow dr in dt2.Rows)
                    {
                        ListBox1.Items.Add(dr["iName"].ToString());// YUKARIDA ÇAĞIRILAN EŞYALARIN HARİCİNDE KALAN ODALAR LİSTBOX1E ATANIYOR BUNUN SEBEBİ ODA EKLENİP ÇIKARILABİLMESİ.
                    }
                }
                else
                {
                    DataTable dt2 = new DataTable();
                    dt2 = ExecReader("SELECT iName FROM Items");
                    foreach (DataRow dr in dt2.Rows)
                    {
                        ListBox1.Items.Add(dr["iName"].ToString());
                    }
                }
            }
            
            
        }
        public SqlConnection DbConnection()
        {// ConnectionString metoda aktarıldı.
            return new SqlConnection("Data Source= YUNUS\\SQLEXPRESS; Initial Catalog= Project; Integrated Security=True");
        }        
        
        protected void Button5_Click(object sender, EventArgs e)
        {
            var gelenid= Request.QueryString["rID"];
            if (gelenid != null)// EĞER ROOMS ODASINDAN YÖNLENDİRME YAPILMIŞSA AŞŞAĞIDAKİ İŞLEMLER YAPILACAK.
            {               
                ExecNonQuery("UPDATE Rooms SET rName='"+ TextBox1.Text +"'" + " WHERE rID=" + gelenid );// EŞYANIN ADINI DEĞİŞTİRME İŞLEMİ

                Label4.Visible = true;
                
                for (int sayac=0; sayac<ListBox2.Items.Count; sayac++)
                {// MEVCUT ODALARA YENİ BİR ODA EKLENME İŞLEMİ KONTROLÜ
                    string rid = ExecSkalar(komut: "SELECT iID FROM Items WHERE iName='" + ListBox2.Items[sayac] + "'");
                    int stat = 1;
                    if(Convert.ToInt32(ExecSkalar("SELECT Count(*) FROM Match WHERE roomID=" + gelenid + " and itemID=" + rid))==0)
                    {
                        ExecNonQuery("INSERT INTO Match(roomID,itemID,StatID) VALUES('" + gelenid + "','" + rid + "','" + stat + "')");
                    }                    
                }
                for(int sayac=0; sayac<ListBox1.Items.Count; sayac++)
                {// MEVCUT ODALARDAN HERHANGİ BİRİNİN ÇIKARILMASI KONTROLÜ
                    string rid = ExecSkalar(komut: "SELECT iID FROM Items WHERE iName='" + ListBox1.Items[sayac] + "'");
                    int stat = 1;
                    if (Convert.ToInt32(ExecSkalar("SELECT Count(*) FROM Match WHERE roomID=" + gelenid + " and itemID=" + rid)) == 1)
                    {
                        ExecNonQuery("DELETE FROM Match WHERE roomID="+gelenid+ " and itemID="+rid);
                    }
                }
                Label4.Text = "Kayıt başarıyla güncellendi.";

            }
            else
            {
                if (TextBox1.Text == null)
                {
                    Label4.Text = "Lütfen oda adı giriniz.";
                }
                else
                {//YENİ ODA EKLEME İŞLEMİ.
                    ExecNonQuery("INSERT INTO Rooms(rName) VALUES('" + TextBox1.Text + "')");//Eşya ilk olarak eklenmeli sonrasında oda seçilmeli.
                    string iid = ExecSkalar("SELECT rID FROM Rooms WHERE rName='" + TextBox1.Text + "'");
                    int stat = 1;
                    for (int sayac = 0; sayac < ListBox2.Items.Count; sayac++)
                    {
                        string rid = ExecSkalar(komut: "SELECT iID FROM Items WHERE iName='" + ListBox2.Items[sayac] + "'");
                        ExecNonQuery("INSERT INTO Match(roomID,itemID,StatID) VALUES('" + iid + "','" + rid + "','" + stat + "')");
                        Label4.Visible = true;
                        Label4.Text = "Kayıt başarıyla eklendi.";
                    }
                }
                
            }
        }
        public DataTable ExecReader(string komut)
        {
            SqlConnection conn = DbConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(komut, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();
            return dt;
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
            catch (Exception e)
            {
                Response.Write("Bir hata oluştu.");
            }
            finally
            {
                conn.Close();
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
            while (ListBox1.SelectedItem != null)
            {
                ListBox2.Items.Add(ListBox1.SelectedItem);
                ListBox1.Items.Remove(ListBox1.SelectedItem);
            }                
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            while (ListBox2.SelectedItem != null)
            {
                ListBox1.Items.Add(ListBox2.SelectedItem);
                ListBox2.Items.Remove(ListBox2.SelectedItem);
            }                    
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            for(int i=0; i < ListBox1.Items.Count; i++)
            {
                ListBox2.Items.Add(ListBox1.Items[i].ToString());
            }
            ListBox1.Items.Clear();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                ListBox1.Items.Add(ListBox2.Items[i].ToString());
            }
            ListBox2.Items.Clear();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Rooms.aspx");
        }
    }
}