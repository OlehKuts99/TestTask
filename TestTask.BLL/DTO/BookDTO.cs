
using System;
using System.Collections.Generic;
using System.Text;
using TestTask.DAL.Models;

namespace TestTask.BLL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public short Year { get; set; }

        public int PagesCount { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
