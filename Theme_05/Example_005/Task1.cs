using System;
using Example_005;

namespace Example_005
{
    public static class Task1
    {
        public static void DoTask()
        {
            // Задание 1.
            // Воспользовавшись решением задания 3 четвертого модуля
            // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
            // 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
            // 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение
            
            Console.Clear();
            UtilsCommon.WriteOnCenter("Выполняем задачу 1");
            UtilsCommon.WriteOnCenter("");
            UtilsCommon.WriteOnCenter("Умножение матрицы на число");
            UtilsCommon.WriteOnCenter("");
            var n = UtilsCommon.ReadIntParameter("Введите количество строк матрицы:");
            var m = UtilsCommon.ReadIntParameter("Введите количество столбцов матрицы:");
            var k = UtilsCommon.ReadIntParameter("Введите число, на которое нужно умножить матрицу:");
            var matrix = UtilsArray.GetRandomIntMatrix(n, m, 0, 50);
            var resMatrix = UtilsArray.MultiplyMatrixByNumber(matrix, k);
            OutputMultiplyMatrixByNumberResult(k, matrix, resMatrix);
            
            UtilsCommon.WriteOnCenter("");
            UtilsCommon.WriteOnCenter("Сложение двух матриц");
            UtilsCommon.WriteOnCenter("");
            n = UtilsCommon.ReadIntParameter("Введите количество строк матрицы:");
            m = UtilsCommon.ReadIntParameter("Введите количество столбцов матрицы:");
            var matrix1 = UtilsArray.GetRandomIntMatrix(n, m, 0, 50);
            var matrix2 = UtilsArray.GetRandomIntMatrix(n, m, 0, 50);
            resMatrix = UtilsArray.SummationMatrix(matrix1, matrix2, UtilsArray.MatrixOperation.Plus);
            OutputSummationMatrixResult(matrix1, matrix2, resMatrix);
            
            UtilsCommon.WriteOnCenter("");
            UtilsCommon.WriteOnCenter("Умножение двух матриц");
            UtilsCommon.WriteOnCenter("");
            var n1 = UtilsCommon.ReadIntParameter("Введите количество строк 1й матрицы:");
            var m1 = UtilsCommon.ReadIntParameter("Введите количество столбцов 1й матрицы:");
            var n2 = m1;
            var m2 = UtilsCommon.ReadIntParameter("Введите количество столбцов 2й матрицы:");
            matrix1 = UtilsArray.GetRandomIntMatrix(n1, m1, 0, 50);
            matrix2 = UtilsArray.GetRandomIntMatrix(n2, m2, 0, 50);
            resMatrix = UtilsArray.MatrixMultiplication(matrix1, matrix2);
            OutputMatrixMultiplicationResult(matrix1, matrix2, resMatrix);            
        }

        private static void OutputMultiplyMatrixByNumberResult(int k, int[,] matrix, int[,] resMatrix)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);
            var outputCenter = (n / 2) + 1; // номер строки для вывода символов операций
            
            //выводим умножение матрицы на число
            for (var i = 0; i < n; i++)
            {
                // выводим число, на которое умножаем матрицу
                if (i == outputCenter - 1) Console.Write("{0,6} x ", k);
                else Console.Write("         ");

                // выводим матрцу
                Console.Write("|");
                for (var j = 0; j < m; j++)
                    Console.Write("{0,4}", matrix[i,j]);
                Console.Write("  |");
                
                //выводим символ равенства
                Console.Write(i == outputCenter - 1 ? " = " : "   ");

                //выводим результирующую матрицу
                Console.Write("|");
                for (var j = 0; j < m; j++)
                    Console.Write("{0,4}", resMatrix[i,j]);
                Console.Write("  |");
                
                Console.WriteLine();
            }
        }
        private static void OutputSummationMatrixResult(int[,] matrix1, int[,] matrix2, int[,] resMatrix)
        {
            var n = matrix1.GetLength(0);
            var m = matrix1.GetLength(1);
            var outputCenter = (n / 2) + 1; // номер строки для вывода символов операций
            
            for (var i = 0; i < n; i++)
            {
                //выводим первую матрицу
                Console.Write("|");
                for (var j = 0; j < m; j++)
                    Console.Write("{0,4}", matrix1[i, j]);
                Console.Write("  |");

                //выводим символ операции сложения 
                Console.Write(i == outputCenter - 1 ? " + " : "   ");

                //выводим вторую матрицу
                Console.Write("|");
                for (var j = 0; j < m; j++)
                    Console.Write("{0,4}", matrix2[i, j]);
                Console.Write("  |");

                //выводим символ равенства
                Console.Write(i == outputCenter - 1 ? " = " : "   ");

                //выводим результат
                Console.Write("|");
                for (var j = 0; j < m; j++)
                    Console.Write("{0,4}", resMatrix[i, j]);
                Console.Write("  |");

                Console.WriteLine();
            }
        }
        private static void OutputMatrixMultiplicationResult(int[,] matrix1, int[,] matrix2, int[,] resMatrix)
        {
            var n1 = matrix1.GetLength(0);
            var m1 = matrix1.GetLength(1);
            
            var n2 = matrix2.GetLength(0);
            var m2 = matrix2.GetLength(1);
            
            var n = (n1 > n2) ? n1 : n2;
            for (var i = 0; i < n; i++)
            {
                //выводим первую матрицу
                if (i < n1)
                {
                    Console.Write("|");
                    for (var j = 0; j < m1; j++)
                        Console.Write("{0,4}", matrix1[i, j]);
                    Console.Write("  |");
                }
                else
                {
                    Console.Write("    ");
                    for (var j = 0; j < m1; j++)
                        Console.Write("    ");
                }

                //выводим символ операции 
                Console.Write(i == 0 ? " x " : "   ");

                //выводим вторую матрицу
                if (i < n2)
                {
                    Console.Write("|");
                    for (var j = 0; j < m2; j++)
                        Console.Write("{0,4}", matrix2[i, j]);
                    Console.Write("  |");
                }
                else
                {
                    Console.Write("    ");
                    for (var j = 0; j < m2; j++)
                        Console.Write("    ");
                }

                //выводим символ равенства
                Console.Write(i == 0 ? " = " : "   ");

                //выводим результат
                if (i < n1)
                {
                    Console.Write("|");
                    for (var j = 0; j < m2; j++)
                        Console.Write("{0,5}", resMatrix[i, j]);
                    Console.Write("  |");
                }
                else
                {
                    Console.Write("    ");
                    for (var j = 0; j < m2; j++)
                        Console.Write("    ");
                }

                Console.WriteLine();
            }
        }
    }
}