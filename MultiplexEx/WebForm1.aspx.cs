using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiplexEx
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            //Recupera stringa connessione
            string connectionString = ConfigurationManager.ConnectionStrings["DbPrenotazioni"].ToString();

            //Crea istanza di SqlConnection
            SqlConnection conn = new SqlConnection(connectionString);

            //Apri connessione e invia dati 
            try
            {
                conn.Open();
                Response.Write("Connessione al database OK");
                SqlCommand cmdInsert = new SqlCommand($"INSERT into Prenotati (NomeCliente, CognomeCliente, Sala, TipoBiglietto) VALUES ('{TxtName.Text}', '{TxtSurname.Text}', '{ReservationRoom.Text}', '{TicketType.Text}')",conn);
                int affectedRow = cmdInsert.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("Connessione al database fallita.");
            }

            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            Response.Write($"DATI PRENOTAZIONE --> Nome:{TxtName.Text}, Cognome:{TxtSurname.Text}, Sala:{ReservationRoom.Text}, Tipo di biglietto:{TicketType.Text}");
        }
    }
}