using Microsoft.AspNet.FriendlyUrls;
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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Connessione e creazione lista
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"]
                                                            .ConnectionString.ToString();

            SqlConnection conn = new SqlConnection(connectionString);
            List<Contatti> ContattiList = new List<Contatti>();

            try
            {
                //Apro la connessione e carico il comando
                conn.Open();

                SqlDataReader sqlDataReader = new SqlCommand("SELECT * FROM Contatti", conn)
                                                            .ExecuteReader();
                //Leggo ul contenuto del datareader e popolo la lista
                while (sqlDataReader.Read())
                {
                    Contatti contatto = new Contatti();

                    contatto.ID = Convert.ToInt32(sqlDataReader["IDContatto"]);
                    contatto.Nome = sqlDataReader["Nome"].ToString();
                    contatto.Cognome = sqlDataReader["Cognome"].ToString();
                    contatto.Indirizzo = sqlDataReader["Indirizzo"].ToString();
                    contatto.Numero = sqlDataReader["Numero"].ToString();
                    contatto.Email = sqlDataReader["Email"].ToString();
                    contatto.Foto = sqlDataReader["Foto"].ToString();


                    ContattiList.Add(contatto);
                }

            }

            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
            }
            //Collego RepeaterContatti alla lista
            RepeaterContatti.DataSource = ContattiList;
            RepeaterContatti.DataBind();
        }

        protected void Nuovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pages/nuovoContatto.aspx");
        }

        protected void Modifica_Click(object sender, EventArgs e)
        {

        }

        protected void Elimina_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conStr);

            Button btn = (Button)sender;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "DELETE FROM Contatti WHERE IDContatto = @Contatto";
                cmd.Parameters.AddWithValue("Contatto", btn.CommandArgument);
                cmd.ExecuteNonQuery();
                
            }

            catch (Exception ex) { }

            finally 
            { 
                con.Close();
                Response.Redirect("default.aspx");
            }
        }
    }


}