using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.BLL.Filters
{
    public class AuthorNameFilter : BaseFilter
    {
        public string Name { get; set; }

        public AuthorNameFilter() : base()
        {
        }
    }
}
