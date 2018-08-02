using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibraryNeoClient.Models
{
    public class LabelDictionary
    {
        Dictionary<string, string> Variants = new Dictionary<string, string>();
        Dictionary<string, string> Types = new Dictionary<string, string>();

        public LabelDictionary()
        {
            //  Перечисление всех Типов программ в 1С и соответствующие им Лейблы

            Types.Add("Краткосрочная программа Школы Управления", "Course");
            Types.Add("Программа обучения", "Course");
            Types.Add("Семинар", "Seminar");


            //  Перечисление всех Видов программ в 1С и соответствующие им Лейблы

            Variants.Add("Дополнительные общеразвивающие программы", "Education");
            Variants.Add("Дополнительные предпрофессиональные программы", "Education");
            Variants.Add("Курсы повышения квалификации", "Education");
            Variants.Add("Обучение", "Education");
            Variants.Add("Подготовка управляющих кадров", "Education");
            Variants.Add("Программы MBA", "Education");
            Variants.Add("Программы повышения квалификации", "Education");
            Variants.Add("Программы профессионального обучения", "Education");
            Variants.Add("Программы профессиональной переподготовки", "Education");
            Variants.Add("Профессиональная переподготовка", "Education");
            Variants.Add("Стажировка", "Traineeship");
            Variants.Add("Квалификация", "Qualification");
        }

        internal string GetVariant(string key)
        {
            return Variants[key];
        }

        internal string GetType(string key)
        {
            return Types[key];
        }
    }
}