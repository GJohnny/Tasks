using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly SqlConnection _connection;
        private SqlCommand _command;
        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }
        public void Add(User entity)
        {
            string sqlCommand = "Insert Into Users" +
                                "(Name, Surname, Username, Password, AdminRole) Values" +
                               $"('{entity.Name}','{entity.Surname}','{entity.Username}'," +
                               $"'{entity.Password}', '{entity.AdminRole}')";

            using (_connection)
            {
                _command = new SqlCommand(sqlCommand, _connection);
                _command.ExecuteNonQuery();
            }
        }

        public void Delete(User entity)
        {
            string sqlCommand = "Delete from Users" +
                               $"Where Id = '{entity.Id}'";

            using (_connection)
            {
                _command = new SqlCommand(sqlCommand, _connection);
                _command.ExecuteNonQuery();
            }
        }

        public User GetElementById(int id)
        {
            User result = null;
            string sqlCommand = "Select * From Users" +
                               $"Where Id = '{id}'";

            using (_connection)
            {
                _command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                result = new User
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surname"],
                    Username = (string)reader["Usrname"],
                    Password = (string)reader["Password"],
                    AdminRole = (bool)reader["AdminRole"]
                };
            }
            return result;
        }
        public User GetUserByUsername(string username)
        {
            User result = null;
            string sqlCommand = "Select * From Users " +
                               $"Where Username = '{username}'";

            using (_connection)
            {
                _command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                result = new User
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surname"],
                    Username = (string)reader["Username"],
                    Password = (string)reader["Password"],
                    AdminRole = (bool)reader["AdminRole"]
                };
            }
            return result;
        }

        public IEnumerable<User> GetItems()
        {
            List<User> users = new List<User>();
            string sqlCommand = "Select * From Users";

            using (_connection)
            {
                _command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        AdminRole = (bool)reader["AdminRole"]
                    });
                }
            }
            return users;
        }

        public IEnumerable<User> GetItemsStartedWith(string started)
        {
            List<User> users = new List<User>();
            string sqlCommand = "Select * From Users" +
                               $"Where Name Like '{started}%'";

            using (_connection)
            {
                _command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        AdminRole = (bool)reader["AdminRole"]
                    });
                }
            }
            return users;
        }
        public void Update(User entity)
        {
            string sqlCommand = "Update Users " +
                        $"Set Name = '{entity.Name}', Surname = '{entity.Surname}'," +
                        $"Username = '{entity.Username}', Password = '{entity.Password}'," +
                        $"AdminRole = '{entity.AdminRole}'" +
                        $"Where Id = '{entity.Id}'";

            using (_connection)
            {
                _command = new SqlCommand(sqlCommand, _connection);
                _command.ExecuteNonQuery();
            }
        }
    }
}
