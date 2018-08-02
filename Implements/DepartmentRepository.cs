using Neo4jClient;
using ServiceLibraryNeoClient.Interfaces;
using ServiceLibraryNeoClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Implements
{
    public class DepartmentRepository : IDepartmentRepository
    {
        IGraphClient client;

        public DepartmentRepository(IGraphClient client)
        {
            this.client = client;
        }

        public void Add(DepartmentNode item)
        {
            client.Cypher
                .Merge("(att:Department  {Guid:{deptGuid}})")
                .OnCreate()
                .Set("att = {deptParam}")

                .WithParams(
                    new
                    {
                        deptGuid = item.Guid,
                        deptParam = item
                    })
                 .ExecuteWithoutResults();
        }

        public DepartmentNode Get(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentNode> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
