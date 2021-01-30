using System;
using Example_005;

namespace Example_005
{
    public static class Task5
    {
        public static void DoTask()
        {
            // *Задание 5
            // Вычислить, используя рекурсию, функцию Аккермана:
            // A(2, 5), A(1, 2)
            // A(n, m) = m + 1, если n = 0,
            //         = A(n - 1, 1), если n <> 0, m = 0,
            //         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
            
            Console.Clear();
            UtilsCommon.WriteOnCenter("Выполняем задачу 5");
            
        }
    }
}