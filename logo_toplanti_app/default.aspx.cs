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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string room = ExecSkalar("SELECT Count(*) FROM Rooms");
            Label1.Text = room;
            string item = ExecSkalar("SELECT Count(*) FROM Items");
            Label2.Text = item;
            string user = ExecSkalar("SELECT Count(*) FROM Login");
            Label3.Text = user;
        }
        public SqlConnection DbConnection()
        {// ConnectionString metoda aktarıldı.
            return new SqlConnection("Data Source= YUNUS\\SQLEXPRESS; Initial Catalog= Project; Integrated Security=True");
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
            Response.Redirect("main.aspx");
        }
    }
}