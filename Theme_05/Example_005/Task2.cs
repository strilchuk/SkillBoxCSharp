using System;
using Example_005;

namespace Example_005
{
    public static class Task2
    {
        public static void DoTask()
        {
            // Задание 2.
            // 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
            // 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
            // Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
            // Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
            // 1. Ответ: А
            // 2. ГГГГ, ДДДД
            
            Console.Clear();
            UtilsCommon.WriteOnCenter("Выполняем задачу 2");
            var text = UtilsCommon.ReadStringParameter("1. Введите текст:");

            var shortestWord = UtilsString.GetShortestWord(text);
            var arrayLongestWords = UtilsString.GetLongestWords(text);

            Console.WriteLine($"1. Ответ: {shortestWord}");
            Console.WriteLine($"2. {string.Join(", ", arrayLongestWords)}");

        }
    }
}