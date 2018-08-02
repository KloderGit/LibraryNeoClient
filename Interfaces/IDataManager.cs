using ServiceLibraryNeoClient.Implements;
using ServiceLibraryNeoClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Interfaces
{
    public interface IDataManager
    {
        IProgramRepository<ProgramNode> Programs { get; }
        IDepartmentRepository Departments { get; }
        IPartTime<FormNode> EducationForms { get; }
        IAttestationRepository<AttestationNode> Attestations { get; }
    }
}
