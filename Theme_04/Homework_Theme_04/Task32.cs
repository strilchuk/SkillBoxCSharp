using System;

namespace Homework_Theme_04
{
    public class Task32
    {
        public static void doTask32()
        {
            // ** Задание 3.2
            // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
            //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
            //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
            //  
            //  
            //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
            //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
            //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |

            Console.Clear();
            Utils.WriteOnCenter("Выполняем задачу 3.2");
            var InputLabel = "Введите количество строк матриц:";
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
            
            InputLabel = "Введите количество столбцов матриц:";
            Utils.WriteOnCenter(InputLabel);
            error = Utils.UserInputStatus.NoError;
            int m = Utils.ReadInt(1, 999, ref error);
            if (error != Utils.UserInputStatus.NoError)
            {
                do
                {
                    Utils.WriteOnCenter(InputLabel);
                    m = Utils.ReadInt(1, 999, ref error); 
                } while (error != Utils.UserInputStatus.NoError);
            }

            int[,] matrix1 = Utils.getRandomIntMatrix(n, m, 0, 50);
            int[,] matrix2 = Utils.getRandomIntMatrix(n, m, 0, 50);
            int[,] additionMatrix = new int[n, m];
            int[,] subtractionMatrix = new int[n, m];

            //Вычисляем две матрицы
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    additionMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                    subtractionMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            int outputCenter = (n / 2) + 1; // номер строки для вывода символов операций
            
            //выводим сложение матриц
            for (int i = 0; i < n; i++)
            {
                //выводим первую матрицу
                Console.Write("|");
                for (int j = 0; j < m; j++)
                    Console.Write("{0,4}", matrix1[i, j]);
                Console.Write("  |");

                //выводим символ операции сложения 
                if (i == outputCenter - 1) Console.Write(" + ");
                else Console.Write("   ");

                //выводим вторую матрицу
                Console.Write("|");
                for (int j = 0; j < m; j++)
                    Console.Write("{0,4}", matrix2[i, j]);
                Console.Write("  |");

                //выводим символ равенства
                if (i == outputCenter - 1) Console.Write(" = ");
                else Console.Write("   ");

                //выводим результат
                Console.Write("|");
                for (int j = 0; j < m; j++)
                    Console.Write("{0,4}", additionMatrix[i, j]);
                Console.Write("  |");

                Console.WriteLine();
            }
            
            Console.WriteLine();
            Console.WriteLine();
            
            //выводим вычитание матриц
            for (int i = 0; i < n; i++)
            {
                //выводим первую матрицу
                Console.Write("|");
                for (int j = 0; j < m; j++)
                    Console.Write("{0,4}", matrix1[i, j]);
                Console.Write("  |");

                //выводим символ операции вычитания
                if (i == outputCenter - 1) Console.Write(" - ");
                else Console.Write("   ");

                //выводим вторую матрицу
                Console.Write("|");
                for (int j = 0; j < m; j++)
                    Console.Write("{0,4}", matrix2[i, j]);
                Console.Write("  |");

                //выводим символ равенства
                if (i == outputCenter - 1) Console.Write(" = ");
                else Console.Write("   ");

                //выводим результат
                Console.Write("|");
                for (int j = 0; j < m; j++)
                    Console.Write("{0,4}", subtractionMatrix[i, j]);
                Console.Write("  |");

                Console.WriteLine();
            }            
        }
    }
}