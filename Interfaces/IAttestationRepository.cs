using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Interfaces
{
    public interface IAttestationRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
    {

    }
}
