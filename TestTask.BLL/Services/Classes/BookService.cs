using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask.BLL.DTO;
using TestTask.BLL.Filters;
using TestTask.BLL.Helpers.Mappers.Interfaces;
using TestTask.BLL.Services.Interfaces;
using TestTask.DAL.Models;
using TestTask.DAL.UnitOfWork.Interfaces;

namespace TestTask.BLL.Services.Classes
{
    public class BookService<T> : IEntityService<T> where T : BookDTO
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IObjectMapper<Book, BookDTO> _objectMapper;

        public BookService(IUnitOfWork unitOfWork, IObjectMapper<Book, BookDTO> objectMapper)
        {
            _unitOfWork = unitOfWork;
            _objectMapper = objectMapper;
        }

        public void Create(T item)
        {
            _unitOfWork.Books.Create(_objectMapper.Map(item));
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.Books.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public T Get(int id)
        {
            return (T)_objectMapper.Map(_unitOfWork.Books.Get(id));
        }

        public IEnumerable<T> GetAll(AuthorNameFilter filter = null)
        {
            var books = _unitOfWork.Books.GetAll().ToList();
            var result = new List<T>();

            if (filter.Name != null)
            {
                books = books.Where(b => b.AuthorBooks.Where(ab => ab.Author.Name == filter.Name).Count() > 0).ToList();
            }
            if (filter.Limit != 0)
            {
                books = books.Skip((filter.Limit - 1) * filter.Page).Take(filter.Limit).ToList();
            }

            foreach (var book in books)
            {
                result.Add((T)_objectMapper.Map(book));
            }

            return result;
        }

        public void Update(int id, T item)
        {
            _unitOfWork.Books.Update(id, _objectMapper.Map(item));
            _unitOfWork.SaveChanges();
        }
    }
}
