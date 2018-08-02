using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Interfaces
{
    public interface IReadRepository<T>
    {
        T Get(string key);
        IEnumerable<T> GetList();
    }
}
