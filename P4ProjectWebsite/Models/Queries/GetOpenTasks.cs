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
                SqlCommand command = new SqlCommand("SELECT * FROM Tasks ORDER BY ID", cnn);

                //reads the table.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //as it reads single rows it will print it out untill theres no more in the table.
                    while (reader.Read())
                    {
                        TaskList.Add(new TaskEntity
                        {
                            Title = (string)reader[0],
                            Description = (string)reader[1],
                            Bid = (int)reader[2],
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
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //as it reads single rows it will print it out untill theres no more in the table.
                    while (reader.Read())
                    {
                        Task.Add(new TaskEntity
                        {
                            Title = (string)reader[0],
                            Description = (string)reader[1],
                            Bid = (int)reader[2],
                            Duration = (int)reader[3],
                            Id = (int)reader[4],
                            Location = (string)reader[5],
                            Category = (string)reader[6],
                            DateCreated = (string)reader[7]
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
            return Task;
        }
    }
}


