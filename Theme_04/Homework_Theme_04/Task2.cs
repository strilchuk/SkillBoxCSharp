using System;

namespace Homework_Theme_04
{
    public class Task2
    {
        public static void doTask2()
        {
            // * Задание 2
            // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
            // 
            // При N = 9. Треугольник выглядит следующим образом:
            //                                 1
            //                             1       1
            //                         1       2       1
            //                     1       3       3       1
            //                 1       4       6       4       1
            //             1       5      10      10       5       1
            //         1       6      15      20      15       6       1
            //     1       7      21      35      35       21      7       1
            //                                                              
            //                                                              
            // Простое решение:                                                             
            // 1
            // 1       1
            // 1       2       1
            // 1       3       3       1
            // 1       4       6       4       1
            // 1       5      10      10       5       1
            // 1       6      15      20      15       6       1
            // 1       7      21      35      35       21      7       1
            // 
            // Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля
            
            Console.Clear();
            Utils.WriteOnCenter("Выполняем задачу 2");
            var InputLabel = "Введите размерность треугольника:";
            Utils.WriteOnCenter(InputLabel);
            var error = Utils.UserInputStatus.NoError;
            int n = Utils.ReadInt(0, 25, ref error);
            if (error != Utils.UserInputStatus.NoError)
            {
                do
                {
                    Utils.WriteOnCenter(InputLabel);
                    n = Utils.ReadInt(1, 25, ref error); 
                } while (error != Utils.UserInputStatus.NoError);
            }
            triangleRender(n);
        }

        private static void triangleRender(int n)
        {
            int c;
            for (int i = 0; i <= n; i++)
            {
                // for (c = 0; c <= (n - i); c++) // отступы слева, чем ниже строка, тем меньше отступ
                // {
                //     Console.Write(" "); 
                // }
                string outString = "";
                for (c = 0; c <= i; c++)
                {
                    //Console.Write(" "); // пробелы между элементами треугольника
                    int elem = (int)Math.Round(Utils.factorial(i) / (Utils.factorial(c) * Utils.factorial(i - c)));
                    outString += " " + elem.ToString();
                    //Console.Write(elem);
                }
                Utils.WriteOnCenter(outString, true);
                Utils.WriteOnCenter("");
            }
            Console.ReadLine();
        }
    }
}