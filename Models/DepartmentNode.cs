using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Models
{
    public class DepartmentNode
    {
        public string Guid { get; set; }

        /// <summary>
        /// Название Направления обучения - УЦ / ШУ
        /// </summary>
        public string Title { get; set; }
    }
}
