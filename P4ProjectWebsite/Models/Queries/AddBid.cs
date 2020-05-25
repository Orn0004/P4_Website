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
                string query = "INSERT INTO Bids (Bid, ContributorUsername, SupplierUsername, TaskId, DateCreated) VALUES (@Bid, @ContributorUsername, @SupplierUsername, @TaskId, @DateCreated)";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@Bid", bid.Bid);
                    command.Parameters.AddWithValue("@ContributorUsername", bid.ContributorUsername);
                    command.Parameters.AddWithValue("@SupplierUsername", bid.SupplierUsername);
                    command.Parameters.AddWithValue("@TaskId", bid.TaskId);
                    command.Parameters.AddWithValue("@DateCreated", bid.DateCreated);

                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }

        public string FindSupplierName(int TaskId)
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
        //public string FindContributorBids(string username)
        //{
        //    using (SqlConnection cnn = new SqlConnection(ConnectionString))
        //    {
        //        string query = $"SELECT * FROM Bids WHERE Id = '{username}'";

        //        using (SqlCommand command = new SqlCommand(query, cnn))
        //        {
        //            cnn.Open();
        //            string result = (string)command.ExecuteScalar();
        //            cnn.Close();

        //            return result;
        //        }
        //    }
        //}
    }
}

