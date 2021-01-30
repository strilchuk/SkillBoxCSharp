using System;

namespace Example_005
{
    internal static class Program
    {
        private static void Main()
        {
            var exit = false;
            do
            {
                Console.Clear();
                var userChoice = UtilsCommon.ShowMainMenu(); // Отображаем главное меню
                
                switch (userChoice)
                {
                    case UtilsCommon.Choice.Task1:
                        Task1.DoTask();
                        break;
                    case UtilsCommon.Choice.Task2:
                        Task2.DoTask();
                        break;
                    case UtilsCommon.Choice.Task31:
                        Task3.DoTask();
                        break;
                    case UtilsCommon.Choice.Task32:
                        Task4.DoTask();
                        break;
                    case UtilsCommon.Choice.Task33:
                        Task5.DoTask();
                        break;    
                    case UtilsCommon.Choice.Exit:
                        exit = true;
                        break;
                    case UtilsCommon.Choice.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.ReadKey();

            } while (!exit);
        }
    }
}
