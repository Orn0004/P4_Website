using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models.Queries
{
    public class DeleteTask     
    {
        private readonly string ConnectionString;
        public DeleteTask(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("P4Database");
        }
       
        public void RemoveTask(int Id)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = $"DELETE FROM Tasks WHERE Id = '{Id}'";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error deleting data from the Database!");
                }
            }
        }
    }
}
