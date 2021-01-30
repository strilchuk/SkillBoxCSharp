using System;
using System.Collections.Generic;

namespace Homework_Theme_04
{
    public class Task1
    {
        const int minSum = 50000;
        const int maxSum = 300000;        
       
        
        public static void doTask1()
        {
            // Задание 1.
            // Заказчик просит вас написать приложение по учёту финансов
            // и продемонстрировать его работу.
            // Суть задачи в следующем: 
            // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            // Количество месяцев с положительной прибылью.
            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            // Пример
            //       
            // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1              100 000             80 000                 20 000
            //     2              120 000             90 000                 30 000
            //     3               80 000             70 000                 10 000
            //     4               70 000             70 000                      0
            //     5              100 000             80 000                 20 000
            //     6              200 000            120 000                 80 000
            //     7              130 000            140 000                -10 000
            //     8              150 000             65 000                 85 000
            //     9              190 000             90 000                100 000
            //    10              110 000             70 000                 40 000
            //    11              150 000            120 000                 30 000
            //    12              100 000             80 000                 20 000
            // 
            // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            // Месяцев с положительной прибылью: 10
            
            Console.Clear();
            Utils.WriteOnCenter("Выполняем задачу 1");
            byte monthCountWithProfit = 0;
            int[] debetArr = Utils.getRandomIntArr(12, minSum, maxSum);
            int[] creditArr = Utils.getRandomIntArr(12, minSum, maxSum);
            int[] profitArr = Utils.sumIntArr(debetArr, creditArr, Utils.ArrayOperation.Minus);
            int[] profitArrCopy = new int[12];
            Array.Copy(profitArr, profitArrCopy, 12);
            profitArrCopy = Utils.groupIntArr(profitArrCopy); // сгруппируем массив прибыли по значению

            int N = profitArrCopy.Length < 3 ? profitArrCopy.Length : 3;
            int[] minProfitSumArr = new int[N];
            for (int i = 0; i < N; i++)
            {
                minProfitSumArr[i] = profitArrCopy[i];
            }
            
            //Определяем количество месяцев с положительной прибылью
            for (int i = 0; i < profitArr.Length; i++)
            {
                if (profitArr[i] > 0)
                {
                    monthCountWithProfit++;
                }
            }
            
            List<int> badMonthlist = new List<int>();
            
            //Определяем худшую прибыль в месяцах
            for (int i = 0; i < profitArr.Length; i++)
            {
                if (Array.Exists(minProfitSumArr, element => element == profitArr[i]))
                {
                    badMonthlist.Add(i + 1);
                }
            }
            
            //Выводим данные на экран
            Console.WriteLine("╔═══════╤════════════════════╤═════════════════════╤══════════════════════╗");
            Console.WriteLine("║ Месяц │  Доход, тыс. руб.  │  Расход, тыс. руб.  │  Прибыль, тыс. руб.  ║");
            Console.WriteLine("╠═══════╪════════════════════╪═════════════════════╪══════════════════════╣");
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("║  {0,2}   │ {1,16}   │ {2,17}   │  {3,18}  ║", 
                    i + 1, 
                    debetArr[i].ToString("### ###"), 
                    creditArr[i].ToString("### ###"), 
                    profitArr[i].ToString("### ###"));
                sum += profitArr[i];
            }
            Console.WriteLine("╚═══════╧════════════════════╧═════════════════════╧══════════════════════╝");
            Console.WriteLine("Итого:{0}", sum.ToString("### ### ###"));
            Console.WriteLine();
            Console.WriteLine("Худшая прибыль в месяцах: {0}", String.Join(", ", badMonthlist.ToArray()));
            Console.WriteLine("Месяцев с положительной прибылью: {0}", monthCountWithProfit);
        }

    }
}