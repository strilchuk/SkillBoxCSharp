using System;

namespace Homework_Theme_04
{
    public class Utils
    {
        public enum UserInputStatus
        {
            Error,
            Empty,
            NoError
        }

        public enum ArrayOperation
        {
            Plus,
            Minus,
            Multiplication,
            Division
        }

        /// <summary>
        /// Прочитать из значение типа Int, перегрузка с границами 
        /// </summary>
        /// <returns></returns>
        public static int ReadInt(int Start, int End, ref UserInputStatus errors)
        {
            int result = 0;
            errors = UserInputStatus.NoError;
            try
            {
                result = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                ShowError("Ошибка при вводе числа, попробуйте еще раз");
                Console.Clear();
                errors = UserInputStatus.Error;
            }

            if ((Start != 0 || End != 0) &&
                (result < Start || result > End))
            {
                ShowError($"Число должно быть в диапазоне от {Start} до {End}");
                Console.Clear();
                errors = UserInputStatus.Error;
            }

            return result;
        }
        
        /// <summary>
        /// Прочитать из значение типа Int
        /// </summary>
        /// <returns></returns>
        public static int ReadInt(ref UserInputStatus errors)
        {
            return ReadInt(0,0, ref errors);
        }
        
        /// <summary>
        /// Выводим строку по центру экрана
        /// </summary>
        /// <param name="Text"></param>
        public static void WriteOnCenter(String Text, bool onCenter = false)
        {
            int columnLength = onCenter ? Text.Length : 33;
            int cursorLeft = (int)((Console.WindowWidth - columnLength) / 2);
            
            if (cursorLeft > 0)
                Console.CursorLeft = cursorLeft;
            Console.WriteLine(Text);    // Печать в консоль вспомогательного текста
        }
        
        /// <summary>
        /// Вывести на экран текст ошибки
        /// </summary>
        /// <param name="Text"></param>
        public static void ShowError(String Text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            WriteOnCenter(Text);
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

        }
        
        /// <summary>
        /// Возвращает массив случайных значений
        /// </summary>
        /// <param name="size">Размерность</param>
        /// <param name="min">Минимальное значение в массиве</param>
        /// <param name="max">Максимальное значение в массиве</param>
        /// <returns>int[]</returns>
        public static int[] getRandomIntArr(int size, int min, int max)
        {
            System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(min, max + 1);
            }
            return arr;
        }
        
        /// <summary>
        /// Складывает два массива типа int и возвращает новый
        /// </summary>
        /// <param name="arr1">Массив 1</param>
        /// <param name="arr2">Массив 2</param>
        /// <returns>int[]</returns>
        public static int[] sumIntArr(int[] arr1, int[] arr2, ArrayOperation operation = ArrayOperation.Plus)
        {
            if (arr1.Length != arr2.Length)
            {
                new Exception("Количество элементов в массиве должно совпадать");
            }

            int[] resArr = new int[arr1.Length];

            for (int i = 0; i < arr1.Length ; i++)
            {
                switch (operation)
                {
                    case ArrayOperation.Plus:
                        resArr[i] = arr1[i] + arr2[i];
                        break;
                    case ArrayOperation.Minus:
                        resArr[i] = arr1[i] - arr2[i];
                        break;
                    case ArrayOperation.Multiplication:
                        resArr[i] = arr1[i] * arr2[i];
                        break;                    
                    case ArrayOperation.Division:
                        resArr[i] = (int)(arr1[i] / arr2[i]);
                        break;                         
                }
            }
            return resArr;
        }

        /// <summary>
        /// Сортирует, а затем группирует массив по его эллементма 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] groupIntArr(int[] arr)
        {
            Array.Sort(arr);
            int newArrLength = arr.Length;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    newArrLength--;
                }
            }

            int[] newArr = new int[newArrLength];

            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Array.IndexOf(newArr, arr[i]) == -1)
                {
                    newArr[j] = arr[i];
                    j++;
                }
            }
            Array.Sort(newArr);
            return newArr;
        }
        
        /// <summary>
        /// Вычисляет факториал числа
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static float factorial(int n)
        {
            float i, x = 1;
            for (i = 1; i <= n; i++)
            {
                x *= i;
            }
            return x;
        }

        /// <summary>
        /// Генерация случайной матрицы
        /// </summary>
        /// <param name="n">Строки</param>
        /// <param name="m">Столбцы</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <returns></returns>
        public static int[,] getRandomIntMatrix(int n, int m, int min, int max)
        {
            System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
            int[,] matrix = new int[n,m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i,j] = random.Next(min, max);
                }
            }
            return matrix;
        }
    }
}