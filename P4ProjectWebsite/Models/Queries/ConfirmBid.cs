using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models.Queries
{
    public class ConfirmBid
    {
        private readonly string ConnectionString;
        public ConfirmBid(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("P4Database");
        }

        public void UpdateBids(int Id)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = $"UPDATE Bids SET Confirmation ='1' WHERE Id = '{Id}'";
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
        public bool ArchiveTask(int taskId)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = $"INSERT INTO ArchivedTasks SELECT * FROM Tasks WHERE Id ='{taskId}'";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();
                    // Check Error
                    if (result < 0) { 
                        Console.WriteLine("Error deleting data from the Database!");
                    }
                    return true;
                }
            }
        }

        public void DeleteTask(int taskId)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = $"DELETE FROM Tasks WHERE Id = {taskId};";
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
