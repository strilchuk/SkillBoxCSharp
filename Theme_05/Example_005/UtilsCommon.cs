using System;

namespace Example_005
{
    public class UtilsCommon
    {
        public enum UserInputStatus
        {
            Error,
            Empty,
            NoError
        }
        
        public enum Choice : byte
        {
            Exit,
            Task1,
            Task2,
            Task31,
            Task32,
            Task33,
            None = byte.MaxValue
        }
        
        /// <summary>
        /// Прочитать из значение типа Int, перегрузка с границами 
        /// </summary>
        /// <returns></returns>
        public static int ReadInt(int start, int end, ref UserInputStatus errors)
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

            if ((start != 0 || end != 0) &&
                (result < start || result > end))
            {
                ShowError($"Число должно быть в диапазоне от {start} до {end}");
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
        /// <param name="text"></param>
        /// <param name="onCenter"></param>
        public static void WriteOnCenter(String text, bool onCenter = false)
        {
            int columnLength = onCenter ? text.Length : 33;
            int cursorLeft = (int)((Console.WindowWidth - columnLength) / 2);
            
            if (cursorLeft > 0)
                Console.CursorLeft = cursorLeft;
            Console.WriteLine(text);    // Печать в консоль вспомогательного текста
        }
        
        /// <summary>
        /// Вывести на экран текст ошибки
        /// </summary>
        /// <param name="text"></param>
        public static void ShowError(String text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            WriteOnCenter(text);
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

        }
        
        public static Choice ShowMainMenu()
        {
            Choice resultChoice = Choice.None;
            WriteOnCenter("1: Задание 1");
            WriteOnCenter("2: Задание 2");
            WriteOnCenter("3: Задание 3");
            WriteOnCenter("4: Задание 4");
            WriteOnCenter("5: Задание 5");
            WriteOnCenter("════════════");
            WriteOnCenter("0: Выход");
            var error = UserInputStatus.NoError;
            resultChoice = (Choice) ReadInt(ref error);;
            if (error != UserInputStatus.NoError)
            {
                resultChoice = Choice.None;
            }
            return resultChoice;
        }
    }
}