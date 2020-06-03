using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.BLL.Helpers.Mappers.Interfaces
{
    public interface IObjectMapper<T, U>
    {
        U Map(T input);

        T Map(U input);
    }
}
