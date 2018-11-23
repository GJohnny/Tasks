using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly SqlConnection _connection;
        private SqlCommand _command;
        public ProductRepository(SqlConnection connection)
        {
            _connection = connection;
        }


        public void Add(Product entity)
        {
            string sqlCommand = "Insert Into Products " +
                                "(Name, Count) Values " +
                               $"('{entity.Name}','{entity.Count}')";

            using (_connection)
            {
                _connection.Open();
                _command = new SqlCommand(sqlCommand, _connection);
                _command.ExecuteNonQuery();
            }
        }

        public void Delete(Product entity)
        {
            string sqlCommand = "Delete from Products " +
                               $"Where Id = '{entity.Id}'";

            using (_connection)
            {
                _connection.Open();
                _command = new SqlCommand(sqlCommand, _connection);
                _command.ExecuteNonQuery();
            }
        }

        public Product GetElementById(int id)
        {
            Product result = null;
            string sqlCommand = "Select * From Products " +
                               $"Where Id = '{id}'";

            using (_connection)
            {
                _connection.Open();
                _command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.Read())
                {
                    result = new Product
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Count = (int)reader["Count"]
                    };
                }
            }
            return result;
        }

        public Product GetElementByName(string name)
        {
            Product result = null;
            string sqlCommand = "Select * From Products " +
                               $"Where Name = '{name}'";

            using (_connection)
            {
                _connection.Open();
                _command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.Read())
                {
                    result = new Product
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Count = (int)reader["Count"]
                    };
                }
            }
            return result;
        }
        public IEnumerable<Product> GetItems()
        {
            List<Product> products = new List<Product>();
            string sqlCommand = "Select * From Products";

            using (_connection)
            {
                _connection.Open();
                _command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Count = (int)reader["Count"],
                    });
                }
            }
            return products;
        }

        public IEnumerable<Product> GetItemsStartedWith(string started)
        {
            List<Product> products = new List<Product>();
            string sqlCommand = "Select * From Products " +
                               $"Where Name Like '{started}%'";

            using (_connection)
            {
                _connection.Open();
                _command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Count = (int)reader["Count"],
                    });
                }
            }
            return products;
        }
        public void Update(Product entity)
        {
            string sqlCommand = "Update Products " +
                        $"Set Count = '{entity.Count}' " +
                        $"Where Id = '{entity.Id}'";

            using (_connection)
            {
                _connection.Open();
                _command = new SqlCommand(sqlCommand, _connection);
                _command.ExecuteNonQuery();
            }
        }

        public void Update(string sqlCommand)
        {
            using (_connection)
            {
                _connection.Open();
                _command = new SqlCommand(sqlCommand, _connection);
                _command.ExecuteNonQuery();
            }
        }

    }
}
