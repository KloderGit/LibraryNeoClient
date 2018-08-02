using ServiceLibraryNeoClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Interfaces
{
    public interface IDepartmentRepository : IReadRepository<DepartmentNode>, IWriteRepository<DepartmentNode>
    {
    }
}
