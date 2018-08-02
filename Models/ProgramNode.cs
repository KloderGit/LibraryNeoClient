using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Models
{
    public class ProgramNode
    {
        public string Guid { get; set; }

        /// <summary>
        /// Активность
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Название программы
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тип - Обучение / Стажировка
        /// </summary>
        public string Variant { get; set; }

        /// <summary>
        /// Вид проведения - Курс / Семинар
        /// </summary>
        public string @Type { get; set; }

        /// <summary>
        /// Форма проведения - Очно / Дистанционно
        /// </summary>
        public FormNode Form { get; set; }

        /// <summary>
        /// Название Направления обучения - УЦ / ШУ
        /// </summary>
        public DepartmentNode Department { get; set; }

        /// <summary>
        /// Название Направления обучения - УЦ / ШУ
        /// </summary>
        public IEnumerable<SubjectNode> Subjects { get; set; }

        /// <summary>
        /// Дата утверждения
        /// </summary>
        public DateTime Accepted { get; set; }

        internal string GetServiceName()
        {
            var labelDictionary = new LabelDictionary();
            return labelDictionary.GetVariant(this.Variant);
        }

        internal string GetTypeName()
        {
            var labelDictionary = new LabelDictionary();
            return labelDictionary.GetType(this.Type);
        }
    }
}
