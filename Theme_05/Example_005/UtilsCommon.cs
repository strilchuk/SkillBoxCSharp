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
    }
}