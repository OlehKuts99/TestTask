using System;
using System.Collections.Generic;
using System.Text;
using TestTask.BLL.Filters;

namespace TestTask.BLL.Services.Interfaces
{
    public interface IEntityService<T>
    {
        IEnumerable<T> GetAll(AuthorNameFilter filter = null);

        T Get(int id);

        void Create(T item);

        void Update(int id, T item);

        void Delete(int id);
    }
}
