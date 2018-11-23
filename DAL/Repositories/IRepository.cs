using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IRepository<T> where T : class   
    {
        IEnumerable<T> GetItems();
        IEnumerable<T> GetItemsStartedWith(string started);
        T GetElementById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
