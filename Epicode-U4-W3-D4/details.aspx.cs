using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Epicode_U4_W3_D4
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "SELECT * FROM Clienti WHERE IDCliente = @ID";
            cmd.Parameters.AddWithValue("ID", Request.QueryString["ID"]);

            SqlDataReader reader = cmd.ExecuteReader();

            conn.Close();
        }
    }
}