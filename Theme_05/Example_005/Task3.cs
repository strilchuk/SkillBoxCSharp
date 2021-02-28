using System;
using Example_005;

namespace Example_005
{
    public static class Task3
    {
        public static void DoTask()
        {
            // Задание 3. Создать метод, принимающий текст. 
            // Результатом работы метода должен быть новый текст, в котором
            // удалены все кратные рядом стоящие символы, оставив по одному 
            // Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
            // Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день
            
            Console.Clear();
            UtilsCommon.WriteOnCenter("Выполняем задачу 3");
            var text = UtilsCommon.ReadStringParameter("1. Введите текст:");
            var handledText = UtilsString.GroupTextByChars(text);
            Console.WriteLine($"{text} >>> {handledText}");
        }
    }
}