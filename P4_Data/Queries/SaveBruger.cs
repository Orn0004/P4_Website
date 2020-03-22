using Microsoft.Extensions.Configuration;
using P4_Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace P4_Data.Queries
{
    public class SaveBruger
    {
        private readonly string ConnectionString;
        public SaveBruger(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("P4Database");
        }

        public void Insert(Bruger bruger)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = "INSERT INTO Bruger (Fornavn,Efternavn,Brugernavn) VALUES (@Fornavn,@Efternavn,@Brugernavn)";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@Fornavn", bruger.Fornavn);
                    command.Parameters.AddWithValue("@Efternavn", bruger.Efternavn);
                    command.Parameters.AddWithValue("@Brugernavn", bruger.Brugernavn);

                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");                    
                }
            }
        }
    }
}
