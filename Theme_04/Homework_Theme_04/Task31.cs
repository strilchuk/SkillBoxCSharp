using System;

namespace Homework_Theme_04
{
    public class Task31
    {
        public static void doTask31()
        {
            // * Задание 3.1
            // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
            // Добавить возможность ввода количество строк и столцов матрицы и число,
            // на которое будет производиться умножение.
            // Матрицы заполняются автоматически. 
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //
            //      |  1  3  5  |   |  5  15  25  |
            //  5 х |  4  5  7  | = | 20  25  35  |
            //      |  5  3  1  |   | 25  15   5  |
            
            Console.Clear();
            Utils.WriteOnCenter("Выполняем задачу 3.1");
            var InputLabel = "Введите количество строк матрицы:";
            Utils.WriteOnCenter(InputLabel);
            var error = Utils.UserInputStatus.NoError;
            int n = Utils.ReadInt(1, 999, ref error);
            if (error != Utils.UserInputStatus.NoError)
            {
                do
                {
                    Utils.WriteOnCenter(InputLabel);
                    n = Utils.ReadInt(1, 999, ref error); 
                } while (error != Utils.UserInputStatus.NoError);
            }
            
            InputLabel = "Введите количество столбцов матрицы:";
            Utils.WriteOnCenter(InputLabel);
            error = Utils.UserInputStatus.NoError;
            int m = Utils.ReadInt(1, 999, ref error);
            if (error != Utils.UserInputStatus.NoError)
            {
                do
                {
                    Utils.WriteOnCenter(InputLabel);
                    n = Utils.ReadInt(1, 999, ref error); 
                } while (error != Utils.UserInputStatus.NoError);
            }

            InputLabel = "Введите число, на которое нужно умножить матрицу:";
            Utils.WriteOnCenter(InputLabel);
            error = Utils.UserInputStatus.NoError;
            int k = Utils.ReadInt(0, 999, ref error);
            if (error != Utils.UserInputStatus.NoError)
            {
                do
                {
                    Utils.WriteOnCenter(InputLabel);
                    k = Utils.ReadInt(1, 999, ref error); 
                } while (error != Utils.UserInputStatus.NoError);
            }

            int[,] matrix = Utils.getRandomIntMatrix(n, m, 0, 50);
            int[,] resMatrix = new int[n,m];

            //Вычисляем умножение матрицы на число
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    resMatrix[i, j] = matrix[i, j] * k;
                }
            }

            int outputCenter = (n / 2) + 1; // номер строки для вывода символов операций
            
            //выводим умножение матрицы на число
            for (int i = 0; i < n; i++)
            {
                // выводим число, на которое умножаем матрицу
                if (i == outputCenter - 1) Console.Write("{0,6} x ", k);
                else Console.Write("         ");

                // выводим матрцу
                Console.Write("|");
                for (int j = 0; j < m; j++)
                    Console.Write("{0,4}", matrix[i,j]);
                Console.Write("  |");
                
                //выводим символ равенства
                if (i == outputCenter - 1) Console.Write(" = ");
                else Console.Write("   ");

                //выводим результирующую матрицу
                Console.Write("|");
                for (int j = 0; j < m; j++)
                    Console.Write("{0,4}", resMatrix[i,j]);
                Console.Write("  |");
                
                Console.WriteLine();
            }
        }
    }
}