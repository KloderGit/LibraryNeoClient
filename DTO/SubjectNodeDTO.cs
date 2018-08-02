using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.DTO
{
    public class SubjectNodeDTO
    {
        public string Guid { get; set; }
        public int Duration { get; set; }
        public string Title { get; set; }
        public AttestationNodeDTO Attestation { get; set; }
    }
}