using System;
using System.Collections.Generic;
using System.Text;
using TestTask.DAL.Models;

namespace TestTask.BLL.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public short Year { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
