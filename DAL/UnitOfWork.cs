using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private SqlConnection _connection;
        private ProductRepository productRepository;
        private UserRepository userRepository;
        private string connectionString = "Server=DESKTOP-72FEJ79;Database=FincaUserProductDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public ProductRepository ProductRepository
        {
            get
            {
                _connection = new SqlConnection(connectionString);
                productRepository = new ProductRepository(_connection);
                return productRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                _connection = new SqlConnection(connectionString);

                userRepository = new UserRepository(_connection);
                return userRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _connection.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
