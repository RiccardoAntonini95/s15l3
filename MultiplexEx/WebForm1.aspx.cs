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

                SqlCommand cmdSalaNord = new SqlCommand(@"SELECT COUNT(*) as PrenotatiNord FROM Prenotati where Sala = 'SALA NORD'");
                //SqlCommand cmdSalaEst = new SqlCommand(@"SELECT COUNT(*) FROM Prenotati where Sala = 'SALA EST'");
                //SqlCommand cmdSalaSud = new SqlCommand(@"SELECT COUNT(*) FROM Prenotati where Sala = 'SALA SUD'");

                SqlDataReader sqlDataReader1 = cmdSalaNord.ExecuteReader();
                //SqlDataReader sqlDataReader2 = cmdSalaEst.ExecuteReader();
                //SqlDataReader sqlDataReader3 = cmdSalaSud.ExecuteReader();

                if(sqlDataReader1.HasRows)
                {
                    while(sqlDataReader1.Read())
                    {
                       LabelNord.Text = $"{sqlDataReader1["PrenotatiNord"]}";
                    }
                    
                }
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