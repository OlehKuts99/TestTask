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
    public class BookRepository<T> : IRepository<T> where T : Book
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(T item)
        {
            _applicationDbContext.Books.Add(item);
        }

        public void Delete(int id)
        {
            var tempItem = _applicationDbContext.Books.FirstOrDefault(b => b.Id == id);

            if (tempItem != null)
            {
                _applicationDbContext.Books.Remove(tempItem);
            }
        }

        public T Get(int id)
        {
            return (T)_applicationDbContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return (IEnumerable<T>)_applicationDbContext.Books.ToList();
        }

        public void Update(int id, T item)
        {
            var tempItem = _applicationDbContext.Books.Find(id);

            if (tempItem != null)
            {
                _applicationDbContext.Entry(tempItem).State = EntityState.Detached;
                _applicationDbContext.Update(item);
            }
        }
    }
}
