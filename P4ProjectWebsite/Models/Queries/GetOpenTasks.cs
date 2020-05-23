using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models.Queries
{
    public class GetOpenTasks
    {
        private readonly string ConnectionString;
        public GetOpenTasks(IConfiguration configuration)
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

        
        
        //public int findUserId(string username)
        //{
        //    using (SqlConnection cnn = new SqlConnection(ConnectionString))
        //    {
        //        string query = $"Select Id FROM AspNetUsers WHERE = '{username}'";

        //        using (SqlCommand command = new SqlCommand(query, cnn))
        //        {
        //            cnn.Open();
        //            int result = command.ExecuteNonQuery();
        //            cnn.Close();

        //            return result;
        //        }
        //    }
        //}
        public void ReadRow(SqlCommand command, List<TaskEntity> row)
        {
            //reads the table.
            using (SqlDataReader reader = command.ExecuteReader())
            {
                //as it reads single rows it will print it out untill theres no more in the table.
                while (reader.Read())
                {
                    row.Add(new TaskEntity
                    {
                        Title = (string)reader[0],
                        Description = (string)reader[1],
                        LowestBid = (int)reader[2],
                        Duration = (int)reader[3],
                        Id = (int)reader[4],
                        Location = (string)reader[5],
                        Category = (string)reader[6],
                        CreatedBy = (string)reader[7],
                        DateCreated = (string)reader[8]

                    });
                }
            }
        }
        public List<TaskEntity> GetList()
        {
            // variable creation
            var TaskList = new List<TaskEntity>();
            SqlConnection cnn = null;

            try
            {
                // connects to the database.
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();

                // create a variable with the query command.
                SqlCommand command = new SqlCommand("SELECT * FROM Tasks ORDER BY DateCreated", cnn);

                ReadRow(command, TaskList);
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
            return TaskList;
        }

        public List<TaskEntity> GetYourList(string username)
        {
            // variable creation
            var Tasks = new List<TaskEntity>();
            SqlConnection cnn = null;

            try
            {
                // connects to the database.
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();

                // create a variable with the query command.
                SqlCommand command = new SqlCommand($"SELECT * FROM Tasks WHERE CreatedBy ='{username}' ORDER BY DateCreated", cnn);

                //reads the table.
                ReadRow(command, Tasks);
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
            return Tasks;
        }
        public List<TaskEntity> GetSingleTask(int taskid)
        {
            // variable creation
            var Task = new List<TaskEntity>();
            SqlConnection cnn = null;

            try
            {
                // connects to the database.
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();

                // create a variable with the query command.
                SqlCommand command = new SqlCommand($"SELECT * FROM Tasks WHERE Id ='{taskid}'", cnn);

                //reads the table.
                ReadRow(command, Task);
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
            return Task;
        }
    }
}


