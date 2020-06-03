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
    public class AuthorService<T> : IEntityService<T> where T : AuthorDTO
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IObjectMapper<Author, AuthorDTO> _objectMapper;

        public AuthorService(IUnitOfWork unitOfWork, IObjectMapper<Author, AuthorDTO> objectMapper)
        {
            _unitOfWork = unitOfWork;
            _objectMapper = objectMapper;
        }

        public void Create(T item)
        {
            _unitOfWork.Authors.Create(_objectMapper.Map(item));
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.Authors.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public T Get(int id)
        {
            return (T)_objectMapper.Map(_unitOfWork.Authors.Get(id));
        }

        public IEnumerable<T> GetAll(AuthorNameFilter filter = null)
        {
            var authors = _unitOfWork.Authors.GetAll().ToList();
            var result = new List<T>();

            if (filter.Name != null)
            {
                authors = authors.Where(a => a.Name == filter.Name).ToList();
            }
            if (filter.Limit != 0)
            {
                authors = authors.Skip((filter.Limit - 1) * filter.Page).Take(filter.Limit).ToList();
            }

            foreach (var author in authors)
            {
                result.Add((T)_objectMapper.Map(author));
            }

            return result;
        }

        public void Update(int id, T item)
        {
            _unitOfWork.Authors.Update(id, _objectMapper.Map(item));
            _unitOfWork.SaveChanges();
        }
    }
}
