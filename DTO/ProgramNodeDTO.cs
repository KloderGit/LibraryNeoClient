using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.DTO
{
    public class ProgramNodeDTO
    {
        public bool Active { get; set; }
        public string Guid { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Accepted { get; set; }
        public DepartmentNodeDTO Department { get; set; }
        public FormNodeDTO Form { get; set; }
        public string Variant { get; set; }
        public IEnumerable<SubjectNodeDTO> Subjects { get; set; }
    }
}