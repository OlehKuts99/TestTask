using System;
using System.Collections.Generic;
using System.Text;
using TestTask.DAL.Context;
using TestTask.DAL.Models;
using TestTask.DAL.Repositories.Clasess;
using TestTask.DAL.Repositories.Interfaces;
using TestTask.DAL.UnitOfWork.Interfaces;

namespace TestTask.DAL.UnitOfWork.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _applicationContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            _applicationContext = context;
        }

        public IRepository<Book> Books => new BookRepository<Book>(_applicationContext);

        public IRepository<Author> Authors => new AuthorRepository<Author>(_applicationContext);

        public int SaveChanges()
        {
            return _applicationContext.SaveChanges();
        }
    }
}
