using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Create(T item);

        void Update(int id, T item);

        void Delete(int id);
    }
}
