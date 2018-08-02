using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Interfaces
{
    public interface IWriteRepository<T> where T : class
    {
        void Add(T item);
    }
}
