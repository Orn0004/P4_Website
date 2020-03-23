using Microsoft.Extensions.Configuration;
using P4_Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace P4_Data.Queries
{
    public class GetJobs
    {
        private readonly string ConnectionString;
        public GetJobs(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("P4Database");
        }

        public List<Jobs> GetList()
        {
            // variable creation
            var JobList = new List<Jobs>();
            SqlConnection cnn = null;

            try
            {
                // connects to the database.
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();

                // create a variable with the query command.
                SqlCommand command = new SqlCommand("SELECT * FROM JobTable ORDER BY ID", cnn);

                //reads the table.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //as it reads single rows it will print it out untill theres no more in the table.
                    while (reader.Read())
                    {
                        JobList.Add(new Jobs
                        {
                            JobTitel = (string)reader[0],
                            JobBeskrivelse = (string)reader[1],
                            JobLøn = (int)reader[2],
                            JobVarighed = (int)reader[3]
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
            return JobList;
        }
    }
}
