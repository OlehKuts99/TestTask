using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.BLL.Filters
{
    public class BaseFilter
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public BaseFilter()
        {
            this.Page = 1;
        }
    }
}
