using System;

namespace Homework_Theme_04
{
    public class Task33
    {
        public static void doTask33()
        {
            // *** Задание 3.3
            // Заказчику требуется приложение позволяющщее перемножать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
            //  
            //  |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
            //  |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
            //  |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
            //
            //  
            //                  | 4 |   
            //  |  1  2  3  | х | 5 | = | 32 |
            //                  | 6 |  

            Console.Clear();
            Utils.WriteOnCenter("Выполняем задачу 3.3");

            var InputLabel = "Введите количество строк первой матрицы:";
            Utils.WriteOnCenter(InputLabel);
            var error = Utils.UserInputStatus.NoError;
            int n1 = Utils.ReadInt(1, 999, ref error);
            if (error != Utils.UserInputStatus.NoError)
            {
                do
                {
                    Utils.WriteOnCenter(InputLabel);
                    n1 = Utils.ReadInt(1, 999, ref error); 
                } while (error != Utils.UserInputStatus.NoError);
            }
            
            InputLabel = "Введите количество столбцов первой матрицы:";
            Utils.WriteOnCenter(InputLabel);
            error = Utils.UserInputStatus.NoError;
            int m1 = Utils.ReadInt(1, 999, ref error);
            if (error != Utils.UserInputStatus.NoError)
            {
                do
                {
                    Utils.WriteOnCenter(InputLabel);
                    m1 = Utils.ReadInt(1, 999, ref error); 
                } while (error != Utils.UserInputStatus.NoError);
            }

            int n2 = m1;
            
            InputLabel = "Введите количество столбцов второй матрицы:";
            Utils.WriteOnCenter(InputLabel);
            error = Utils.UserInputStatus.NoError;
            int m2 = Utils.ReadInt(1, 999, ref error);
            if (error != Utils.UserInputStatus.NoError)
            {
                do
                {
                    Utils.WriteOnCenter(InputLabel);
                    m2 = Utils.ReadInt(1, 999, ref error); 
                } while (error != Utils.UserInputStatus.NoError);
            }
            
            int[,] matrix1 = Utils.getRandomIntMatrix(n1, m1, 0, 50);
            int[,] matrix2 = Utils.getRandomIntMatrix(n2, m2, 0, 50);
            int[,] resMatrix = new int[n1, m2];

            //Вычисляем две матрицы
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    resMatrix[i, j] = 0;
                    for (int k = 0; k < m1; k++)
                    {
                        resMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            //Выводим результаты
            int N = (n1 > n2) ? n1 : n2;
            for (int i = 0; i < N; i++)
            {
                //выводим первую матрицу
                if (i < n1)
                {
                    Console.Write("|");
                    for (int j = 0; j < m1; j++)
                        Console.Write("{0,4}", matrix1[i, j]);
                    Console.Write("  |");
                }
                else
                {
                    Console.Write("    ");
                    for (int j = 0; j < m1; j++)
                        Console.Write("    ");
                }

                //выводим символ операции 
                if (i == 0) Console.Write(" x ");
                else Console.Write("   ");

                //выводим вторую матрицу
                if (i < n2)
                {
                    Console.Write("|");
                    for (int j = 0; j < m2; j++)
                        Console.Write("{0,4}", matrix2[i, j]);
                    Console.Write("  |");
                }
                else
                {
                    Console.Write("    ");
                    for (int j = 0; j < m2; j++)
                        Console.Write("    ");
                }

                //выводим символ равенства
                if (i == 0) Console.Write(" = ");
                else Console.Write("   ");

                //выводим результат
                if (i < n1)
                {
                    Console.Write("|");
                    for (int j = 0; j < m2; j++)
                        Console.Write("{0,5}", resMatrix[i, j]);
                    Console.Write("  |");
                }
                else
                {
                    Console.Write("    ");
                    for (int j = 0; j < m2; j++)
                        Console.Write("    ");
                }

                Console.WriteLine();
            }
        }
    }
}