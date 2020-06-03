using System;
using System.Collections.Generic;
using System.Text;
using TestTask.DAL.Models;
using TestTask.DAL.Repositories.Interfaces;

namespace TestTask.DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }

        IRepository<Author> Authors { get; }

        int SaveChanges();
    }
}
