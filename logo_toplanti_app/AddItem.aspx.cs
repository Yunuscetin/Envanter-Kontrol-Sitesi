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
    public partial class AddItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var gelenid = Request.QueryString["iID"];
                if (gelenid != null)
                { // ITEMS ODASINDAN GELEN IDYI ALARAK GELEN IDYE GÖRE İŞLEM YAPILIYOR.
                    Button5.Visible = true;
                    Label1.Text = "Eşya Güncelle";
                    Label2.Text = "Eşya Güncelleme işlemleri";
                    string itemname = ExecSkalar("SELECT iName FROM Items WHERE iID ='" + gelenid + "'"); //GELEN EŞYA IDNE GÖRE EŞYANIN ADI ALINIYOR.
                    TextBox1.Text = itemname;                   
                    DataTable dt = new DataTable();
                    dt = ExecReader("Select DISTINCT rName FROM Match INNER JOIN Rooms ON Match.roomID = Rooms.rId INNER JOIN Items ON Match.itemID = Items.iID INNER JOIN Status ON Match.StatID = Status.StatusID WHERE iID=" + gelenid);// ADI ALINAN EŞYANIN BULUNDUĞU ODALAR ÇAĞIRILIYOR.
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListBox2.Items.Add(dr["rName"].ToString()); // ÇAĞIRILAN ODALAR LİSTBOX2 İÇİNE ATILIYOR.
                    }
                    DataTable dt2 = new DataTable();
                    dt2 = ExecReader("SELECT rName FROM Rooms WHERE rID NOT IN(Select roomID FROM Match WHERE itemID =" + gelenid + ")");
                    foreach (DataRow dr in dt2.Rows)
                    {
                        ListBox1.Items.Add(dr["rName"].ToString());// YUKARIDA ÇAĞIRILAN ODALARIN HARİCİNDE KALAN ODALAR LİSTBOX1E ATANIYOR BUNUN SEBEBİ ODA EKLENİP ÇIKARILABİLMESİ.
                    }
                }
                else
                {
                    DataTable dt2 = new DataTable();
                    dt2 = ExecReader("SELECT rName FROM Rooms");
                    foreach (DataRow dr in dt2.Rows)
                    {
                        ListBox1.Items.Add(dr["rName"].ToString());
                    }
                }
            }
            
        }
        public SqlConnection DbConnection()
        {// ConnectionString metoda aktarıldı.
            return new SqlConnection("Data Source= YUNUS\\SQLEXPRESS; Initial Catalog= Project; Integrated Security=True");
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox2.Items.Add(ListBox1.SelectedValue);
            ListBox1.Items.Remove(ListBox1.SelectedValue);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add(ListBox2.SelectedValue);
            ListBox2.Items.Remove(ListBox2.SelectedValue);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListBox1.Items.Count; i++)
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
           
                var gelenid = Request.QueryString["iID"];
                if (gelenid != null)// EĞER ITEMS ODASINDAN YÖNLENDİRME YAPILMIŞSA AŞŞAĞIDAKİ İŞLEMLER YAPILACAK.
                {
                    ExecNonQuery("UPDATE Items SET iName='" + TextBox1.Text + "'" + " WHERE iID=" + gelenid);// EŞYANIN ADINI DEĞİŞTİRME İŞLEMİ
                    Label4.Visible = true;
                    

                    for (int sayac = 0; sayac < ListBox2.Items.Count; sayac++)
                    {// MEVCUT ODALARA YENİ BİR ODA EKLENME İŞLEMİ KONTROLÜ
                        string rid = ExecSkalar(komut: "SELECT rID FROM Rooms WHERE rName='" + ListBox2.Items[sayac] + "'");
                        int stat = 1;
                        if (Convert.ToInt32(ExecSkalar("SELECT Count(*) FROM Match WHERE itemID=" + gelenid + " and roomID=" + rid)) == 0)
                        {
                            ExecNonQuery("INSERT INTO Match(roomID,itemID,StatID) VALUES('" + rid + "','" + gelenid + "','" + stat + "')");
                        }
                    }
                    for (int sayac = 0; sayac < ListBox1.Items.Count; sayac++)
                    {// MEVCUT ODALARDAN HERHANGİ BİRİNİN ÇIKARILMASI KONTROLÜ
                        string rid = ExecSkalar(komut: "SELECT rID FROM Rooms WHERE rName='" + ListBox1.Items[sayac] + "'");
                        int stat = 1;
                        if (Convert.ToInt32(ExecSkalar("SELECT Count(*) FROM Match WHERE itemID=" + gelenid + " and roomID=" + rid)) == 1)
                        {
                            ExecNonQuery("DELETE FROM Match WHERE roomID=" + rid + " and itemID=" + gelenid);
                        }
                    }
                    Label4.Text = "Kayıt başarıyla güncellendi.";

            }
                else if (TextBox1.Text == "")
                {
                    Label1.Visible = true;
                    Label4.Text = "Lütfen eşya adı giriniz.";
                }
                else
                {
                //YENİ EŞYA EKLEME VE ITEMS TABLOSUNA GÖNDERME İŞLEMİ.
                    ExecNonQuery("INSERT INTO Items(iName) VALUES('" + TextBox1.Text + "')");//Eşya ilk olarak eklenmeli sonrasında oda seçilmeli.
                    string iid = ExecSkalar("SELECT iID FROM Items WHERE iName='" + TextBox1.Text + "'");
                    int stat = 1;
                    for (int sayac = 0; sayac < ListBox2.Items.Count; sayac++)
                    {
                        string rid = ExecSkalar(komut: "SELECT rID FROM Rooms WHERE rName='" + ListBox2.Items[sayac] + "'");
                        ExecNonQuery("INSERT INTO Match(roomID,itemID,StatID) VALUES('" + rid + "','" + iid + "','" + stat + "')");
                        Label4.Visible = true;
                        Label4.Text = "Kayıt başarıyla eklendi.";
                    }
                }

            
           
                                                           
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
            /*catch
            {
                Response.Write("Bir hata oluştu.");
            }*/
            finally
            {
                conn.Close();
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
        public string ExecSkalar(string komut)
        {          
            SqlConnection conn = DbConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(komut,conn);
            string id = cmd.ExecuteScalar().ToString();
            conn.Close();
            return id;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {            
            Response.Redirect("Items.aspx");
        }
    }
}
