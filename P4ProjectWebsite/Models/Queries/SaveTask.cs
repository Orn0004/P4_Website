﻿using Microsoft.Extensions.Configuration;
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

        //public int FindCategoryId(string CategoryName)
        //{
        //    using (SqlConnection cnn = new SqlConnection(ConnectionString))
        //    {
        //        string query = $"Select Id FROM TaskCategories Where Name = '{CategoryName}'";

        //        using (SqlCommand command = new SqlCommand(query, cnn))
        //        {
        //            cnn.Open();
        //            int result = command.ExecuteNonQuery();
        //            cnn.Close();

        //            return result;
        //        }
        //    }
        //}
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
        public void InsertTask(TaskEntity task)
        {
            // connects to the database.
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // create a variable with the query command
                string query = "INSERT INTO Tasks (Title,Description,Duration,Location,Category,CreatedBy,DateCreated) VALUES (@Title,@Description,@Duration,@Location,@Category,@CreatedBy,@DateCreated)";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@Title", task.Title);
                    command.Parameters.AddWithValue("@Description", task.Description);
                    command.Parameters.AddWithValue("@Duration", task.Duration);
                    command.Parameters.AddWithValue("@Location", task.Location);
                    command.Parameters.AddWithValue("@Category", task.Category);
                    command.Parameters.AddWithValue("@CreatedBy", task.CreatedBy);
                    command.Parameters.AddWithValue("@DateCreated", task.DateCreated);

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