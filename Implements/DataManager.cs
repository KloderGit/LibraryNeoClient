using Neo4jClient;

using ServiceLibraryNeoClient.Interfaces;
using ServiceLibraryNeoClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Implements
{
    public class DataManager : IDataManager
    {
        IGraphClient client;        

        IProgramRepository<ProgramNode> ProgramRepository;
        IDepartmentRepository DepartmentRepository;
        IPartTime<FormNode> EducationFormRepository;
        IAttestationRepository<AttestationNode> AttestationRepository;

        public DataManager()
        {

            this.client = new Neo4jClient.GraphClient(new Uri("http://localhost:7474/db/data"));

            client.Connect();
        }


        public IProgramRepository<ProgramNode> Programs => ProgramRepository ?? (ProgramRepository = new ProgramRepository(client));
        public IDepartmentRepository Departments => DepartmentRepository ?? (DepartmentRepository = new DepartmentRepository(client));
        public IPartTime<FormNode> EducationForms => EducationFormRepository ?? (EducationFormRepository = new PartTimeRepository(client));
        public IAttestationRepository<AttestationNode> Attestations => AttestationRepository ?? (AttestationRepository = new AttestationRepository(client));
    }
}
