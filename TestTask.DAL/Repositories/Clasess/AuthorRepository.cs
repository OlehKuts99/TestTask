using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask.DAL.Context;
using TestTask.DAL.Models;
using TestTask.DAL.Repositories.Interfaces;

namespace TestTask.DAL.Repositories.Clasess
{
    public class AuthorRepository<T> : IRepository<T> where T : Author
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthorRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(T item)
        {
            _applicationDbContext.Authors.Add(item);
        }

        public void Delete(int id)
        {
            var tempItem = _applicationDbContext.Authors.FirstOrDefault(a => a.Id == id);

            if (tempItem != null)
            {
                _applicationDbContext.Authors.Remove(tempItem);
            }
        }

        public T Get(int id)
        {
            return (T)_applicationDbContext.Authors.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return (IEnumerable<T>)_applicationDbContext.Authors.ToList();
        }

        public void Update(int id, T item)
        {
            var tempItem = _applicationDbContext.Authors.Find(id);

            if (tempItem != null)
            {
                _applicationDbContext.Entry(tempItem).State = EntityState.Detached;
                _applicationDbContext.Update(item);
            }
        }
    }
}
