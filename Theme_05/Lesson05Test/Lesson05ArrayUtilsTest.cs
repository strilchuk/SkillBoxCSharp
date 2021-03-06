﻿using System;
using NUnit.Framework;
using Example_005;

namespace Lesson05Test
{
    [TestFixture]
    public class Lesson05ArrayUtilsTest
    {
        [TestCase(
            4,
            2,
            2,
            new[] {2, 2, 2, 2},
            TestName = "TC-0001",
            Description = "Получить случайный Int массив"
        )]
        [TestCase(
            0,
            1,
            1,
            new int[] { },
            TestName = "TC-0002",
            Description = "Получить случайный Int массив"
        )]
        public void GetRandomIntArrTest(int size, int min, int max, int[] expectedResult)
        {
            var array = UtilsArray.GetRandomIntArr(size, min, max);
            Assert.That(array, Is.EqualTo(expectedResult));
        }

        [TestCase(
            new[] {1, 1},
            new[] {1, 1},
            UtilsArray.ArrayOperation.Plus,
            new[] {2, 2},
            TestName = "TC-0003",
            Description = "Сложить два массива"
        )]
        [TestCase(
            new[] {1, 1},
            new[] {1},
            UtilsArray.ArrayOperation.Plus,
            new int[] { },
            TestName = "TC-0004",
            Description = "Сложить два массива с ошибкой"
        )]
        [TestCase(
            new[] {2, 2},
            new[] {1, 1},
            UtilsArray.ArrayOperation.Minus,
            new[] {1, 1},
            TestName = "TC-0005",
            Description = "Вычесть один массив из другого"
        )]
        [TestCase(
            new[] {2, 2},
            new[] {3, 1},
            UtilsArray.ArrayOperation.Multiplication,
            new[] {6, 2},
            TestName = "TC-0006",
            Description = "Умножить один массив на другой"
        )]
        [TestCase(
            new[] {11, 7},
            new[] {14, 5},
            UtilsArray.ArrayOperation.Division,
            new[] {0, 1},
            TestName = "TC-0007",
            Description = "Разделить один массив на другой"
        )]
        public void OperateIntArrTest(
            int[] arr1,
            int[] arr2,
            UtilsArray.ArrayOperation operation,
            int[] expectedResult
        )
        {
            if (arr1.Length == arr2.Length)
            {
                var actualArray = UtilsArray.OperateIntArr(arr1, arr2, operation);
                Assert.That(actualArray, Is.EqualTo(expectedResult));
            }
            else
            {
                Assert.Throws<Exception>(() => UtilsArray.OperateIntArr(arr1, arr2, operation));
            }
        }

        [TestCase(
            TestName = "TC-0008",
            Description = "Умножение матрицы на число"
        )]
        public void MultiplyMatrixByNumberTest()
        {
            int[,] inputMatrix = new int[,] {{11, 11, 11}, {11, 11, 11}, {11, 11, 11}};
            int[,] expectedMatrix = new int[,] {{55, 55, 55}, {55, 55, 55}, {55, 55, 55}};
            int k = 5;

            int[,] actualMatrix = UtilsArray.MultiplyMatrixByNumber(inputMatrix, k);
            Assert.That(actualMatrix, Is.EqualTo(expectedMatrix));
        }

        [TestCase(
            TestName = "TC-0009",
            Description = "Получить случайную матрицу"
        )]
        public void GetRandomIntMatrixTest()
        {
            int[,] actualMatrix = UtilsArray.GetRandomIntMatrix(3, 3, 3, 3);
            Assert.IsTrue(actualMatrix.GetLength(0) == 3);
            Assert.IsTrue(actualMatrix.GetLength(1) == 3);
            for (var i = 0; i < actualMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < actualMatrix.GetLength(1); j++)
                {
                    Assert.IsTrue(actualMatrix[i, j] == 3);
                }
            }
        }

        [TestCase(
            TestName = "TC-0010",
            Description = "Перемножение матриц"
        )]
        public void MatrixMultiplicationTest()
        {
            int[,] matrix1 = {{1, 3, 5}, {4, 5, 7}, {5, 3, 1}};
            int[,] matrix2 = {{1, 3, 4}, {2, 5, 6}, {3, 6, 7}};
            int[,] expectedMatrix1 = {{22, 48, 57}, {35, 79, 95}, {14, 36, 45}};
            int[,] actualMatrix1 = UtilsArray.MatrixMultiplication(matrix1, matrix2);

            for (var i = 0; i < actualMatrix1.GetLength(0); i++)
            {
                for (var j = 0; j < actualMatrix1.GetLength(1); j++)
                {
                    Assert.IsTrue(actualMatrix1[i, j] == expectedMatrix1[i, j]);
                }
            }

            int[,] matrix3 = {{1, 2, 3}};
            int[,] matrix4 = {{4}, {5}, {6}};
            int[,] expectedMatrix2 = {{32}};
            int[,] actualMatrix2 = UtilsArray.MatrixMultiplication(matrix3, matrix4);

            for (var i = 0; i < actualMatrix2.GetLength(0); i++)
            {
                for (var j = 0; j < actualMatrix2.GetLength(1); j++)
                {
                    Assert.IsTrue(actualMatrix2[i, j] == expectedMatrix2[i, j]);
                }
            }

            int[,] matrix5 = {{1, 2, 3, 4}};
            int[,] matrix6 = {{4}, {5}, {6}};

            Assert.Throws<Exception>(() => UtilsArray.MatrixMultiplication(matrix5, matrix6));
        }
        
        [TestCase(
            TestName = "TC-0011",
            Description = "Сложение и вычитание матриц"
        )]
        public void SummationMatrixTest()
        {
            int[,] matrix1 = {{1, 3, 5}, {4, 5, 7}, {5, 3, 1}};
            int[,] matrix2 = {{1, 3, 4}, {2, 5, 6}, {3, 6, 7}};
            int[,] expectedMatrix1 = {{2, 6, 9}, {6, 10, 13}, {8, 9, 8}};
            int[,] expectedMatrix2 = {{0, 0, 1}, {2, 0, 1}, {2, -3, -6}};
            int[,] actualMatrix1 = UtilsArray.SummationMatrix(matrix1, matrix2, UtilsArray.MatrixOperation.Plus);
            int[,] actualMatrix2 = UtilsArray.SummationMatrix(matrix1, matrix2, UtilsArray.MatrixOperation.Minus);

            for (var i = 0; i < actualMatrix1.GetLength(0); i++)
            {
                for (var j = 0; j < actualMatrix1.GetLength(1); j++)
                {
                    Assert.IsTrue(actualMatrix1[i, j] == expectedMatrix1[i, j]);
                }
            }
            for (var i = 0; i < actualMatrix2.GetLength(0); i++)
            {
                for (var j = 0; j < actualMatrix2.GetLength(1); j++)
                {
                    Assert.IsTrue(actualMatrix2[i, j] == expectedMatrix2[i, j]);
                }
            }
            
            int[,] matrix5 = {{1, 3}, {4, 5}};
            int[,] matrix6 = {{1, 3, 4}, {2, 5, 6}, {3, 6, 7}};
            Assert.Throws<Exception>(() => UtilsArray.SummationMatrix(
                matrix5, 
                matrix6, 
                UtilsArray.MatrixOperation.Plus)
            );
            Assert.Throws<Exception>(() => UtilsArray.SummationMatrix(
                matrix5, 
                matrix6, 
                UtilsArray.MatrixOperation.Minus)
            );            
        }
    }
}