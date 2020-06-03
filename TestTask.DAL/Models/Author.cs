using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.DAL.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public short Year { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
