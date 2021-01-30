using System;

namespace Example_005
{
    /// <summary>
    /// Utility class for handling arrays
    /// </summary>
    public static class UtilsArray
    {
        public enum ArrayOperation
        {
            Plus,
            Minus,
            Multiplication,
            Division
        }

        /// <summary>
        /// Return array of random value
        /// </summary>
        /// <param name="size">Array size</param>
        /// <param name="min">Min value in array</param>
        /// <param name="max">Max value in array</param>
        /// <returns>int[] Array</returns>
        public static int[] GetRandomIntArr(int size, int min, int max)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var arr = new int[size];
            for (var i = 0; i < size; i++)
            {
                arr[i] = random.Next(min, max + 1);
            }

            return arr;
        }

        /// <summary>
        /// Sum two arrays of type int and returns a new one
        /// </summary>
        /// <param name="arr1">Array N1</param>
        /// <param name="arr2">Array N2</param>
        /// <param name="operation">Type of operation</param>
        /// <returns>int[] Array</returns>
        /// <exception cref="Exception"></exception>
        public static int[] OperateIntArr(int[] arr1, int[] arr2, ArrayOperation operation)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new Exception("Количество элементов в массиве должно совпадать");
            }

            var resArr = new int[arr1.Length];

            for (var i = 0; i < arr1.Length; i++)
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
                        resArr[i] = (arr1[i] / arr2[i]);
                        break;
                    default:
                        resArr[i] = arr1[i];
                        break;
                }
            }

            return resArr;
        }

        /// <summary>
        /// Multiply matrix by number
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns>int[,] Array</returns>
        public static int[,] MultiplyMatrixByNumber(int[,] matrix, int k)
        {
            var resMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    resMatrix[i, j] = matrix[i, j] * k;
                }
            }

            return resMatrix;
        }

        /// <summary>
        /// Matrix multiplication
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            int n1 = matrix1.GetLength(0);
            int m1 = matrix1.GetLength(1);
            int n2 = matrix2.GetLength(0);
            int m2 = matrix2.GetLength(1);

            if (n2 != m1)
            {
                throw new Exception("Количество столбцов M1 должно быть равно количеству строк M2");
            }

            int[,] resMatrix = new int[n1, m2];
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

            return resMatrix;
        }

        /// <summary>
        /// Generating a random matrix
        /// </summary>
        /// <param name="n">Rows count</param>
        /// <param name="m">Columns count</param>
        /// <param name="min">Min value in matrix</param>
        /// <param name="max">Max value in matrix</param>
        /// <returns>int[,] Array</returns>
        public static int[,] GetRandomIntMatrix(int n, int m, int min, int max)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var matrix = new int[n, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    matrix[i, j] = random.Next(min, max);
                }
            }

            return matrix;
        }
    }
}