using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Epicode_U4_W3_D4.Pages
{
    public partial class nuovoContatto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Aggiungi_Click(object sender, EventArgs e)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO Contatti VALUES(@Nome, @Cognome, @Indirizzo, @Numero, @Email, @Foto)";
                cmd.Parameters.AddWithValue("Nome", Nome.Text);
                cmd.Parameters.AddWithValue("Cognome", Cognome.Text);
                cmd.Parameters.AddWithValue("Indirizzo", Indirizzo.Text);
                cmd.Parameters.AddWithValue("Numero", Numero.Text);
                cmd.Parameters.AddWithValue("Email", Email.Text);
                cmd.Parameters.AddWithValue("Foto", uploadFile());

                int inserimentoEffettuato = cmd.ExecuteNonQuery();
                if (inserimentoEffettuato > 0)
                    Response.Write("Inserimento effettuato con successo");
            }

            catch (Exception ex) { }

            finally
            {
                conn.Close();
                Response.Redirect("../default.aspx");
            }
        }


        private string uploadFile()
        {
            if (FileUpload.HasFile)
                FileUpload.SaveAs(Server.MapPath($"/Content/img/{FileUpload.FileName}"));
            return FileUpload.FileName;
        }
    }
}