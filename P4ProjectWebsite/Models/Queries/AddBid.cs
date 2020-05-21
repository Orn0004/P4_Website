using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models.Queries
{
    public class AddBid
    {

        private readonly string ConnectionString;
        public AddBid(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("P4Database");
        }
        public void InsertBid(BidEntity bids)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = "INSERT INTO BidTable (Bid, ContributorId, SupplierId, TaskId, Confirmation) VALUES (@Bid, @ContributorId, @SupplierId, @TaskiD, 0)";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@Bid", bids.Bid);
                    command.Parameters.AddWithValue("@ContributorId", bids.ContributorId);
                    command.Parameters.AddWithValue("@SupplierId", bids.SupplierId);
                    command.Parameters.AddWithValue("@TaskId", bids.TaskId);
                    command.Parameters.AddWithValue("@Confirmation", bids.Confirmation);

                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }
        public string FindSupId()
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string query = $"SELECT CreatedBy FROM Tasks WHERE Id = '{TaskId}'";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    string result = (string)command.ExecuteScalar();
                    cnn.Close();

                    return result;
                }
            }
        }
    }
}

