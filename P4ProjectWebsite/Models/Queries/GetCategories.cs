using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models.Queries
{
    public class GetCategories
    {
        private readonly string ConnectionString;
        public GetCategories(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("P4Database");
        }
        public List<CategoryEntity> GetList()
        {
            // variable creation
            var Categories = new List<CategoryEntity>();
            SqlConnection cnn = null;

            try
            {
                // connects to the database.
                using (cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();

                    string query = "SELECT Name, Type FROM TaskCategories ORDER BY Type";
                    using (SqlCommand command = new SqlCommand(query, cnn))
                    {
                        //reads the table.
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //as it reads single rows it will print it out untill theres no more in the table.
                            while (reader.Read())
                            {
                                Categories.Add(new CategoryEntity
                                {
                                    Name = (string)reader[0],
                                    Type = (string)reader[1]
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
            return Categories;
        }
    }
}

