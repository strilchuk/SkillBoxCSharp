using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_01
{
    /// <summary>
    /// Организация хранения и генерации данных
    /// </summary>
    class Repository
    {
        /// <summary>
        /// Множество имен для генерации
        /// </summary>
        static readonly string[] firstNames;

        /// <summary>
        /// Множество фамилий для генерации
        /// </summary>
        static readonly string[] lastNames;

        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        static Random randomize;

        /// <summary>
        /// Статический конструктор, в котором "хранятся"
        /// данные о именах и фамилиях баз данных firstNames и lastNames
        /// </summary>
        static Repository()
        {
            randomize = new Random(); // Размещение в памяти генератора случайных чисел

            // Размещение имен в базе данных firstNames
            firstNames = new string[] {
                "Агата",
                "Агнес",
                "Аделаида",
                "Аделина",
                "Алдона",
                "Алима",
                "Аманда",
            };

            // Размещение фамилий в базе данных lastNames
            lastNames = new string[]
            {
                "Иванова",
                "Петрова",
                "Васильева",
                "Кузнецова",
                "Ковалёва",
                "Попова",
                "Пономарёва",
                "Дьячкова",
                "Коновалова",
                "Соколова",
                "Лебедева",
                "Соловьёва",
                "Козлова",
                "Волкова",
                "Зайцева",
                "Ершова",
                "Карпова",
                "Щукина",
                "Виноградова",
                "Цветкова",
                "Калинина"
            };
        }

        /// <summary>
        /// База данных работников, в которой хранятся 
        /// Имя, фамилия, возраст и зарплаты каждого сотрудника
        /// </summary>
        public List<Student> Students { get; set; }

        /// <summary>
        /// Конструктор, заполняющий базу студентов
        /// </summary>
        /// <param name="Count">Количество студентов, которых нужно создать</param>
        public Repository(int Count)
        {
            this.Students = new List<Student>(); // Выделение памяти для хранения базы данных студентов

            for (int i = 0; i < Count; i++)    // Заполнение базы данных студентов
            {
                String Name = firstNames[Repository.randomize.Next(Repository.firstNames.Length)] + " " +
                    lastNames[Repository.randomize.Next(Repository.lastNames.Length)];

                Dictionary<string, byte> Subjects = new Dictionary<string, byte>();
                Subjects.Add("История", (byte) randomize.Next(3, 5));
                Subjects.Add("Математика", (byte) randomize.Next(3, 5));
                Subjects.Add("Русский язык", (byte) randomize.Next(3, 5));
                // Добавляем нового студента в базу
                this.Students.Add(
                    new Student(Name, // Имя
                        (byte) randomize.Next(17, 22), // Возраст
                        (byte) randomize.Next(130, 190), // Рост
                        Subjects // Предмет
                        ));
            }
        }

        /// <summary>
        /// Выводим строку по центру экрана
        /// </summary>
        /// <param name="Text"></param>
        public void WriteOnCenter(String Text)
        {
            byte columnLength = 33;
            byte cursorLeft = (byte)((Console.WindowWidth - columnLength) / 2);

            Console.CursorLeft = cursorLeft;
            Console.WriteLine(Text);    // Печать в консоль вспомогательного текста
        }

        /// <summary>
        /// Вывод базы студентов в консоль
        /// </summary>
        /// <param name="Text"></param>
        public void Print(string Text)
        {
            WriteOnCenter(Text); // Печать в консоль вспомогательного текста

            // Изменяем цвет шрифта для печати в консоли на Cyan
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Выводим Заголовки колонок базы данных
            WriteOnCenter($"{"Студент",20} {"Возраст",7} {"Рост",4}");

            // Изменяем цвет шрифта для печати в консоли на Gray
            Console.ForegroundColor = ConsoleColor.Gray;

            WriteOnCenter("");
            foreach (var Student in this.Students)
            {
                WriteOnCenter(Student.ToString());

                foreach (KeyValuePair<string, byte> item in Student.Subjects)
                {
                    WriteOnCenter($"{item.Key,13} - {item.Value,1}");
                }
                WriteOnCenter($"Средний бал: {Student.GetAverageScore()}");
                WriteOnCenter("--------------------------------");
            }
        }
    }
}
