using Mapster;
using Neo4jClient;
using Newtonsoft.Json;
using ServiceLibraryNeoClient.DTO;
using ServiceLibraryNeoClient.Interfaces;
using ServiceLibraryNeoClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLibraryNeoClient.Implements
{
    public class ProgramRepository : IProgramRepository<ProgramNode>
    {
        IGraphClient client;

        public ProgramRepository(IGraphClient client)
        {
            this.client = client;
        }

        public void Add(ProgramNode item)
        {
 
            var srcItem = new
            {
                Guid = item.Guid,
                Active = item.Active,
                Title = item.Title,
                Accepted = item.Accepted,
                Type = item.Type
            };

            client.Cypher
                .Merge("(prog:Program {Guid:{progGuid}})")
                .OnCreate()
                .Set("prog = {progParam}")

                .WithParams(
                    new
                    {
                        progGuid = srcItem.Guid,
                        progParam = srcItem
                    })
                 .ExecuteWithoutResults();


            if (!String.IsNullOrEmpty(item.Variant))
            {
                var servParams = new
                {
                    Title = item.Variant
                };

                client.Cypher
                    .Match("(prog {Guid:{progGuid}})")

                    .Merge("(serv:Service {Title:{titleServ}})")
                    .OnCreate()
                    .Set("serv = {servParam}")

                    .WithParams(
                        new
                        {
                            progGuid = item.Guid,

                            titleServ = item.Variant,
                            servParam = servParams
                        })
                     .CreateUnique("(prog)-[:ServiceType]->(serv)")
                     .ExecuteWithoutResults();
            }


            if (item.Form != null && !String.IsNullOrEmpty(item.Form.Title)) {
                client.Cypher
                    .Match("(prog {Guid:{progGuid}})")
                    .Match("(servc {Title:{titleServ}})")

                    .Merge("(form:Form  {Guid:{formGuid}})")
                    .OnCreate()
                    .Set("form = {formParam}")

                    .WithParams(
                        new
                        {
                            progGuid = item.Guid,
                            titleServ = item.Variant,

                            formGuid = item.Form.Guid,
                            formParam = item.Form
                        })
                     .CreateUnique("(prog)-[:PartType]->(form)-[:ServiceForm]->(servc)")
                     .ExecuteWithoutResults();
            }

            if (item.Department != null && !String.IsNullOrEmpty(item.Department.Title))
            {
                client.Cypher
                    .Match("(prog {Guid:{progGuid}})")

                    .Merge("(dept:Department  {Guid:{deptGuid}})")
                    .OnCreate()
                    .Set("dept = {deptParam}")

                    .WithParams(
                        new
                        {
                            progGuid = item.Guid,

                            deptGuid = item.Department.Guid,
                            deptParam = item.Department
                        })
                     .CreateUnique("(prog)-[:inDepartment]->(dept)")
                     .ExecuteWithoutResults();
            }


            if (item.Subjects != null)
            {
                createSubjects(item);
            }



        }

        public ProgramNode Get(string key)
        {
            var query = client.Cypher
                .Match("(n: Program {Guid:{prorgamGuid}})<-[r: PartOf]-(s: Subject)")
                .WithParam("prorgamGuid", key)
                .With("n as prog, collect(s) as col")
                .Unwind("col", "ss")
                .OptionalMatch("(ss)-[aa: ForSubject]->(a: Attestation)<--(nn)")
                .Where("(prog) = (nn) and aa.ProgramGuid = prog.Guid")
                .With("collect(ss {.*, Attestation: a{.*} }) as subjts, prog")
                .Match("(dept:Department)<-[:inDepartment]-(prog)-[:PartType]->(form:Form)")
                .Match("(prog)-[:ServiceType]->(serv:Service)")
                .With("prog { .*, Department: dept{.*}, Form: form{.*}, Variant: serv.Title, Subjects: subjts } as result")
                .Return(result => result.As<ProgramNodeDTO>())
                .Results.FirstOrDefault();

            return query.Adapt<ProgramNode>();
        }

        public IEnumerable<ProgramNode> GetList()
        {
            var query = client.Cypher
                .Match("(n:Program)<-[r:PartOf]-(s:Subject)")
                .With("n as prog, collect(s) as col")
                .Unwind("col", "ss")
                .OptionalMatch("(ss)-[aa:ForSubject]->(a:Attestation)<--(nn)")
                .Where("(prog) = (nn) and aa.ProgramGuid = prog.Guid")
                .With("collect(ss {.*, Attestation: a{.*} }) as subjts, prog")
                .Match("(dept:Department)<-[:inDepartment]-(prog)-[:PartType]->(form:Form)")
                .Match("(prog)-[:ServiceType]->(serv:Service)")
                .With("prog { .*, Department: dept{.*}, Form: form{.*}, Variant: serv.Title, Subjects: subjts } as result")
                .Return(result => result.As<ProgramNodeDTO>())
                .Results;

            return query.Adapt<IEnumerable<ProgramNode>>();
        }


        void createSubjects(ProgramNode item)
        {
            foreach (var subject in item.Subjects)
            {
                var srcSubject = new
                {
                    Guid = subject.Guid,
                    Title = subject.Title,
                    Duration = subject.Duration
                };

                client.Cypher
                    .Match("(prog {Guid:{progGuid}})")

                    .Merge("(subj:Subject {Guid:{subjGuid}})")
                    .OnCreate()
                    .Set("subj = {subjParam}")

                    .WithParams(
                        new
                        {
                            progGuid = item.Guid,

                            subjGuid = subject.Guid,
                            subjParam = srcSubject
                        })
                     .CreateUnique("(prog)<-[:PartOf]-(subj)")
                     .ExecuteWithoutResults();


                if (subject.Attestation != null && !String.IsNullOrEmpty(subject.Attestation.Title))
                {
                    client.Cypher
                        .Match("(prog {Guid:{progGuid}})")
                        .Match("(subj {Guid:{subjGuid}})")

                        .Merge("(att:Attestation {Guid:{attGuid}})")
                        .OnCreate()
                        .Set("att = {attParam}")

                        .WithParams(
                            new
                            {
                                progGuid = item.Guid,
                                subjGuid = subject.Guid,

                                attGuid = subject.Attestation.Guid,
                                attParam = subject.Attestation
                            })
                         .CreateUnique("(prog)-[:ForProgram]->(att)<-[:ForSubject {ProgramGuid:{progGuid}}]-(subj)")
                         .ExecuteWithoutResults();
                }


            }
        }
    }
}
