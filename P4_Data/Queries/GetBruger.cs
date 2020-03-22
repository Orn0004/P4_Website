using Microsoft.Extensions.Configuration;
using P4_Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace P4_Data.Queries
{
    public class GetBruger
    {
        private readonly string ConnectionString;
        public GetBruger(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("P4Database");
        }

        public List<Bruger> GetList()
        {
            // variable creation
            var brugerList = new List<Bruger>();
            SqlConnection cnn = null;

            try
            {
                // connects to the database.
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();

                // create a variable with the query command.
                SqlCommand command = new SqlCommand("SELECT * FROM Bruger ORDER BY Fornavn", cnn);

                //reads the table.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //as it reads single rows it will print it out untill theres no more in the table.
                    while (reader.Read())
                    {
                        brugerList.Add(new Bruger
                        {
                            Fornavn = (string)reader[0],
                            Efternavn = (string)reader[1],
                            Brugernavn = (string)reader[2]
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // closes the connection if cnn is null.
                if (cnn != null)
                    cnn.Close();
            }
            return brugerList;
        }
    }
}
