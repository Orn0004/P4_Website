using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models.Queries
{
    public class SaveTask
    {
        private readonly string ConnectionString;
        public SaveTask(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("P4Database");
        }


        public void Insert(Tasks task)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = "INSERT INTO Tasks (Title,Description,Salary,Duration,Location) VALUES (@Title,@Description,@Salary,@Duration,@Location)";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@Title", task.Title);
                    command.Parameters.AddWithValue("@Description", task.Description);
                    command.Parameters.AddWithValue("@Salary", task.Salary);
                    command.Parameters.AddWithValue("@Duration", task.Duration);
                    command.Parameters.AddWithValue("@Location", task.Location);

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