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
        /// <param name="Size">Array size</param>
        /// <param name="Min">Min value in array</param>
        /// <param name="Max">Max value in array</param>
        /// <returns>int[] Array</returns>
        public static int[] GetRandomIntArr(int Size, int Min, int Max)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var arr = new int[Size];
            for (var i = 0; i < Size; i++)
            {
                arr[i] = random.Next(Min, Max + 1);
            }

            return arr;
        }

        /// <summary>
        /// Sum two arrays of type int and returns a new one
        /// </summary>
        /// <param name="Arr1">Array N1</param>
        /// <param name="Arr2">Array N2</param>
        /// <param name="Operation">Type of operation</param>
        /// <returns>int[] Array</returns>
        /// <exception cref="Exception"></exception>
        public static int[] OperateIntArr(int[] Arr1, int[] Arr2, ArrayOperation Operation)
        {
            if (Arr1.Length != Arr2.Length)
            {
                throw new Exception("Количество элементов в массиве должно совпадать");
            }

            var resArr = new int[Arr1.Length];

            for (var i = 0; i < Arr1.Length; i++)
            {
                switch (Operation)
                {
                    case ArrayOperation.Plus:
                        resArr[i] = Arr1[i] + Arr2[i];
                        break;
                    case ArrayOperation.Minus:
                        resArr[i] = Arr1[i] - Arr2[i];
                        break;
                    case ArrayOperation.Multiplication:
                        resArr[i] = Arr1[i] * Arr2[i];
                        break;
                    case ArrayOperation.Division:
                        resArr[i] = (Arr1[i] / Arr2[i]);
                        break;
                    default:
                        resArr[i] = Arr1[i];
                        break;
                }
            }

            return resArr;
        }

        /// <summary>
        /// Multiply matrix by number
        /// </summary>
        /// <param name="Matrix"></param>
        /// <param name="k"></param>
        /// <returns>int[,] Array</returns>
        public static int[,] MultiplyMatrixByNumber(int[,] Matrix, int k)
        {
            var resMatrix = new int[Matrix.GetLength(0), Matrix.GetLength(1)];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    resMatrix[i, j] = Matrix[i, j] * k;
                }
            }

            return resMatrix;
        }

        /// <summary>
        /// Matrix multiplication
        /// </summary>
        /// <param name="Matrix1"></param>
        /// <param name="Matrix2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int[,] MatrixMultiplication(int[,] Matrix1, int[,] Matrix2)
        {
            int n1 = Matrix1.GetLength(0);
            int m1 = Matrix1.GetLength(1);
            int n2 = Matrix2.GetLength(0);
            int m2 = Matrix2.GetLength(1);

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
                        resMatrix[i, j] += Matrix1[i, k] * Matrix2[k, j];
                    }
                }
            }

            return resMatrix;
        }

        /// <summary>
        /// Generating a random matrix
        /// </summary>
        /// <param name="N">Rows count</param>
        /// <param name="M">Columns count</param>
        /// <param name="Min">Min value in matrix</param>
        /// <param name="Max">Max value in matrix</param>
        /// <returns>int[,] Array</returns>
        public static int[,] GetRandomIntMatrix(int N, int M, int Min, int Max)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var matrix = new int[N, N];
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    matrix[i, j] = random.Next(Min, Max);
                }
            }

            return matrix;
        }
    }
}