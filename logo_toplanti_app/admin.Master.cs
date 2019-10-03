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
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) // Login giriş kontrolü
            {
                Response.Redirect("adminlogin.aspx");
            }
            else
            {
                string logon = ExecSkalar("SELECT name FROM Login WHERE username='" + Session["username"] + "'");
                Label1.Text = logon;
            }
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
            Response.Redirect("adminlogin.aspx");
        }
    }
}