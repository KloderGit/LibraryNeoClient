using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Models
{
    public class FormNode
    {
        public string Guid { get; set; }

        /// <summary>
        /// Название Формы обучения Очно / Дистанционно
        /// </summary>
        public string Title { get; set; }
    }
}
