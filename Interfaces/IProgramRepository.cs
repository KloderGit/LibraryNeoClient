using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Interfaces
{
    public interface IProgramRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
    {
    }
}
