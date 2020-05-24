﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models.Queries
{
    public class GetOutgoingBids
    {

        private readonly string ConnectionString;
        public GetOutgoingBids(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("P4Database");
        }

        public string FindUsername(string userid)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string query = $"SELECT Username FROM AspNetUsers WHERE Id = '{userid}'";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    string result = (string)command.ExecuteScalar();
                    cnn.Close();

                    return result;
                }
            }
        }

        public List<BidEntity> GetList(string username)
        {
            // variable creation
            var Bids = new List<BidEntity>();
            SqlConnection cnn = null;

            try
            {
                // connects to the database.
                using (cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string query = $"SELECT * FROM Bids WHERE ContributorUsername = '{username}'";
                    using (SqlCommand command = new SqlCommand(query, cnn))
                    {
                        //reads the table.
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //as it reads single rows it will print it out untill theres no more in the table.
                            while (reader.Read())
                            {
                                Bids.Add(new BidEntity
                                {
                                    Bid = (int)reader[0],
                                    SupplierUsername = (string)reader[1],
                                    ContributorUsername = (string)reader[2],
                                    Id = (int)reader[3],
                                    TaskId = (int)reader[4],
                                    DateCreated = (string)reader[5]
                                });
                            }
                        }
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
            return Bids;
        }
        public List<BidEntity> GetConfirmedList(string username)
        {
            // variable creation
            var Bids = new List<BidEntity>();
            SqlConnection cnn = null;

            try
            {
                // connects to the database.
                using (cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string query = $"SELECT * FROM ConfirmedBids WHERE ContributorUsername = '{username}'";
                    using (SqlCommand command = new SqlCommand(query, cnn))
                    {
                        //reads the table.
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //as it reads single rows it will print it out untill theres no more in the table.
                            while (reader.Read())
                            {
                                Bids.Add(new BidEntity
                                {
                                    Bid = (int)reader[0],
                                    SupplierUsername = (string)reader[1],
                                    ContributorUsername = (string)reader[2],
                                    Id = (int)reader[3],
                                    TaskId = (int)reader[4],
                                    DateCreated = (string)reader[5]
                                });
                            }
                        }
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
            return Bids;
        }
    }
}

