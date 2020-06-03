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
    public class AuthorMapper<T, U> : IObjectMapper<T, U> where T : Author where U : AuthorDTO
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public U Map(T input)
        {
            return (U)new AuthorDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Year = input.Year,
                Books = _unitOfWork.Books.GetAll().Where(b => input.AuthorBooks.Where(ab => ab.AuthorId == input.Id)
                    .Select(ab => ab.BookId).Contains(b.Id)).ToList()
            };
        }

        public T Map(U input)
        {
            var tempAuthorBooks = new List<AuthorBook>();

            foreach (var book in input.Books)
            {
                tempAuthorBooks.Add(new AuthorBook() { AuthorId = input.Id, BookId = book.Id });
            }

            return (T)new Author()
            {
                Id = input.Id,
                Name = input.Name,
                Year = input.Year,
                AuthorBooks = tempAuthorBooks
            };
        }
    }
}
