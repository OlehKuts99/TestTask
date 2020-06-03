using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask.BLL.DTO;
using TestTask.BLL.Helpers.Mappers.Interfaces;
using TestTask.DAL.Models;
using TestTask.DAL.UnitOfWork.Interfaces;

namespace TestTask.BLL.Helpers.Mappers.Classes
{
    public class BookMapper<T, U> : IObjectMapper<T, U> where T : Book where U : BookDTO
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public U Map(T input)
        {
            return (U)new BookDTO()
            {
                Id = input.Id,
                Description = input.Description,
                Name = input.Name,
                Year = input.Year,
                PagesCount = input.PagesCount,
                Authors = _unitOfWork.Authors.GetAll().Where(a => input.AuthorBooks.Where(ab => ab.BookId == input.Id)
                    .Select(ab => ab.AuthorId).Contains(a.Id)).ToList()
            };
        }

        public T Map(U input)
        {
            var tempAuthorBooks = new List<AuthorBook>();

            foreach (var author in input.Authors)
            {
                tempAuthorBooks.Add(new AuthorBook() { AuthorId = author.Id, BookId = input.Id });
            }

            return (T)new Book()
            {
                Id = input.Id,
                Description = input.Description,
                Name = input.Name,
                Year = input.Year,
                PagesCount = input.PagesCount,
                AuthorBooks = tempAuthorBooks
            };
        }
    }
}
