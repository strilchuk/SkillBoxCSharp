using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_01
{
    /// <summary>
    /// Класс, описывающий модель контакта
    /// </summary>
    class Student
    {
        /// <summary>
        /// Имя студента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возраст студента
        /// </summary>
        public byte Age { get; set; }

        /// <summary>
        /// Рост студента
        /// </summary>
        public byte Height { get; set; }

        /// <summary>
        /// Предметы
        /// </summary>
        public Dictionary<string, byte> Subjects { get; set; }

        /// <summary>
        /// Конструктор класса студент
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="Subjects"></param>
        public Student(string Name, byte Age, byte Height, Dictionary<string, byte> Subjects)
        {
            this.Name = Name;       // Сохранить переданное значение имени
            this.Age = Age;         // Сохранить переданное значение возраста
            this.Height = Height;   // Сохранить переданное значение роста
            this.Subjects = Subjects; // Сохранить переданное значение предметов
        }

        public float GetAverageScore()
        {
            float result = 0;
            if (this.Subjects.Count > 0)
            {
                byte countSubj = 0;
                foreach (KeyValuePair<string, byte> Subject in this.Subjects)
                {
                    countSubj++;
                    result += Subject.Value;
                }
                result = (float)Math.Round(result / countSubj, 2);
            }
            return result;
        }

        /// <summary>
        /// Организация вывода информации о студенте
        /// </summary>
        /// <returns>Строковое представление информации</returns>
        public override string ToString()
        {
            return $"{Name, 20} {Age,7} {Height,4}";
        }

    }
}
