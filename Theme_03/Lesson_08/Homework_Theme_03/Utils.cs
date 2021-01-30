using System;
using System.Diagnostics;
using System.Reflection;


namespace Homework_Theme_03
{
    class Utils
    {
        public const byte USER_INPUT_ERROR = 125;
        public const byte USER_INPUT_EMPTY = 124;

        /// <summary>
        /// Прочитать из значение типа Int
        /// </summary>
        /// <returns></returns>
        public static int ReadInt(int Start = 0, int End = 0)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                ShowError("Ошибка при воде числа, попробуйте еще раз");
                Console.Clear();
                result = Utils.USER_INPUT_ERROR;
            }

            if ((Start != 0 || End != 0) &&
                    (result < Start || result > End))
            {
                ShowError($"Число должно быть в диапазоне от {Start} до {End}");
                Console.Clear();
                result = Utils.USER_INPUT_ERROR;
            }

            return result;
        }

        /// <summary>
        /// Выводим строку по центру экрана
        /// </summary>
        /// <param name="Text"></param>
        public static void WriteOnCenter(String Text)
        {
            byte columnLength = 33;
            byte cursorLeft = (byte)((Console.WindowWidth - columnLength) / 2);

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
        /// Задать значение опции с типом Byte
        /// </summary>
        /// <param name="OptionsName"></param>
        /// <param name="DefaultValue"></param>
        /// <returns></returns>
        public static int SetOptions(String OptionsName, int DefaultValue, String Text)
        {
            do
            {
                Console.Clear();
                WriteOnCenter(Text);
                WriteOnCenter($"Текущее значение: {DefaultValue}");
                int Value = 0;
                switch (OptionsName)
                {
                    case "PlayerCount":
                        Value = ReadInt(2, 100);
                        break;
                    case "userTryCountMax":
                        Value = ReadInt(-1, 1000);
                        break;
                    case "gameNumberMax":
                        Value = ReadInt(0, 1000);
                        break;
                    case "gameNumberMin":
                        Value = ReadInt(0, 1000);
                        break;
                    default:
                        Value = ReadInt();
                        break;
                }
                    
                if (Value != Utils.USER_INPUT_ERROR)
                {
                    return Value;
                }
            } while (true);
            return DefaultValue;
        }
    }
}
