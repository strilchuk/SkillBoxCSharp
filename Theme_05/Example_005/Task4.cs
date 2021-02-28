using System;
using Example_005;

namespace Example_005
{
    public static class Task4
    {
        public static void DoTask()
        {
            // Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
            // является заданная последовательность элементами арифметической или геометрической прогрессии
            // 
            // Примечание
            //             http://ru.wikipedia.org/wiki/Арифметическая_прогрессия
            //             http://ru.wikipedia.org/wiki/Геометрическая_прогрессия
            
            Console.Clear();
            UtilsCommon.WriteOnCenter("Выполняем задачу 4");
            var n = UtilsCommon.ReadIntParameter("Введите количество элементов последовательности");
            var arrInt = new int[n];
            for (int i = 0; i < n; i++)
            {
                arrInt[i] = UtilsCommon.ReadIntParameter($"Введите {(i + 1)}й элемент последовательности");
            }

            var resProgression = UtilsMath.IsProgression(arrInt);
            
            Console.WriteLine($"Данная последовательность является арифметической: {(resProgression.isArithmetic ? "Да":"Нет")}");
            Console.WriteLine($"Данная последовательность является геометрической: {(resProgression.isGeometric ? "Да":"Нет")}");
        }
    }
}