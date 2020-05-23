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
        public void InsertBid(BidEntity bid)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = "INSERT INTO Bids (Bid, ContributorId, SupplierId, TaskId, Confirmation) VALUES (@Bid, @ContributorId, @SupplierId, @TaskiD, @Confirmation)";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@Bid", bid.Bid);
                    command.Parameters.AddWithValue("@ContributorId", bid.ContributorId);
                    command.Parameters.AddWithValue("@SupplierId", bid.SupplierId);
                    command.Parameters.AddWithValue("@TaskId", bid.TaskId);
                    command.Parameters.AddWithValue("@Confirmation", bid.Confirmation);

                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }

        public int LowestBidQuery(int taskId)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = $"SELECT MIN (Bid) FROM Bids WHERE TaskId='{taskId}'";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    int result = (int)command.ExecuteScalar();
                    cnn.Close();
                    return result;
                }
            }
        }


        public void InsertLowestBidIntoTask(int bid, int taskId)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = $"UPDATE Tasks SET LowestBid = '{bid}' WHERE Id = '{taskId}'";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }
        public string FindSupId(int TaskId)
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

        public string FindContributorName(string contributorId )
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string query = $"SELECT UserName FROM AspNetUsers WHERE Id = '{contributorId}'";

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

