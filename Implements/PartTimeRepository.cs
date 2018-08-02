using Neo4jClient;
using ServiceLibraryNeoClient.Interfaces;
using ServiceLibraryNeoClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Implements
{
    public class PartTimeRepository : IPartTime<FormNode>
    {
        IGraphClient client;

        public PartTimeRepository(IGraphClient client)
        {
            this.client = client;
        }

        public void Add(FormNode item)
        {
            client.Cypher
                .Merge("(att:EducationForm  {Guid:{itemGuid}})")
                .OnCreate()
                .Set("att = {itemParam}")

                .WithParams(
                    new
                    {
                        itemGuid = item.Guid,
                        itemParam = item
                    })
                 .ExecuteWithoutResults();
        }

        public FormNode Get(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FormNode> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
