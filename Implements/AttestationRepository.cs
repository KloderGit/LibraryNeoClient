using Neo4jClient;
using ServiceLibraryNeoClient.Interfaces;
using ServiceLibraryNeoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLibraryNeoClient.Implements
{
    public class AttestationRepository : IAttestationRepository<AttestationNode>
    {
        IGraphClient client;

        public AttestationRepository(IGraphClient client)
        {
            this.client = client;
        }

        public void Add(AttestationNode item)
        {
            client.Cypher
                .Merge("(att:Attestation  {Guid:{attGuid}})")
                .OnCreate()
                .Set("att = {attParam}")

                .WithParams(
                    new
                    {
                        attGuid = item.Guid,
                        attParam = item
                    })
                 .ExecuteWithoutResults();
        }

        public AttestationNode Get(string key)
        {
            var query = client.Cypher
                .Match("(att:Attestation {Guid:{guid}})")
                .WithParam("guid", key)
                .Return(subj => subj.As<AttestationNode>())
                .Results.SingleOrDefault();

            return query;
        }

        public IEnumerable<AttestationNode> GetList()
        {
            var query = client.Cypher
                .Match("(att:Attestation)")
                .Return(prog => prog.As<AttestationNode>())
                .Results;

            return query;
        }
    }
}
