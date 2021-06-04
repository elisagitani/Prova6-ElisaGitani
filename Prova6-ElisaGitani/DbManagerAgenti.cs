using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Prova6_ElisaGitani
{
    static class DbManagerAgenti
    {
        const string connectionString = @"Data Source= (localdb)\mssqllocaldb;" +
                                          "Initial Catalog = ProvaAgenti;" +
                                          "Integrated Security=true;";
        public static List<Agente> GetAllAgents()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Agenti";

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agentiDiPolizia = new List<Agente>();

                while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var codiceFiscale = (string)reader["CodiceFiscale"];
                    var area = (string)reader["AreaGeografica"];
                    var annoDiInizioAttivita = (int)reader["AnnoDiInizioAttivita"];

                    Agente a = new Agente(nome, cognome, codiceFiscale, area, annoDiInizioAttivita);
                    agentiDiPolizia.Add(a);
                }

                return agentiDiPolizia;
            }
        }
        public static bool VerificaEsistenzaAgenteConArea(string area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Agenti where AreaGeografica=@AreaGeografica";
                command.Parameters.AddWithValue("@AreaGeografica", area);
                SqlDataReader reader = command.ExecuteReader();

                bool esiste = false;

                if (reader.HasRows)
                {
                    esiste = true;
                }

                return esiste;
            }
        }
        public static List<Agente> AgentiInArea(string area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Agenti where AreaGeografica=@AreaGeografica";
                command.Parameters.AddWithValue("@AreaGeografica", area);
                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agentiInArea = new List<Agente>();

                while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var codiceFiscale = (string)reader["CodiceFiscale"];
                    var annoDiInizioAttivita = (int)reader["AnnoDiInizioAttivita"];
                    Agente a = new Agente(nome, cognome, codiceFiscale, area, annoDiInizioAttivita);
                    agentiInArea.Add(a);
                }

                return agentiInArea;
            }

        }
        public static bool VerificaEsistenzaAgenteConAnniServizio(int anni)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Agenti where AnnoDiInizioAttivita<=@AnnoDiInizioAttivita";
                int annoDiInizioAttivita = DateTime.Today.Year - anni;
                command.Parameters.AddWithValue("@AnnoDiInizioAttivita", annoDiInizioAttivita);
                SqlDataReader reader = command.ExecuteReader();

                bool esiste = false;

                if (reader.HasRows)
                {
                    esiste = true;
                }

                return esiste;
            }

        }
        public static List<Agente> AgentiConAnniDiServizio(int anni)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                int annoDiInizioAttivita = DateTime.Today.Year - anni;
                command.CommandText = "select * from dbo.Agenti where AnnoDiInizioAttivita<=@AnnoDiInizioAttivita";
                command.Parameters.AddWithValue("@AnnoDiInizioAttivita", annoDiInizioAttivita);
                SqlDataReader reader = command.ExecuteReader();
                List<Agente> agentiConAnniDiServizio = new List<Agente>();

                while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var codiceFiscale = (string)reader["CodiceFiscale"];
                    var area = (string)reader["AreaGeografica"];
                    annoDiInizioAttivita = (int)reader["AnnoDiInizioAttivita"];
                    Agente a = new Agente(nome, cognome, codiceFiscale, area, annoDiInizioAttivita);
                    agentiConAnniDiServizio.Add(a);
                }

                return agentiConAnniDiServizio;
            }
        }
        public static bool VerificaEsistenzaAgentiConCF (string cf)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Agenti where CodiceFiscale=@CodiceFiscale";
                command.Parameters.AddWithValue("@CodiceFiscale", cf);
                SqlDataReader reader = command.ExecuteReader();

                bool esiste = false;

                if (reader.HasRows)
                {
                    esiste = true;
                }

                return esiste;
            }


        }
        public static void InserisciAgente(Agente agente)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Agenti values(@Nome,@Cognome,@CodiceFiscale,@AreaGeografica,@AnnoDiInizioAttivita)";
                command.Parameters.AddWithValue("@Nome", agente.Nome);
                command.Parameters.AddWithValue("@Cognome", agente.Cognome);
                command.Parameters.AddWithValue("@CodiceFiscale", agente.CodiceFiscale);
                command.Parameters.AddWithValue("@AreaGeografica", agente.AreaGeografica);
                command.Parameters.AddWithValue("@AnnoDiInizioAttivita", agente.AnnoDiInizioAttivita);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
