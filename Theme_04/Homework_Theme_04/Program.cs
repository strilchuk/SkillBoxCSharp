using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Program
    {
        public enum Choice : byte
        {
            Exit,
            Task1,
            Task2,
            Task31,
            Task32,
            Task33,
            None = Byte.MaxValue
        }

        static void Main(string[] args)
        {
            Utils.UserInputStatus ChoiceStatus = Utils.UserInputStatus.Empty;
            Choice UserChoice = Choice.None;
            do
            {
                Console.Clear();

                if (ChoiceStatus == Utils.UserInputStatus.Empty || ChoiceStatus == Utils.UserInputStatus.Error) // 
                {
                    UserChoice = ShowMainMenu(); // Отображаем главное меню
                }
                else
                {
                    ChoiceStatus = Utils.UserInputStatus.Empty;
                    Console.ReadKey();
                }
                
                switch (UserChoice)
                {
                    case Choice.Task1:
                        Task1.doTask1();
                        break;
                    case Choice.Task2:
                        Task2.doTask2();
                        break;
                    case Choice.Task31:
                        Task31.doTask31();
                        break;
                    case Choice.Task32:
                        Task32.doTask32();
                        break;
                    case Choice.Task33:
                        Task33.doTask33();
                        break;    
                    case Choice.Exit:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();

            } while (true);
        }

        /// <summary>
        /// Отобразить главное меню
        /// </summary>
        /// <returns></returns>
        public static Choice ShowMainMenu()
        {
            Choice resultChoice = Choice.None;
            
            Utils.WriteOnCenter("1 Задание 1");
            Utils.WriteOnCenter("2 Задание 2");
            Utils.WriteOnCenter("3 Задание 3.1");
            Utils.WriteOnCenter("4 Задание 3.2");
            Utils.WriteOnCenter("5 Задание 3.3");
            Utils.WriteOnCenter("-----------------------");
            Utils.WriteOnCenter("0 Выход");

            var error = Utils.UserInputStatus.NoError;
            resultChoice = (Choice) Utils.ReadInt(ref error);;
            if (error != Utils.UserInputStatus.NoError)
            {
                resultChoice = Choice.None;
            }

            return resultChoice;
        }
    }
}