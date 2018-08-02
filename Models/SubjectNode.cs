using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Models
{
    public class SubjectNode
    {
        public string Guid { get; set; }

        /// <summary>
        /// Название дисциплины
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Продолжительность
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Аттестация
        /// </summary>
        public AttestationNode Attestation { get; set; }
    }
}
