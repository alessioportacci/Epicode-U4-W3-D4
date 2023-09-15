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
    public partial class repeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Connessione e creazione lista
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"]
                                                            .ConnectionString.ToString();

            SqlConnection conn = new SqlConnection(connectionString);
            List<Clienti> clientiList = new List<Clienti>();

            try
            {
                //Apro la connessione e carico il comando
                conn.Open();
                
                SqlDataReader sqlDataReader = new SqlCommand("SELECT * FROM Clienti", conn)
                                                            .ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Clienti cliente = new Clienti();

                    cliente.IdCliente = Convert.ToInt32(sqlDataReader["IDCliente"]);
                    cliente.Nome = sqlDataReader["Nome"].ToString();
                    cliente.Cognome = sqlDataReader["Cognome"].ToString();
                    cliente.Indirizzo = sqlDataReader["Indirizzo"].ToString();

                    clientiList.Add(cliente);
                }

            }

            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
            }

            Repeater1.DataSource = clientiList;
            Repeater1.DataBind();
        }

    }

    public class Clienti
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
    }
}