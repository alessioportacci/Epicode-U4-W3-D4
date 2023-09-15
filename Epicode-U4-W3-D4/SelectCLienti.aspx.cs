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
    public partial class SelectCLienti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Clienti", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) 
                ElencoClienti.InnerHtml += $"<a href='Details.aspx?id={reader["IDCliente"]}'> {reader["Nome"]} {reader["Cognome"]}</a>";

            conn.Close();
        }
    }
}