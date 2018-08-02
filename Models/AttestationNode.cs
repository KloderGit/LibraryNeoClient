using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Models
{
    public class AttestationNode
    {
        public string Guid { get; set; }

        /// <summary>
        /// Название Аттестации Экзамен \ Зачет
        /// </summary>
        public string Title { get; set; }
    }
}
